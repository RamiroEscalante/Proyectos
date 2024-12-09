#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
const int sensor = A0;
void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 2);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:

  lcd.clear();

  int voltajeAnalogico = analogRead(sensor);

  float voltaje = voltajeAnalogico * (5000.0 / 1024);

  float temperatura = voltaje / 20.0;

  lcd.setCursor(0, 0);
  lcd.print("voltaje: ");
  lcd.print(voltaje);

  lcd.setCursor(0, 1);
  lcd.print("tem: ");
  lcd.print(temperatura);

  binario(temperatura);
  delay(1000);
}

void binario(int temp){
  for(int i = 9; i > 0; i--){
    Serial.print(bitRead(temp,i));
    
  }
  Serial.println("");
}
