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
    /// Lógica de interacción para EliminarPrestamoWindow.xaml
    /// </summary>
    public partial class EliminarPrestamoWindow : Window
    {
        Prestamo prestamo = new Prestamo();
        public EliminarPrestamoWindow()
        {
            InitializeComponent();
        }

        private void EliminaPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdPrestamoTextBox.Text))
            {
                MessageBox.Show("Por favor, llena ambos campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            

            Regex numeroRegex = new Regex(@"^\d+$");

            if (!numeroRegex.IsMatch(IdPrestamoTextBox.Text))
            {
                MessageBox.Show("El ID de género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = int.Parse(IdPrestamoTextBox.Text);

            prestamo.ID_Prestamo = id;

            PrestamoDAO.Delete(prestamo);
            MessageBox.Show($"El prestamo {id} fue eliminado", "Agregar", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
