using CRUD_Biblioteca.Controladores;
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
    /// Lógica de interacción para ActualizarPrestamorWindow.xaml
    /// </summary>
    public partial class ActualizarPrestamorWindow : Window
    {
        public ActualizarPrestamorWindow()
        {
            InitializeComponent();
        }

        private void ActualizarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdPrestamoTextBox1.Text) || string.IsNullOrWhiteSpace(IdClienteTextBox1.Text) || string.IsNullOrWhiteSpace(IdLibroTextBox1.Text) || string.IsNullOrWhiteSpace(FechaTextBox1.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           

            Regex numeroRegex = new Regex(@"^\d+$"); // Solo números positivos.
            Regex fechaRegex = new Regex(@"^\d{4}-\d{2}-\d{2}$"); // Formato de fecha: YYYY-MM-DD.

            // Validar IdPrestamo.
            if (!numeroRegex.IsMatch(IdPrestamoTextBox1.Text))
            {
                MessageBox.Show("El ID del préstamo debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar IdCliente.
            if (!numeroRegex.IsMatch(IdClienteTextBox1.Text))
            {
                MessageBox.Show("El ID del cliente debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar IdLibro.
            if (!numeroRegex.IsMatch(IdLibroTextBox1.Text))
            {
                MessageBox.Show("El ID del libro debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar Fecha.
            if (!fechaRegex.IsMatch(FechaTextBox1.Text) || !DateTime.TryParse(FechaTextBox1.Text, out DateTime fecha))
            {
                MessageBox.Show("La fecha debe tener el formato YYYY-MM-DD y ser válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idprestamo = int.Parse(IdPrestamoTextBox1.Text);
            int idcliente = int.Parse(IdClienteTextBox1.Text);
            int idlibro = int.Parse(IdLibroTextBox1.Text);
            //DateTime fecha = DateTime.Parse(FechaTextBox1.Text);

            PrestamoDAO.Update(idprestamo, idcliente, idlibro, fecha);

            MessageBox.Show($"El prestamo {idprestamo} se actualizo", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
