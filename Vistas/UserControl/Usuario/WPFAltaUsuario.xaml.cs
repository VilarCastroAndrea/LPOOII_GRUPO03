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

        WPFUsuario padre;

        public WPFAltaUsuario(WPFUsuario formularioPadre)
        {
            InitializeComponent();
            padre = formularioPadre;
            cargarComboRol();

        }

        //public WPFAltaUsuario()
        //{
        //    InitializeComponent();
        //    cargarComboRol();
        //}

        //private void BtnAltaUsuario_Click(object sender, RoutedEventArgs e)
        //{
        //    ClasesBase.Usuario usuario = new ClasesBase.Usuario();
        //    usuario.Usu_ApellidoNombre = txtApellidoNombre.Text;
        //    usuario.Usu_NombreUsuario = txtNombreUsuario.Text;
        //    usuario.Usu_Password = txtPassword.Text;
        //    usuario.Usu_Disponible = true;
        //    usuario.Rol_Codigo = int.Parse(cmbRol.SelectedValue.ToString());

        //    TrabajarUsuario.altaUsuario(usuario);         
        //    MessageBox.Show("Usuario agregado correctamente");
        //    limpiarCampos();
        //}

        private void BtnAltaUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                try
                {
                    String passwordEncript = Encryp.Encriptar(txtPassword.Text);
                    padre.altaUsuario(new ClasesBase.Usuario(txtNombreUsuario.Text, passwordEncript, txtApellidoNombre.Text, int.Parse(cmbRol.SelectedValue.ToString()),true));

                    MessageBoxResult resultado = MessageBox.Show("Se agrego usuario con exito", "Atención");
                    //limpiarCampos();
                }
                catch (Exception error)
                {
                    MessageBoxResult resultado = MessageBox.Show("Error al realizar alta de Usuario ", "Atención");
                }

            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }

        }

        private void cargarComboRol()
        {
            cmbRol.ItemsSource = TrabajarRol.listarRoles();
            cmbRol.SelectedValuePath = "Rol_Codigo";
            cmbRol.DisplayMemberPath = "Rol_Descripcion";
        }

        private void limpiarCampos()
        {
            txtApellidoNombre.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
        }
        private bool validarCampos()
        {
            if (txtApellidoNombre.Text == "" || txtNombreUsuario.Text == "" || txtPassword.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
