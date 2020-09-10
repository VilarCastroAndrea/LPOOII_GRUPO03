using ClasesBase;
using System.Collections;
using System.Windows;
using Vistas.rsc;

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
            usuarios.Add(new Usuario("admin", "123", "Ignacio Scocco", 1));
            usuarios.Add(new Usuario("vendedor", "123", "Ignacio Scocco", 2));
        }

        /// <summary>
        /// Compara los datos ingresados en el login y si son correctos guarda el usuario que ingreso y 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool encontro = false;
            foreach (Usuario usuario in usuarios)
            {
                if (txtbUsuario.Text.Equals(usuario.Usu_NombreUsuario) && txtbContraseña.Password.Equals(usuario.Usu_Password))
                {
                    guardarUsuLogin(usuario);
                    MainWindow menu = new MainWindow();
                    menu.Show();
                    Close();
                    encontro = true;
                    break;
                }
            }
            if (encontro == false)
            {
                MessageBox.Show("No se encontro el usuario " + txtbUsuario.Text, "Error");
            }
        }

        /// <summary>
        /// guarda los datos del usuario que se esta logeando
        /// </summary>
        /// <param name="usuario"></param>
        private void guardarUsuLogin(Usuario usuario)
        {
            UsuarioLogin.usu_Id = usuario.Usu_Id;
            UsuarioLogin.usu_NombreUsuario = usuario.Usu_NombreUsuario;
            UsuarioLogin.usu_Password = usuario.Usu_Password;
            UsuarioLogin.usu_ApellidoNombre = usuario.Usu_ApellidoNombre;
            UsuarioLogin.rol_Codigo = usuario.Rol_Codigo;
            UsuarioLogin.usu_Disponible = usuario.Usu_Disponible;
        }

    }
}
