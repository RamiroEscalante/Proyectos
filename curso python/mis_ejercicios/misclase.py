
class unPerro:
    def __init__(self, apodo, edad) -> None:
        self.apodo = apodo
        self.edad = edad
    
    def comer(self):
        print('como croquetas')
        
el_primer_perro = unPerro('vic', 5)

print(el_primer_perro.comer())
print(f'el nombre del perro es {el_primer_perro.apodo}')