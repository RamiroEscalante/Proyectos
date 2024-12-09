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
    /// Lógica de interacción para LibroWindow.xaml
    /// </summary>
    public partial class LibroWindow : Window
    {
        Libro libro = new Libro();
        public LibroWindow()
        {
            InitializeComponent();
        }

        private void AgregarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TituloTextBox.Text) || string.IsNullOrWhiteSpace(AutorTextBox.Text) || string.IsNullOrWhiteSpace(IdGeneroTextBox.Text))
            {
                MessageBox.Show("Por favor, llena los campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string titulo = TituloTextBox.Text;
            string autor = AutorTextBox.Text;
            //int idgenero = int.Parse(IdGeneroTextBox.Text);

            Regex textoRegex = new Regex(@"^[a-zA-ZñÑ\s]+$"); // Solo letras y espacios.
            Regex numeroRegex = new Regex(@"^\d+$");          // Solo números.

            // Validar título.
            if (!textoRegex.IsMatch(TituloTextBox.Text))
            {
                MessageBox.Show("El título solo puede contener letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar autor.
            if (!textoRegex.IsMatch(AutorTextBox.Text))
            {
                MessageBox.Show("El autor solo puede contener letras y espacios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar ID de género.
            if (!numeroRegex.IsMatch(IdGeneroTextBox.Text) || !int.TryParse(IdGeneroTextBox.Text, out int idgenero))
            {
                MessageBox.Show("El ID de género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.ID_Genero = idgenero;
            LibroDAO.Add(libro);

            MessageBox.Show($"El libro {titulo} fue agregado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EliminarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            EliminarLibroWindow eliminarLibroWindow = new EliminarLibroWindow();
            eliminarLibroWindow.Show();

        }

        private void ActualizarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            ActualizarLibroWindow actualizarLibroWindow = new ActualizarLibroWindow();
            actualizarLibroWindow.Show();
        }
    }
}
