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

namespace CRUD_Biblioteca
{
    /// <summary>
    /// Lógica de interacción para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {

        ClienteClass clienteClass = new ClienteClass();
        public ClienteWindow()
        {
            InitializeComponent();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) || string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string nombre = NombreTextBox.Text;
            string apellido = ApellidoTextBox.Text;

            Regex textoRegex = new Regex(@"^[a-zA-ZñÑ\s]+$");

            // Validar nombre.
            if (!textoRegex.IsMatch(NombreTextBox.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar apellido.
            if (!textoRegex.IsMatch(ApellidoTextBox.Text))
            {
                MessageBox.Show("El apellido solo puede contener letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            clienteClass.Apellido = apellido;
            clienteClass.Nombre = nombre;

            CliienteDAO.Add(clienteClass);
            MessageBox.Show($"Cliente {nombre} {apellido} fue agregado", "Agregar", MessageBoxButton.OK,MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            EliminarConId eliminarWindow = new EliminarConId();
            eliminarWindow.Show();
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            ActualizarVentana actualizar = new ActualizarVentana();
            actualizar.Show();
        }
    }
}
