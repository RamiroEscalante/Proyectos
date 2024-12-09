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
    /// Lógica de interacción para ActualizarGeneroWindow.xaml
    /// </summary>
    public partial class ActualizarGeneroWindow : Window
    {
        public ActualizarGeneroWindow()
        {
            InitializeComponent();
        }

        private void ActualizarGenero_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreGeneroTextBox1.Text) || string.IsNullOrWhiteSpace(IdGeneroTextBox1.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            string nombre = NombreGeneroTextBox1.Text;

            Regex numeroRegex = new Regex(@"^\d+$"); // Solo acepta números.

            // Validar IdGenero.
            if (!numeroRegex.IsMatch(IdGeneroTextBox1.Text))
            {
                MessageBox.Show("El ID del género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = int.Parse(IdGeneroTextBox1.Text);

            GeneroDAO.Update(id, nombre);

            MessageBox.Show($"Cliente {id}, {nombre} fue actualizado", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
