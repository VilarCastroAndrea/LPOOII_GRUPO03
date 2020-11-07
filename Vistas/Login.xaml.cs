using ClasesBase;
using System.Collections;
using System.Windows;

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

    }
}
