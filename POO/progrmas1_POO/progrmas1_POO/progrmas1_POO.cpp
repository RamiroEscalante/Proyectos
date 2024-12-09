//clases en c++

#include <iostream>
#include <stdlib.h>
#include <string>
using namespace std;

class Rectangulo {
private:
	float largo;
	float ancho;
public:
	Rectangulo(float, float);
	void perimetro();
	void area();
};

Rectangulo::Rectangulo(float _largo, float _ancho) {
	largo = _largo;
	ancho = _ancho;
}

void Rectangulo::area() {
	float Area;
	Area = ancho * largo;

	cout << "El area = " << Area << endl;
}

void Rectangulo::perimetro() {
	float Perimetro;
	Perimetro = (2 * ancho) + (2 * largo);

	cout << "El perimetro = " << Perimetro << endl;
}


/*class Persona {
private://atributos
	int edad;
	string nombre;
public://metodos
	Persona(int, string);//constructor
	void leer();
	void correr();
};

//constructor, nos sirve para inicializar los atributos
Persona::Persona(int _edad, string _nombre) {
	edad = _edad;
	nombre = _nombre;
}

void Persona::leer() {
	cout << "Soy " << nombre << " y estoy leyendo un libro" << "y tengo" << edad << endl;
}

void Persona::correr() {
	cout << "Soy " << nombre << " y estoy corriendo un maraton" << " y tengo" << edad  << endl;
}
*/

int main()
{
	
	Rectangulo m1 = Rectangulo(7, 11);
	
	m1.area();
	m1.perimetro();

	/*Persona p1 = Persona(20, "Ramiro");
	Persona p2(19, "Maria");
	Persona p3(18, "juan");
	p2.correr();
	p1.leer();

	p3.correr();
	p3.leer();
	*/
}

