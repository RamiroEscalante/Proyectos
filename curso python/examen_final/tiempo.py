def militime(day = 0, hour = 0, minutes = 0, seconds = 0):
    hour =+ day * 24
    minutes =+ hour * 60
    seconds =+ minutes *60
    
    tiempo = seconds * 1000
    
    return tiempo

res = militime(12,10, 33,134)
print(res)
