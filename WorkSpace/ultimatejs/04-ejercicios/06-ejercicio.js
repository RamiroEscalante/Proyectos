let array = [2, 5, 7, 15, -5, -100, 55];

function cauntosPositivos(arr){
    let c = 0;
    for(let numero in arr){
        if(arr[numero] > 0){
            c++;
        }
    }
    

    let cantidad = 0;
    for(let num of arr){
        if(num > 0){
            cantidad++;
        }
    }

    return cantidad;
}



let resultado = cauntosPositivos(array);
console.log(resultado);