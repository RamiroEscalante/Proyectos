my_first_string = 'string comillas simaples'
my_second_string = "string comillas dobles"

print('este es un texto de una variable de string: ' + my_first_string + ', ' + my_second_string)

print(f'esto es un texto de una varaible string: {my_first_string}, {my_second_string}')

other_string = 'hola'

a,b,c,d = other_string #guarda la letra

print(a)

print(my_first_string.upper())#todo en mayus
print(my_first_string.lower())#todo en minusculas
print(my_first_string.capitalize())#la primer en mayus
print(len(my_first_string))#cantidad de caracteres 
print(my_first_string.find('r'))#posicion en donde se encuntra
print(my_first_string.count('l'))#cuantas hay en el string
print(my_first_string.lower().isupper())