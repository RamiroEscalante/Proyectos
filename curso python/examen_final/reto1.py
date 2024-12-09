lista = [5,7,2,7,9,4,8]

numero_mayor = lista[0]
penultimmo = lista[0]

for n in lista:
    if(numero_mayor <= n):
        numero_mayor = n
        continue
    
for n in lista:
    if(penultimmo < n):
        if(n != numero_mayor):
            penultimmo = n
            continue
    continue
        
        
print(penultimmo)        