//Falso
//false
//0
//''
//null
//undefined
//NaN

let nombre = 'Ramiro';
let userName =  nombre || 'anonimo';
console.log(userName);

function fn1(){
    console.log('soy funcion 1');
    return true;
};  

function fn2(){
    console.log('soy funcion 2');
    return false;
}

let x = fn2() && fn1();