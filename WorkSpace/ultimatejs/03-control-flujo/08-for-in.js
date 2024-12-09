let user = {
    id: 1,
    name: 'Ramiro',
    age: '18',
};

for (let prop in user){
    console.log(prop, user[prop]);
}

let animales = ['perro', 'gato', 'dragon'];

for(let animal in animales){
    console.log(animales[animal]);
}