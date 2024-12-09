using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Biblioteca.Modelos
{
    class Libro
    {
        public int ID_Libro { get; set; }
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int ID_Genero { get; set; }
    }
}
