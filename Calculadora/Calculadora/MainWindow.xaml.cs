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

namespace Calculadora
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

        private void Button_Limpiar(object sender, RoutedEventArgs e)
        {

            numeroOperandos1 = 0;
            numeroOperandos2 = 0;
            numeroTexto1 = "";
            numeroTexto2 = "";
            resultado = "";
            operador = "";
            pantalla.Text = "";
        }

        private void Button_Numeros(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

           
            if (operador == "" && numeroTexto2 == "")
            {
                numeroTexto1 = numeroTexto1 + (string)btn.Content;

                numeroOperandos1 = double.Parse(numeroTexto1);

                MostrarPantalla(numeroTexto1);
            }
            else
            {
                numeroTexto2 = numeroTexto2 + (string)btn.Content;

                numeroOperandos2 = double.Parse(numeroTexto2);

                MostrarPantalla(numeroTexto1, numeroTexto2);

            }






        }

        private void Button_Signos(object sender, RoutedEventArgs e)
        {

            if (operador == "")
            {
                numeroOperandos1 *= -1;
                numeroTexto1 = Convert.ToString(numeroOperandos1);

                MostrarPantalla(numeroTexto1);
            }
            else
            {
                numeroOperandos2 *= -1;
                numeroTexto2 = Convert.ToString(numeroOperandos2);

                MostrarPantalla(numeroTexto1, numeroTexto2);
            }

        }

        private void Button_Punto(object sender, RoutedEventArgs e)

        {
            
                if (operador == "" && numeroTexto1 != "" && numeroOperandos1 % 1 == 0)
                {
                if (numeroTexto1 != "" && !pantalla.Text.Contains(".")){
                    numeroTexto1 = numeroTexto1 + ".";
                    MostrarPantalla(numeroTexto1);
                }
                }
                if (operador != "" && numeroTexto2 != "" && numeroOperandos2 % 1 == 0)
                {
                if ( numeroTexto1.Contains(".") && !numeroTexto2.Contains(".")) {
                    numeroTexto2 = numeroTexto2 + ".";
                    MostrarPantalla(numeroTexto1, numeroTexto2);
                    }
                }
            
            


        }

        private void Button_Operadores(object sender, RoutedEventArgs e)
        {
            Button btn1 = sender as Button;

            if (operador == "" && numeroTexto2 == "")
            {
                operador = (string)btn1.Content;

                MostrarPantalla(numeroTexto1);
            }
        }


        private void Button_Igual(object sender, RoutedEventArgs e)
        {
            if (operador != "" && numeroTexto1 != "" && numeroTexto2 != "")
            {
                switch (operador)
                {
                    case "+":
                        resultado = Convert.ToString(numeroOperandos1 + numeroOperandos2);
                        break;
                    case "-":
                        resultado = Convert.ToString(numeroOperandos1 - numeroOperandos2);
                        break;
                    case "X":
                        resultado = Convert.ToString(numeroOperandos1 * numeroOperandos2);
                        break;
                    case "/":
                        if(numeroOperandos2 == 0)
                        {

                            resultado = "No se puede divir entre 0";


                        }
                        else 
                        { 
                        resultado = Convert.ToString(numeroOperandos1 / numeroOperandos2);

                        }
                        break;
                }
            }
            else
            {
                
                resultado = "";
             
            }

            if(resultado == "" )
            {
                numeroOperandos1 = 0;
                numeroOperandos2 = 0;
                numeroTexto1 = "";
                numeroTexto2 = "";
                operador = "";
                resultado = "";
                MostrarPantalla(resultado);
            }
            else if(resultado == "No se puede divir entre 0")
            {
                MostrarPantalla(resultado);
            }
            else
            {
                MostrarPantalla(numeroTexto1, numeroTexto2);

                numeroTexto1 = resultado;
                numeroOperandos1 = double.Parse(numeroTexto1);

                numeroTexto2 = "";
                numeroOperandos2 = 0;
                operador = "";
                resultado = "";
            }
           
        }

        private void MostrarPantalla(object numero, object numero2 = null)
        {
            if (resultado == "")
            {
                if (operador == "")
                {
                    pantalla.Text = Convert.ToString(numero);
                }
                else
                {
                    pantalla.Text = "(" + Convert.ToString(numero) + ")" + operador + "( " + Convert.ToString(numero2) + ")";
                }
            }
            else
            {
                pantalla.Text = resultado;
            }

        }

        private double numeroOperandos1 = 0;
        private double numeroOperandos2 = 0;
        private string numeroTexto1 = "";
        private string numeroTexto2 = "";
        private string resultado = "";
        private string operador = "";

        private int contador = 0;

        private void Button_Raiz(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(numeroTexto1))
            {
                // Convertir el primer número y calcular su raíz cuadrada
                if (double.TryParse(numeroTexto1, out numeroOperandos1))
                {
                    resultado = Convert.ToString(Math.Sqrt(numeroOperandos1));

                    if(resultado == "NaN")
                    {
                        resultado = "No existe raiz negativa";
                        MostrarPantalla(resultado);
                    }
                    else
                    {
                        // Mostrar el resultado y actualizar las variables
                        MostrarPantalla(numeroTexto1, numeroTexto2);
                        numeroTexto1 = resultado;
                        numeroOperandos1 = double.Parse(numeroTexto1);

                        numeroTexto2 = "";
                        numeroOperandos2 = 0;
                        operador = "";
                        resultado = "";// Reiniciar el operador ya que la operación se realizó
                    }
                    
                }
                
            
            }
           

        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            if (operador == "" && numeroTexto2 == "")
            {
                numeroTexto1 = "";
                numeroOperandos1 = 0;
                MostrarPantalla(numeroTexto1);
            }
            else if (operador != "" && numeroTexto2 == "")
            {
                operador = "";
                MostrarPantalla(numeroTexto1); 
            }
            else
            {
                numeroTexto2 = "";
                numeroOperandos2 = 0;
                MostrarPantalla(numeroTexto1, numeroTexto2);
            }
        }
    }
}
