using ClasesBase;
using System.Windows;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Usuario logueado)
        {
            InitializeComponent();
            mostrarBotones(logueado);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mostrarBotones(Usuario usuario)
        {
            if (usuario.Rol_Codigo == 1)
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
