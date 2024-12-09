let c = 0;
function getbyIdx(arr,idx){

    /*
    if(idx < 0 || idx >= arr.length){
        return false;
    }
    else{
       return arr[idx];
    };
    */

    //logica larga cuando escribi mal length

    for(let contar of arr){
        c++;
    }

    if(idx < 0 || idx >= c){
        return false;
    }else{
        return arr[idx];
    }
}

let resultado = getbyIdx([1,2],0);
console.log(resultado);