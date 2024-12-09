numeros = input('Dame una serie de numeros separados por espacios')

lista_numeros = [ float(numero) for numero in numeros.split()]

promedio = 0
suma = 0

for n in lista_numeros:
    suma += n
    
promedio = suma / len(lista_numeros)

print(promedio)