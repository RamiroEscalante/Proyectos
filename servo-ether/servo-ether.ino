#include <Servo.h>
#include <SPI.h>
#include <Ethernet.h>

Servo myservo;
int servoPin = 9;
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192, 168, 229, 216); // Cambia esta IP según tu red
EthernetServer server(80);

void setup() {
  myservo.attach(servoPin);
  Ethernet.begin(mac, ip);
  server.begin();
}

void loop() {
  EthernetClient client = server.available();

  if (client) {
    String request = client.readStringUntil('\n');
    
    // Procesar la solicitud para establecer ángulo
    if (request.indexOf("/angle=") != -1) {
      int angle = request.substring(request.indexOf("=") + 1).toInt();
      myservo.write(angle);
      client.println("HTTP/1.1 200 OK");
      client.println("Content-Type: text/html");
      client.println("Connection: close");
      client.println();
      client.println("Ángulo establecido");
    }

    // Procesar la solicitud para secuencia de ángulos
    else if (request.indexOf("/sequence?angles=") != -1) {
      String anglesStr = request.substring(request.indexOf("=") + 1);
      int commaPos;
      
      while ((commaPos = anglesStr.indexOf(",")) != -1) {
        int angle = anglesStr.substring(0, commaPos).toInt();
        myservo.write(angle);
        delay(1000); // Esperar un segundo entre cada ángulo
        anglesStr = anglesStr.substring(commaPos + 1);
      }

      // Escribir el último ángulo
      int lastAngle = anglesStr.toInt();
      myservo.write(lastAngle);
      delay(1000);

      client.println("HTTP/1.1 200 OK");
      client.println("Content-Type: text/html");
      client.println("Connection: close");
      client.println();
      client.println("Secuencia de ángulos ejecutada");
    }
    
    // Si no es una solicitud de control, envía el HTML de la página
    else {
      client.println("HTTP/1.1 200 OK");
      client.println("Content-Type: text/html");
      client.println("Connection: close");
      client.println();
      client.println("<!DOCTYPE html>");
      client.println("<html lang='es'>");
      client.println("<head>");
      client.println("<meta charset='UTF-8'>");
      client.println("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
      client.println("<title>Cabina de Control de Servomotor</title>");
      client.println("<style>");
      client.println("body { font-family: Arial, sans-serif; display: flex; justify-content: center; align-items: center; height: 100vh; background-color: #333; color: #fff; }");
      client.println("#dashboard { text-align: center; width: 300px; background: #222; border-radius: 10px; padding: 20px; box-shadow: 0 0 15px rgba(0,0,0,0.5); }");
      client.println("h1 { font-size: 24px; color: #00c1c1; }");
      client.println("#angleDisplay { width: 120px; height: 120px; margin: 20px auto; border: 5px solid #555; border-radius: 50%; position: relative; }");
      client.println("#needle { position: absolute; width: 2px; height: 60px; background: #e74c3c; left: 50%; top: 10px; transform-origin: bottom; transform: rotate(90deg); }");
      client.println("#controls { display: flex; flex-direction: column; align-items: center; }");
      client.println("input[type=range] { width: 80%; margin: 10px 0; }");
      client.println("button { padding: 10px 20px; font-size: 16px; margin-top: 15px; background-color: #00c1c1; color: #222; border: none; border-radius: 5px; cursor: pointer; transition: background 0.3s; }");
      client.println("button:hover { background-color: #019a9a; }");
      client.println("#sequenceInput { margin: 15px 0; }");
      client.println("input[type='number'] { margin: 5px; width: 50px; }");
      client.println("</style>");
      client.println("</head>");
      client.println("<body>");
      client.println("<div id='dashboard'>");
      client.println("<h1>Cabina de Control de Servomotor</h1>");
      client.println("<div id='angleDisplay'>");
      client.println("<div id='needle'></div>");
      client.println("</div>");
      client.println("<div id='angleControl'>");
      client.println("<label>Ángulo: <span id='angleValue'>90</span>°</label>");
      client.println("<input type='range' id='angleSlider' min='0' max='180' value='90' step='1'>");
      client.println("</div>");
      client.println("<button onclick='setAngle()'>Establecer Ángulo</button>");
      client.println("<div id='sequenceInput'>");
      client.println("<label>Secuencia de Ángulos:</label><br>");
      client.println("<input type='number' id='angle1' min='0' max='180' placeholder='0°'>");
      client.println("<input type='number' id='angle2' min='0' max='180' placeholder='45°'>");
      client.println("<input type='number' id='angle3' min='0' max='180' placeholder='90°'>");
      client.println("<input type='number' id='angle4' min='0' max='180' placeholder='135°'>");
      client.println("</div>");
      client.println("<button onclick='runCustomSequence()'>Ejecutar Secuencia Personalizada</button>");
      client.println("</div>");
      client.println("<script>");
      client.println("const ip = '192.168.229.216';");
      client.println("document.getElementById('angleSlider').oninput = function() {");
      client.println("  const angle = this.value;");
      client.println("  document.getElementById('angleValue').textContent = angle;");
      client.println("  document.getElementById('needle').style.transform = `rotate(${angle - 90}deg)`;");
      client.println("};");
      client.println("function setAngle() {");
      client.println("  const angle = document.getElementById('angleSlider').value;");
      client.println("  fetch(`http://${ip}/angle=${angle}`)");
      client.println("    .then(response => console.log(`Ángulo establecido a ${angle}°`))");
      client.println("    .catch(error => console.error('Error:', error));");
      client.println("}");
      client.println("function runCustomSequence() {");
      client.println("  const angles = [");
      client.println("    document.getElementById('angle1').value,");
      client.println("    document.getElementById('angle2').value,");
      client.println("    document.getElementById('angle3').value,");
      client.println("    document.getElementById('angle4').value");
      client.println("  ];");
      client.println("  const validAngles = angles.filter(angle => angle !== '' && angle >= 0 && angle <= 180);");
      client.println("  if (validAngles.length > 0) {");
      client.println("    fetch(`http://${ip}/sequence?angles=${validAngles.join(',')}`)");
      client.println("      .then(response => console.log('Secuencia personalizada ejecutada'))");
      client.println("      .catch(error => console.error('Error:', error));");
      client.println("  } else {");
      client.println("    console.error('Por favor, ingresa ángulos válidos.');");
      client.println("  }");
      client.println("}");
      client.println("</script>");
      client.println("</body>");
      client.println("</html>");
    }

    client.stop();
  }
}
