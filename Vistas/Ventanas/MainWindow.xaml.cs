using ClasesBase;
using System.Windows;
using Vistas.UserControl.Proyeccion;
using Vistas.UserControl.Usuario;
using Vistas.UserControl.ticket;
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

        public void refrescarCliente()
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFCliente(this));
        }

        public void refrescarPelicula()
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFPelicula(this));
        }

        public void refrescarUsuario()
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFUsuario(this));
        }

        /// <summary>
        /// Muestra los botones segun el usuario que se encuentra logeado
        /// </summary>
        private void mostrarBotones()
        {
            if (UsuarioLogin.rol_Codigo == 1)
            {
                btnCliente.Visibility = Visibility.Hidden;
                btnTicket.Visibility = Visibility.Hidden;
                lblCliente.Visibility = Visibility.Hidden;
                lblTicket.Visibility = Visibility.Hidden;
            }
            else
            {
                btnUsuario.Visibility = Visibility.Hidden;
                btnProyeccion.Visibility = Visibility.Hidden;
                btnPelicula.Visibility = Visibility.Hidden;
                lblUsuario.Visibility = Visibility.Hidden;
                lblProyeccion.Visibility = Visibility.Hidden;
                lblPelicula.Visibility = Visibility.Hidden;
            }
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFCliente(this));
        }

        private void BtnPelicula_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFPelicula(this));
        }




        /// <summary>
        /// Boton para deslogear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            deslogearUsuario();
            Close();
            login.Show();
        }


        /// <summary>
        /// Borra los datos que tiene guardado el usuario que se logeo
        /// </summary>
        private void deslogearUsuario()
        {
            UsuarioLogin.rol_Codigo = -1;
            UsuarioLogin.usu_ApellidoNombre = null;
            UsuarioLogin.usu_Id = -1;
            UsuarioLogin.usu_NombreUsuario = null;
            UsuarioLogin.usu_Password = null;
        }

        private void BtnProyeccion_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFProyeccion());
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFUsuario(this));
        }

        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFTicket(this));
        }

        public void refrescarTicket()
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(new WPFTicket(this));
        }
    }
}
