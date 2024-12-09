
try:
    print(6 + "2")
except NameError as error:
    print('error de tipo NameError')
    print(error)
except TypeError as error:
    print('error de tipo TypeError')
    print(error)
else:
    print('hola')
finally:
    print('dale like')