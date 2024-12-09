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

namespace CRUD_Biblioteca
{
    /// <summary>
    /// Lógica de interacción para ActualizarVentana.xaml
    /// </summary>
    public partial class ActualizarVentana : Window
    {
        public ActualizarVentana()
        {
            InitializeComponent();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreTextBox1.Text) || string.IsNullOrWhiteSpace(ApellidoTextBox1.Text) || string.IsNullOrWhiteSpace(IdTextBox1.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nombre = NombreTextBox1.Text;
            string apellido = ApellidoTextBox1.Text;
            

            Regex nombreApellidoRegex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"); // Solo letras y espacios.
            Regex numeroRegex = new Regex(@"^\d+$"); // Solo números positivos.

            // Validar Nombre.
            if (!nombreApellidoRegex.IsMatch(NombreTextBox1.Text))
            {
                MessageBox.Show("El nombre debe contener solo letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar Apellido.
            if (!nombreApellidoRegex.IsMatch(ApellidoTextBox1.Text))
            {
                MessageBox.Show("El apellido debe contener solo letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar ID.
            if (!numeroRegex.IsMatch(IdTextBox1.Text))
            {
                MessageBox.Show("El ID debe ser un número positivo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idcliente = int.Parse(IdTextBox1.Text);

            CliienteDAO.Update(idcliente, nombre, apellido);

            MessageBox.Show($"Cliente {idcliente}, {nombre} fue actualizado", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
