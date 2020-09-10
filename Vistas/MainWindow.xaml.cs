using ClasesBase;
using System.Windows;
using Vistas.rsc;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mostrarBotones();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mostrarBotones()
        {
            if (UsuarioLogin.rol_Codigo == 1)
            {
                btnCliente.Visibility = Visibility.Hidden;
                btnTicket.Visibility = Visibility.Hidden;
            }
            else
            {
                btnButaca.Visibility = Visibility.Hidden;
                btnUsuario.Visibility = Visibility.Hidden;
                btnProyeccion.Visibility = Visibility.Hidden;
                btnPelicula.Visibility = Visibility.Hidden;
            }
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFCliente());
        }

        private void BtnPelicula_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFPelicula());
        }

        private void BtnButaca_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFButaca());
        }
    }
}
