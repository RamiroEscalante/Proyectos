//DESTRUCTOR

#include <iostream>
using namespace std;

class Perro {
private:
	string nombre;
	string raza;
public:
	Perro(string, string);
	~Perro();// destructor
	void mostrarDatos();
	void jugar();
};

Perro::Perro(string _nombre, string _raza) {
	nombre = _nombre;
	raza = _raza;
}

Perro::~Perro() {
}

void Perro::mostrarDatos() {
	cout << "Nombre: " << nombre << endl;
	cout << "Raza: " << raza << endl;
}

void Perro::jugar() {
	cout << "Esta jugando el perro" << nombre << endl;
}

int main()
{
	Perro p1("rodolfo", "desconocida");
	p1.jugar();
	p1.mostrarDatos();
	p1.~Perro();//destruye un objeto de la clase 

}

 