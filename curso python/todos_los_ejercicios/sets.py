my_set = {}
print(type(my_set))

my_set = {'python', 'java script', 'c++'}
print(type(my_set))

print(my_set)#NO HAY ORDEN Y NO SE PUEDEN REPETIR

my_set.add('c#') #añadir un elemeto
print(my_set)

my_set_0 = {'python', 'java script', 'c++'}

my_set.difference_update(my_set_0)#ve caual es diferente y ponerlo en tu primer variable 
print(my_set)