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
    /// Lógica de interacción para GeneroWindow.xaml
    /// </summary>
    public partial class GeneroWindow : Window
    {
        Genero genero = new Genero();
        public GeneroWindow()
        {
            InitializeComponent();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(NombreGeneroTextBox.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nombre = NombreGeneroTextBox.Text;

            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            if (!regex.IsMatch(nombre))
            {
                MessageBox.Show("El campo solo debe contener letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            genero.Nombre = nombre;

            GeneroDAO.Add(genero);
            MessageBox.Show($"El genero {nombre} fue agregado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            EliGeneroWindow eliGeneroWindow = new EliGeneroWindow();
            eliGeneroWindow.Show();

        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            ActualizarGeneroWindow actualizarGeneroWindow = new ActualizarGeneroWindow();
            actualizarGeneroWindow.Show();
        }
    }
}
