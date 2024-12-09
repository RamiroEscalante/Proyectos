let longitud = 25;

function crearArray(n){
    let array = [];

    if(n < 0){
        return [];
    }
    else{
    for(let i = 0; i < n; i++){
        array[i] = i + 1; 
    }
    return array;
}

    
}

let resultado = crearArray(longitud);
console.log(resultado);