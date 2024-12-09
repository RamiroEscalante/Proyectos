#include <SPI.h>

#include <Ethernet.h>

#include <UbidotsEthernet.h>

#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN 2
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);

byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xE };

char const *TOKEN = "BBUS-YrduXUNbVVPJ8A6xrio7TTcstFEerK";
char const *TEMP_LABEL = "temperatura";
char const *HUM_LABEL = "humedad";



Ubidots client(TOKEN);


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  dht.begin();

  Serial.println("Se esta inicializando...");

  if (Ethernet.begin(mac) == 0) {
    Serial.println("No se pudo conectar");
    while (true)
      ;
  }
  delay(1000);
  Serial.println("Se logro la conexion ethernet");
}

void loop() {
  // put your main code here, to run repeatedly:

  float t = dht.readTemperature();
  float h = dht.readHumidity();

  if (isnan(h) || isnan(t)) {
    Serial.println("No se leyeron los datos");
    return;
  }

  Serial.println("temperatura: ");
  Serial.println(t);

  Serial.println("Humedad: ");
  Serial.println(h);

  //esto va a mandar los datos a ubidots
  client.add(TEMP_LABEL, t);
  client.add(HUM_LABEL, h);

  bool enviar = client.sendAll();

  if (enviar) {
    Serial.println("Se enviaron correctamente");
  } else {
    Serial.println("Se enviaron mal");
  }

  delay(15000);
}
