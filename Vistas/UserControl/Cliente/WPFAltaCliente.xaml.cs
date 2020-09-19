using ClasesBase;
using System;
using System.Windows;
using System.Windows.Input;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFAltaCliente.xaml
    /// </summary>
    public partial class WPFAltaCliente
    {
        public WPFAltaCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Camptura de datos 
        /// </summary>
        /// <param name="cliente"></param>
        private void capturarValores(Cliente cliente)
        {
            cliente.Cli_DNI = Int32.Parse(txtDni.Text);
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Telefono = txtTelefono.Text;
            cliente.Cli_Email = txtEmail.Text;
            cliente.Cli_Disponible = true;
        }

        /// <summary>
        /// Alta de cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtDni.Text + ", " + txtNombre.Text + ", " +
                             txtApellido.Text + ", " + txtTelefono.Text + ", " + txtEmail.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Cliente Guardado con exito");
                    Cliente cliente = new Cliente(Int32.Parse(txtDni.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text);
                }
                limpiarCampos();
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }

        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        /// <summary>
        /// Validaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private bool validarCampos()
        {
            if (txtDni.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
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
