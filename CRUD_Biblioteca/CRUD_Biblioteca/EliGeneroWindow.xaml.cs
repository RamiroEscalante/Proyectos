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
    /// Lógica de interacción para EliGeneroWindow.xaml
    /// </summary>
    public partial class EliGeneroWindow : Window
    {
        Genero genero = new Genero();
        public EliGeneroWindow()
        {
            InitializeComponent();
        }

        private void EliminarGeneroButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdGeneroTextBox.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            

            Regex numeroRegex = new Regex(@"^\d+$");

            if (!numeroRegex.IsMatch(IdGeneroTextBox.Text))
            {
                MessageBox.Show("El ID de género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = int.Parse(IdGeneroTextBox.Text);

            genero.ID_Genero = id;
            GeneroDAO.Delete(genero);

            MessageBox.Show($"El genero {id} fue agregado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
