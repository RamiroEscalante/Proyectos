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
    /// Lógica de interacción para ActualizarLibroWindow.xaml
    /// </summary>
    public partial class ActualizarLibroWindow : Window
    {
        public ActualizarLibroWindow()
        {
            InitializeComponent();
        }

        private void ActualizarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TituloTextBox1.Text) || string.IsNullOrWhiteSpace(AutorTextBox1.Text) 
                || string.IsNullOrWhiteSpace(IdLibroTextBox1.Text) || string.IsNullOrWhiteSpace(IdGeneroTextBox1.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            string titulo = TituloTextBox1.Text;
            string autor = AutorTextBox1.Text;
            

            Regex numeroRegex = new Regex(@"^\d+$"); // Solo acepta números.

            // Validar IdLibro.
            if (!numeroRegex.IsMatch(IdLibroTextBox1.Text))
            {
                MessageBox.Show("El ID del libro debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar IdGenero.
            if (!numeroRegex.IsMatch(IdGeneroTextBox1.Text))
            {
                MessageBox.Show("El ID del género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id_libro = int.Parse(IdLibroTextBox1.Text);
            int id_genero = int.Parse(IdGeneroTextBox1.Text);

            LibroDAO.Update(id_libro,titulo,autor,id_genero);

            MessageBox.Show($"El libri {titulo} fue actualizado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);


        }
    }
}
