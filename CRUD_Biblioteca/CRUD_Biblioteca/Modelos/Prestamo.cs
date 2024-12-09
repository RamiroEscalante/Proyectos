using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Biblioteca.Modelos
{
    internal class Prestamo
    {
        public int ID_Prestamo { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Libro { get; set; }
        public DateTime Fecha   { get; set; }
    }
}
