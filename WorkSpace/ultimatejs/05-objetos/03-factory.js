

function crearUsario(name, email){
    return {
        email,//se puede hacer asi
        name: name,
        activo: true,
        recuperarClave: function (){
            console.log('Recuoernado clave...');
        },
    };
}

let user1 = crearUsario('Ramiro', 'ramiro@holamundo.io');
let user2 = crearUsario('Jose', 'jose@holamundo.io');

console.log(user1,user2);