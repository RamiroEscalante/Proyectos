using CRUD_Biblioteca.Controladores;
using CRUD_Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD_Biblioteca
{
    /// <summary>
    /// Lógica de interacción para Tablas.xaml
    /// </summary>
    public partial class Tablas : Window
    {
        List<ClienteClass> cli;
        List<Prestamo> pre;
        List<Libro> li;

        public Tablas()
        {
            InitializeComponent();

            CargarDatos();
            
        }

        private void CargarDatos()
        {
            // Cargar cl)ientes
            cli = CliienteDAO.GetItems();
            ListaCliente.ItemsSource = cli;

            // Cargar préstamos
            pre = PrestamoDAO.GetItems();
            ListaPrestamo.ItemsSource = pre;

            // Cargar libros
            li = LibroDAO.GetItems();
            ListaLibro.ItemsSource = li;
        }

        private void ListaLibro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //li = LibroDAO.GetItems();
           //ListaLibro.ItemsSource = li;

        }

        private void ListaPrestamo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //pre = PrestamoDAO.GetItems();
            //ListaPrestamo.ItemsSource = pre;
        }

        private void ListaCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //cli = CliienteDAO.GetItems();

            //ListaCliente.ItemsSource = cli;
        }
    }
}
