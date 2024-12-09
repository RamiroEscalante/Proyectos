let array = [{
    id: 1,
    nombre: 'Ramiro',
},{
    id: 2,
    nombre: 'Oliver',
},{
    id: 3,
    nombre: 'Pepe',
}];
    


function toPairs(arr){
    let Pairs = [];
    for(i in arr){
        let elemento = arr[i];
        Pairs[i] = [elemento.id, elemento]//meter un arreglo dentro de otro 
    }

    return Pairs;
}

let resultado = toPairs(array);
console.log(resultado);