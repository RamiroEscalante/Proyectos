def bizzbuzz():
    for numeros in range(101):
        if  numeros % 3 == 0 and numeros % 5 == 0:
            print('fizzbuzz')
        elif numeros % 3 == 0:
            print('buzz')
        elif numeros % 5 == 0:
            print('buzz')
        else:
            print(numeros)
    
bizzbuzz()

    