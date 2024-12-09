my_dict = {'a' , 'b'}
print(type(my_dict))

my_dict ={5:'Nicolas' , 'Apellido':'Escalante', 'Apodo':'Amor'}

print(type(my_dict))

print(my_dict['Apellido'])

print(my_dict.keys())#como se identifican 

print(my_dict.values())#los valores que tienen 

my_dict.update({'Edad': 23})#añadir

print(my_dict)

my_dict = list(my_dict)

my_dict.reverse()

print(my_dict)
