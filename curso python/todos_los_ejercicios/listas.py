my_list = ['python' , 53 , False,'hola mundo']

print(type(my_list))

print(my_list)
print(my_list[1])
print(my_list[-1])#para llamarlo al reves

my_list.append(53) #añadir mas elementos
print(my_list)
my_list.insert(3, 'suscribete')#insertar en posicion especifica
print(my_list)
my_list.remove('hola mundo')#remover algo
print(my_list)
print(my_list.pop(2))#elimina el de la posicion asiganada y guarda lo que quito
print(my_list)


print(my_list.count(53))#cuantos hay iguales

my_list.reverse()#ponerla al reves
print(my_list)

my_list.clear()#elminar todos

print(my_list)