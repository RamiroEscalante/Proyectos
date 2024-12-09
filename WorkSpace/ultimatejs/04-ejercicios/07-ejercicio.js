function precioCompleto(precio , impuesto = 16){
    let precioConImpeustos = precio + (precio * (impuesto / 100));
    return precioConImpeustos;
}

let resultado = precioCompleto(20, 15);
console.log(resultado);