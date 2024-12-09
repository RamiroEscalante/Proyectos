//sobrecarga de constructores

#include <iostream>
#include <stdlib.h>

using namespace std;

class Tiempo {
private:
	int horas, minutos, segundos;
public:
	Tiempo(int, int, int);
	Tiempo(long);
	void mostraTimepo();
};

Tiempo::Tiempo(int _horas, int _minutos, int _segundos) {
	horas = _horas;
	minutos = _minutos;
	segundos = _segundos;
}

Tiempo::Tiempo(long timpo) {
	
	horas = int(timpo / 3600);
	
	minutos = int((timpo % 3600) / 60);

	segundos = int(((timpo % 3600) % 60));
	
}

void Tiempo::mostraTimepo() {
	cout << horas << ":" << minutos << ":" << segundos << endl;
}

/*class Fecha {
private:
	int dia, mes, anio;
public:
	Fecha(int, int, int);
	Fecha(long);
	void mostraFecha();
};

Fecha::Fecha(int _dia, int _mes, int _anio) {
	dia = _dia;
	mes = _mes;
	anio = _anio;
}

Fecha::Fecha(long fecha) {
	anio = int(fecha / 10000);
	mes = int((fecha % 10000) / 100);
	dia = int(((fecha % 10000) % 100));
}

void Fecha::mostraFecha() {
	cout << "La fecha es: " << dia << "/" << mes << "/" << anio << endl;
}
*/
int main()
{

	Tiempo t1 = Tiempo(15, 45, 34);
	t1.mostraTimepo();

	Tiempo t2(7500);
	t2.mostraTimepo();
		/*Fecha f1(30, 10, 2024);
	Fecha ayer(20241030);

	f1.mostraFecha();

	ayer.mostraFecha();
	*/

}

