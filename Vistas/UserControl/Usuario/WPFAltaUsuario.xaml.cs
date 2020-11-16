using System;
using System.Collections.Generic;
using System.Data;
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
        string frmIncompleto = "";
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
                DataTable usuarioNomUsu = TrabajarUsuario.buscarUsuario1(txtNombreUsuario.Text);
                if (usuarioNomUsu.Rows.Count == 0)
                {
                    String passwordEncript = Encryp.Encriptar(txtPassword.Text);
                    padre.altaUsuario(new ClasesBase.Usuario(txtNombreUsuario.Text, passwordEncript, txtApellidoNombre.Text, int.Parse(cmbRol.SelectedValue.ToString()), true));
                    limpiarCampos();
                    padre.actualizarVentana();

                    MessageBoxResult resultado = MessageBox.Show("Se agrego usuario con exito", "Atención");
                }
                else
                {
                    MessageBoxResult resultado = MessageBox.Show("El Nombre de usuario ingresado ya existe", "Atención");
                }


            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto " + frmIncompleto, "Atención");
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
            bool res = false;
            if (txtApellidoNombre.Text == "" || txtNombreUsuario.Text == "" || txtPassword.Text == "" || cmbRol.Text == "")
            {
                this.frmIncompleto = "Debe Completar todos los campos";
                res = false;
            }
            else
            {
                if (txtApellidoNombre.Text.Length < 5 || txtNombreUsuario.Text.Length < 5 || txtPassword.Text.Length < 5)
                {
                    this.frmIncompleto = "todos los campos deben tener al menos 5 caracteres";
                }
                else
                {
                    res = true;
                }
            }
            return res;

        }

        private void PreviewTextInputOnlyLetters(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }

        private void PreviewTextInputOnlyLetters(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }

       
    }
}
