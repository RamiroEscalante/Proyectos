using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD_Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Cliente(object sender, RoutedEventArgs e)
        {
            ClienteWindow clienteWindow = new ClienteWindow();
            clienteWindow.Show();
        }

        private void Button_Click_Genero(object sender, RoutedEventArgs e)
        {
            GeneroWindow generoWindow = new GeneroWindow();
            generoWindow.Show();
        }

        private void Button_Click_Libro(object sender, RoutedEventArgs e)
        {
            LibroWindow libroWindow = new LibroWindow();
            libroWindow.Show();
        }

        private void Button_Click_Prestamo(object sender, RoutedEventArgs e)
        {
            PrestamoWindow prestamoWindow = new PrestamoWindow();
            prestamoWindow.Show();
        }

        private void Button_Click_Tablas(object sender, RoutedEventArgs e)
        {
            Tablas tablas = new Tablas();
            tablas.Show();
        }
    }
}