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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al seleccionar un item del ListView se muestra el UserControl correspondiente
        /// segun el indice 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listViewMenu.SelectedIndex;
           
            switch (index) {
                case 0:
                       /*Seccion Clientes*/
                       stackPanelPrincipal.Children.Clear();
                       stackPanelPrincipal.Children.Add(new Clientes());
                    
                    break;
                case 1:
                    /*Seccion Ticket*/

                    break;
                case 2:
                    /*Seccion Peliculas*/
                    stackPanelPrincipal.Children.Clear();
                    stackPanelPrincipal.Children.Add(new Peliculas());

                    break;
                case 3:
                    /*Seccion Butacas*/

                    break;
                case 4:
                    /*Seccion Proyecciones*/

                    break;
                case 5:
                    /*Seccion Usuarios*/

                    break;

                default:
                    break;
            }


        }

     

        private void ListViewItem_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            validarRolUsuario();
            mostrarDatosDeUsaurioLogin();
        }

        /// <summary>
        /// Valida el rol del usuario (Usuario Login) para ocultar o mostrar los item del menu
        /// </summary>
        private void validarRolUsuario() {
            if (UsuarioLogin.rol_Codigo == 2)
            {
                itemUsuario.Visibility = Visibility.Hidden;
                itemProyecciones.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Muestra los datos del usuario logeado en el interfaz
        /// </summary>
        private void mostrarDatosDeUsaurioLogin() {
            NombreUusario.Content = UsuarioLogin.usu_ApellidoNombre;
            if (UsuarioLogin.rol_Codigo == 1) {
                RolUusario.Content = "Administrador";
            } else { 
                  RolUusario.Content = "Vendedor";
                    }
        }
    }
}
