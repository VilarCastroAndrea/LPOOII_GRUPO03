using ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario1 = new Usuario();
            usuario1.Usu_NombreUsuario = "admin";
            usuario1.Usu_Password = "123";
            usuario1.Rol_Codigo = 1;

            Usuario usuario2 = new Usuario();
            usuario2.Usu_NombreUsuario = "vendedor";
            usuario2.Usu_Password = "123";
            usuario2.Rol_Codigo = 2;

           

            if (txtUsuario.Text == usuario1.Usu_NombreUsuario && txtPassword.Password.ToString() == usuario1.Usu_Password)
            {
                UsuarioLogin.rol_Codigo = usuario1.Rol_Codigo;
                UsuarioLogin.usu_ApellidoNombre = "Ignacio Scocco";


                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Close();
            }
            else {
                if (txtUsuario.Text == usuario2.Usu_NombreUsuario && txtPassword.Password.ToString() == usuario2.Usu_Password) {

                    UsuarioLogin.rol_Codigo = usuario2.Rol_Codigo;
                    UsuarioLogin.usu_ApellidoNombre = "JuanFer Quintero";

                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                    this.Close();
                }
            }



          
        }
    }
}
