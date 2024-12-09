my_tupla = (53, 'perro', 7.4 , True)

print(type(my_tupla))

print(my_tupla[1])

print(my_tupla.count(53))
print(my_tupla.index(True))#te va a decir donde esta

my_tupla = list(my_tupla)#convertir en otro tipo 
my_tupla.pop()

print(my_tupla)

print(type(my_tupla))

my_tupla = tuple(my_tupla)#convertir en otro tipo 

print(type(my_tupla))