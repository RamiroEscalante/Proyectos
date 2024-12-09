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
    /// Lógica de interacción para EliminarConId.xaml
    /// </summary>
    public partial class EliminarConId : Window
    {

        ClienteClass clienteid = new ClienteClass();
        public EliminarConId()
        {
            InitializeComponent();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show("Por favor, llena los campos antes de agregar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           

            Regex numeroRegex = new Regex(@"^\d+$");

            if (!numeroRegex.IsMatch(IdTextBox.Text))
            {
                MessageBox.Show("El ID de género debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = int.Parse(IdTextBox.Text);

            clienteid.ID_Cliente = id;

            CliienteDAO.Delete(clienteid);
            MessageBox.Show($"Cliente {id} fue agregado", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
