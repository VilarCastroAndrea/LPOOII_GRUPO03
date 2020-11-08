using ClasesBase;
using System;
using System.Collections;
using System.Windows;
using System.Configuration;
using System.Collections.Specialized;

namespace Vistas
{

    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public ArrayList usuarios = new ArrayList();

        public Login()
        {
            InitializeComponent();
            ReproducirEfectoSonido();
        }

        /// <summary>
        /// Reproduce un sonido al iniciar la aplicacion.
        /// </summary>
        private void ReproducirEfectoSonido()
        {
            //Obtiene el valor del app.config
            //string reproducirSonido = ConfigurationManager.AppSettings.Get("reproducirSonidos");
            //if (reproducirSonido.Equals(true.ToString()))
            //{
            //    string path = ConfigurationManager.AppSettings.Get("URLSonidoInicial");
            //    //Verificar su la url existe
            //    Uri uriSonido;
            //    if(Uri.TryCreate(path, UriKind.Absolute, out uriSonido))
            //    {
            //        //Se cambia la carga a manual sino da error.
            //        mediaElement.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            //        mediaElement.Source = uriSonido;
            //        mediaElement.Play();
            //    }
            //}

            //Obtiene valor de configuracion de UserConfig.settings
            bool reproducirSonido = Properties.UserConfig.Default.iniciarSonido;
            if (reproducirSonido)
            {
                string path = Properties.UserConfig.Default.urlSonido;
                //Verificar si la url existe
                Uri uriSonido;
                if (Uri.TryCreate(path, UriKind.Absolute, out uriSonido))
                {
                    //Se cambia la carga a manual sino da error.
                    mediaElement.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                    mediaElement.Source = uriSonido;
                    mediaElement.Play();
                }
            }
        }

        /// <summary>
        /// Compara los datos ingresados en el login y si son correctos guarda el usuario que ingreso y 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TrabajarUsuario.validarUsuario(login.Usuario,login.Contraseña) == true)
            {

               MainWindow menu = new MainWindow();
                menu.Show();
                Close();

               // MessageBox.Show("usuario " + UsuarioLogin.usu_Disponible);
            }
            else
            {
                MessageBox.Show("No se encontro el usuario " + login.Usuario, "Error");
            }
        }

        /// <summary>
        /// Abre la ventana de configuracion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            VentanaConfig vc = new VentanaConfig();
            vc.Show();
        }
    }
}
