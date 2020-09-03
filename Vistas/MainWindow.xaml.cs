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
            usuario.Content = logueado.Usu_NombreUsuario;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
