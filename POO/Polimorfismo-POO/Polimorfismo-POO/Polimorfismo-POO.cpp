// Polimorfismo-POO.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>
using namespace std;

class Animal {
private:
	int edad;
public:
	Animal(int);
	~Animal();
	void mostrar();
	virtual void comer();
};

Animal::Animal(int _edad) {
	edad = _edad;
}

Animal::~Animal() {

}

void Animal::mostrar() {
	cout << "Edad: " << edad << endl;
}

void Animal::comer() {
	cout << "ESTE ANIMAL COME: " << endl;
}

//--------------------------------------------------------------------------------------//

class Humano : public Animal {
private:
	string nombre;
public:
	Humano(int, string);
	~Humano();
	void comer();
};

Humano::Humano(int _edad, string _nombre) : Animal(_edad){
	nombre = _nombre;
}

Humano::~Humano() {

}

void Humano::comer() {
	Animal::comer();
	cout << "comida humana" << endl;
}

//------------------------------------------------------------------------//

class Perro : public Animal {
private:
	string raza;
public:
	Perro(int, string);
	~Perro();
	void comer();
};

Perro::Perro(int _edad, string _raza) : Animal(_edad){
	raza = _raza;
}

Perro::~Perro() {

}

void Perro::comer() {
	Animal::comer();
	cout << "croquetas" << endl;
}


/*
class Persona {
private:
	string nombre;
	int edad;
public:
	Persona(string, int);
	~Persona();
	virtual void mostrar();//polimorfismo
};

Persona::Persona(string _nombre, int _edad) {
	nombre = _nombre;
	edad = _edad;
}

Persona::~Persona(){}

void Persona::mostrar() {
	cout << "Nombre " << nombre << endl;
	cout << "Edad " << edad << endl;
}

//------------------------------------------------------------------------------------------------//
class Alumno : public Persona{
private:
	string registro;
	float calificacion;
public:
	Alumno(string, int, string, float);
	~Alumno();
	void mostrar();
};

Alumno::Alumno(string _nombre, int _edad, string _registro, float _calificacion) : Persona(_nombre, _edad){
	registro = _registro;
	calificacion = _calificacion;
}

Alumno::~Alumno() {

}

void Alumno::mostrar() {
	Persona::mostrar();
	cout << "Registro " << registro << endl;
	cout << "Calificacion " << calificacion << endl;
}
//----------------------------------------------------------------------//

class Profesor : public Persona {
private:
	string materia;
public:
	Profesor(string, int, string);
	~Profesor();
	void mostrar();
};

Profesor::Profesor(string _nombre, int _edad, string _materia) : Persona(_nombre, _edad){
	materia = _materia;
}

Profesor::~Profesor(){}

void Profesor::mostrar() {
	Persona::mostrar();
	cout << "Materia " << materia << endl;
}
 
 */
int main()
{
	/*
	Persona* vector[3];

	vector[0] = new Alumno("ramiro", 20, "21300676", 100);
	vector[1] = new Alumno("oliver", 18, "21300676", 98);
	vector[2] = new Profesor("Molina", 55, "proyecto");
   
	vector[0]->mostrar();
	cout << endl;
	vector[1]->mostrar();
	cout << endl;
	vector[2]->mostrar();
	*/

	Animal* arr[3];

	arr[0] = new Humano(13, "jose");
	arr[0]->mostrar();
	arr[0]->comer();
	cout << endl;

	arr[1] = new Perro(2, "lobo mexicano");
	arr[1]->comer();
	cout << endl;
}

