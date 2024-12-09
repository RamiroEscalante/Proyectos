

class unHumano:
    def __init__(self ,altura, edad, peso):
        self.altura = altura
        self.edad = edad
        self.peso = peso
        
    def comer(self):
        print(f'el humano de {self.edad} esta comiendo')


humano_1 = unHumano(1.34,23,89)

print(humano_1.altura)
print(humano_1.peso)
print(humano_1.edad)

print(f'la altura es {humano_1.altura}, la edad es {humano_1.edad} y este wey pesa {humano_1.peso}')

print(humano_1.comer())  