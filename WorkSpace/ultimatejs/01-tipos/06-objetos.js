//personajes de TV
let nombre = "Tanjiro";
let anime = "Demos Slayer";
let edad = 16;

//esto es un objeto literal
let personaje = {
    nombre: "Tanjiro",//par llave-valor o propiedad
    anime: "Demon Slayer",
    edad: 16,
};
console.log(personaje);
console.log(personaje.anime);
console.log(personaje['edad']);

personaje.edad = 13;

let llave = 'edad';
personaje[llave] = 16;

delete personaje.anime;

console.log(personaje);