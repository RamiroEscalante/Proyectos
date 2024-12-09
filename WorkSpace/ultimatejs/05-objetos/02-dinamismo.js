const user = {id: 1};

user.name = 'Nicolas';

user.guardar = function (){
    console.log('Guardando los cambios...', user.name);
};

user.guardar();

console.log(user);

delete user.name;
delete user.guardar;
console.log(user);

//const user1 = Object.freeze({id: 1});//no puedes modificar nada 
const user1 = Object.seal({id: 1,});//solo puedes atualizar 
user1.name = "Ramiro";
user1.id = 2;
console.log(user1);