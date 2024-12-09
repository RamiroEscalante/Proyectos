#include <iostream>
using namespace std;

class Punto {
private:
    int x, y;
public:
    Punto();
    void setPunto(int , int);//dar o establcer valores a los atributos
    int getPuntoX();//dar la info
    int getPuntoY();
};

Punto::Punto() {

}

void Punto::setPunto(int _x, int _y) {
    x = _x;
    y = _y;
}

int Punto::getPuntoX() {
    return x;
}

int Punto::getPuntoY() {
    return y;
}

int main()
{
    Punto p1;
    p1.setPunto(10, 20);

    cout << "X = " << p1.getPuntoX() << endl;

    cout << "Y = " << p1.getPuntoY() << endl;
    
}
