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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas.UserControl.Usuario
{
    /// <summary>
    /// Lógica de interacción para WPFAltaUsuario.xaml
    /// </summary>
    public partial class WPFAltaUsuario 
    {
        public WPFAltaUsuario()
        {
            InitializeComponent();
            cargarComboRol();
        }

        private void BtnAltaUsuario_Click(object sender, RoutedEventArgs e)
        {
            ClasesBase.Usuario usuario = new ClasesBase.Usuario();
            usuario.Usu_ApellidoNombre = txtApellidoNombre.Text;
            usuario.Usu_NombreUsuario = txtNombreUsuario.Text;
            usuario.Usu_Password = txtPassword.Text;
            usuario.Usu_Disponible = true;
            usuario.Rol_Codigo = 1;

            TrabajarUsuario.altaUsuario(usuario);

            MessageBox.Show("Usuario agregado correctamente");
        }

        private void cargarComboRol()
        {
            cmbRol.ItemsSource = TrabajarRol.listarRoles();
            cmbRol.SelectedValuePath = "Rol_Codigo";
            cmbRol.DisplayMemberPath = "Rol_Descripcion";
        }
    }
}
