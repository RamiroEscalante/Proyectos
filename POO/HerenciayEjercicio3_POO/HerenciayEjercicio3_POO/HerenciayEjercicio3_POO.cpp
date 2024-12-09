
#include <iostream>
#include <stdlib.h>
using namespace std;

/*class Persona {
private :
	string nombre;
	int edad;
public:
	Persona(string, int);
	~Persona();
	void mostrarPersona();
	string get();
};

Persona::Persona(string _nombre, int _edad) {
	edad = _edad;
	nombre = _nombre;
}

Persona::~Persona() {

}

void Persona::mostrarPersona() {
	cout << "La persona es: " << nombre << "y su edad es: " << edad << endl;
}

class Alumno : public Persona{
private:
	string codigoAlumno;
	float notaFinal;
public:
	Alumno(string, int, string, float);
	void mostrarAlumno();
};

Alumno::Alumno(string _nombre, int _edad, string _codigoAlumno, float _notaFinal) : Persona (_nombre, _edad){
	codigoAlumno = _codigoAlumno;
	notaFinal = _notaFinal;
}

void Alumno::mostrarAlumno() {
	mostrarPersona();
	cout << "El codigo es: " << codigoAlumno << " y su calificacion es: " << notaFinal << end  l;

}*/

class Persona {
private:
	string nombre;
	int edad;
public:
	Persona();
	~Persona();
	void setDatosPersona(string , int);
	string getNombre();
	int getEdad();
};

Persona::Persona() {

}

Persona::~Persona() {

}

void Persona::setDatosPersona(string _nombre, int _edad) {
	nombre = _nombre;
	edad = _edad;
}

string Persona::getNombre() {
	return nombre;
}

int Persona::getEdad() {
	return edad;
}

//------------------------------------------------------------//

class Estudiante : public Persona{
private:
	string registro;
	float calificacion;
public:
	Estudiante();
	~Estudiante();
	void setDatosEstudiante(string, int , string , float);
	string getRegistro();
	float getCalificacion();
};

Estudiante::Estudiante() {

}

Estudiante::~Estudiante() {

}

void Estudiante::setDatosEstudiante(string _nombre, int _edad, string _registro, float _califiacion) {
	//setDatosPersona(_nombre, _edad);//si no estas haciendolo en el csntructor llama la fucnion de asignacion de datos
	Persona::setDatosPersona(_nombre, _edad);
	registro = _registro;
	calificacion = _califiacion;
	
}

float Estudiante::getCalificacion() {
	return calificacion;
}

string Estudiante::getRegistro() {
	return registro;
}

//--------------------------------------------------------------------------------------//

class Empleado : public Persona { //decir a que tenemos acceso
private:
	string puesto;
	float sueldo;
public:
	Empleado();
	~Empleado();
	void setDatosEmpleado(string, int , string , float);
	string getPuesto();
	float getSueldo();
};

Empleado::Empleado() {

}

Empleado::~Empleado() {

}

void Empleado::setDatosEmpleado(string _nombre, int _edad, string _puesto, float _sueldo) {
	setDatosPersona(_nombre, _edad);
	puesto = _puesto;
	sueldo = _sueldo;
}

string Empleado::getPuesto() {
	return puesto;
}

float Empleado::getSueldo() {
	return sueldo;
}

//----------------------------------------------------------------------//
class Universitario : public Estudiante {
private:
	string carrera;
public:
	Universitario();
	~Universitario();
	void setDatosUniversitario(string , int , string , float , string);
	string getCarrera();
};

Universitario::Universitario() {

}

Universitario::~Universitario() {

}

void Universitario::setDatosUniversitario(string _nombre, int _edad, string _registro, float _calificacion, string _carrera) {
	setDatosEstudiante(_nombre, _edad, _registro, _calificacion);
	carrera = _carrera;
}

string Universitario::getCarrera() {
	return carrera;
}

int main()
{
	/*Alumno a1("Ramiro", 18, "21300676", 78);

	a1.mostrarAlumno();
	*/

	/*Estudiante e1;

	e1.setDatosEstudiante("ramiro", 18, "21300676", 98.9);

	cout << "nombre: " << e1.getNombre() << ", edad: " << e1.getEdad() << ", registro: " << e1.getRegistro() << "y calficacion: " << e1.getCalificacion() << endl;

	Empleado emp1;

	emp1.setDatosEmpleado("Jose", 28, "ingeniero", 23560.99);

	cout << "nombre: " << emp1.getNombre() << ", edad: " << emp1.getEdad() << ", registro: " << emp1.getPuesto() << "y calficacion: " << emp1.getSueldo() << endl;

	Universitario u1;
	u1.setDatosUniversitario("pepito", 17, "ff443rd", 87.56, "desarrollo de software");
	cout << "Carrera: " << u1.getCarrera() << endl;
	cout << "Nombre: " << u1.getNombre() << endl;
	*/

	int cantidad = 0;

	cout << "Dame una camtidad: " << endl;
	cin >> cantidad;

	Estudiante* estudiante = new Estudiante[cantidad];// crear un arreglo dinamico

	string* nombre = new string[cantidad];
	int* edad = new int[cantidad];
	string* registro = new string[cantidad];
	float* calificacion = new float[cantidad];

	for (int i = 0; i < cantidad; i++) {
		cout << "dame el nombre del alumno " << i + 1 << ": " << endl;
		cin >> nombre[i];
		cout << "dame la edad del alumno " << i + 1 << ": " << endl;
		cin >> edad[i];
		cout << "dame el registro del alumno " << i + 1 << ": " << endl;
		cin >> registro[i];
		cout << "dame la califiacion del alumno " << i + 1 << ": " << endl;
		cin >> calificacion[i];
		estudiante[i].setDatosEstudiante(nombre[i], edad[i], registro[i], calificacion[i]);
	}

	for (int j = 0; j < cantidad; j++) {
		cout << estudiante[j].getNombre() << estudiante[j].getRegistro() << endl;
	}

	Estudiante e2;
   
}

