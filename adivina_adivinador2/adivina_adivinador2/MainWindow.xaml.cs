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

namespace adivina_adivinador2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool caputura = false;
        private StringBuilder repuesta = new StringBuilder();
        private string TextoSecreto = "Adivina adivinador que tiene el rey en la panza";
        private string[] mensajes = { "Tu pregunta es de bajo nivel para el genio", "Te estas acercando solo te hace falta pensar",
        "JAJAJAJ, El genio lo hizo de nuevo", "Estas seguro que sabes hacer la pregunta", "AHGGG, ya me estoy enojando"};

        int contador = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            if(!caputura && !(RequestTextBox.Text.Contains(":")))
            {
                if(contador >= mensajes.Length) {
                    contador = 0;
                    Salida.Text = mensajes[0];
                }
                else
                {
                    Salida.Text = mensajes[contador];
                    contador++;
                }

            }
            else
            {
                Salida.Text = repuesta.ToString();
            }
        }

        private void RequestTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Text == ".")
            {
                caputura = !caputura;
                if(caputura)
                {
                    repuesta.Clear();
                }

                e.Handled = true;
                return;
            }

            if (caputura)
            {
                if(e.Text == "_")
                {
                    repuesta.Append(" ");
                }
                else
                {
                    repuesta.Append(e.Text);
                }

                StringBuilder secreto = new StringBuilder();
                int inciceTexto = 0;

                for(int i = 0; i < repuesta.Length; i++)
                {
                    secreto.Append(TextoSecreto[inciceTexto]);
                    inciceTexto++;
                    if(inciceTexto >= TextoSecreto.Length)
                    {
                        inciceTexto = 0;
                    }
                }

                RequestTextBox.Text = secreto.ToString();
                RequestTextBox.CaretIndex = RequestTextBox.Text.Length;
                e.Handled = true;   
            }
        }

    }
}