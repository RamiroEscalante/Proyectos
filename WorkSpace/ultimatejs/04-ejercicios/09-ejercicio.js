let array = [
    [1, {name: 'ramiro'}],
    [2, {name: 'olver'}],
    [3, {name: 'pepe'}],
];


function toCollection(arr){
    let collection = [];
    for (i in arr){
        let elemento = arr[i];
        collection[i] = elemento[1];
        collection[i].id = elemento[0];
    }

    return collection;
}

let resulado = toCollection(array);
console.log(resulado);