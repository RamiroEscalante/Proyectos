using CRUD_Biblioteca.Controladores;
using CRUD_Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_Biblioteca
{
    /// <summary>
    /// Lógica de interacción para PrestamoWindow.xaml
    /// </summary>
    public partial class PrestamoWindow : Window
    {
        Prestamo prestamo = new Prestamo();
        public PrestamoWindow()
        {
            InitializeComponent();
        }

        private void AgregarPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdLibroTextBox.Text) || string.IsNullOrWhiteSpace(IdClienteTextBox.Text) || string.IsNullOrWhiteSpace(FechaTextBox.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
           
            //DateTime fecha = DateTime.Parse(FechaTextBox.Text);

            Regex numeroRegex = new Regex(@"^\d+$"); // Solo números.
            Regex fechaRegex = new Regex(@"^\d{4}-\d{2}-\d{2}$"); // Formato de fecha: YYYY-MM-DD.

            // Validar IdLibro.
            if (!numeroRegex.IsMatch(IdLibroTextBox.Text))
            {
                MessageBox.Show("El ID del libro debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar IdCliente.
            if (!numeroRegex.IsMatch(IdClienteTextBox.Text))
            {
                MessageBox.Show("El ID del cliente debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar Fecha.
            if (!fechaRegex.IsMatch(FechaTextBox.Text) || !DateTime.TryParse(FechaTextBox.Text, out DateTime fecha))
            {
                MessageBox.Show("La fecha debe tener el formato YYYY-MM-DD.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idcliente = int.Parse(IdClienteTextBox.Text);
            int idlibro = int.Parse(IdLibroTextBox.Text);

            prestamo.ID_Libro = idlibro;
            prestamo.ID_Cliente = idcliente;
            prestamo.Fecha = fecha;
            PrestamoDAO.Add(prestamo);

            MessageBox.Show($"El libro {idlibro} se presto al cliente {idcliente} fue agregado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        private void EliminarPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            EliminarPrestamoWindow eliminarPrestamo = new EliminarPrestamoWindow();
            eliminarPrestamo.Show();

        }

        private void ActualizarPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPrestamorWindow actualizarPrestamo = new ActualizarPrestamorWindow();
            actualizarPrestamo.Show();

        }
    }
}
