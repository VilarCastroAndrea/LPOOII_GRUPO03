using ClasesBase;
using System.Windows;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuario usuarioVendedor = new Usuario("vendedor", "vendedor", "Vendedor", 1);
        Usuario usuarioAdministrador = new Usuario("admin", "admin", "Administrador", 2);
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtbUsuario.Text != "" && txtbContraseña.Text != "")
            {
                if (txtbUsuario.Text.Equals(usuarioAdministrador.Usu_NombreUsuario) && txtbContraseña.Text.Equals(usuarioAdministrador.Usu_Password))
                {
                    MainWindow main = new MainWindow(usuarioAdministrador);
                    main.Show();
                    this.Close();
                }
                else
                {
                    if (txtbUsuario.Text.Equals(usuarioVendedor.Usu_NombreUsuario) && txtbContraseña.Text.Equals(usuarioVendedor.Usu_Password))
                    {
                        MainWindow main = new MainWindow(usuarioVendedor);
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error en el ingreso", "error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error en el ingreso", "error");
            }
        }

    }
}
