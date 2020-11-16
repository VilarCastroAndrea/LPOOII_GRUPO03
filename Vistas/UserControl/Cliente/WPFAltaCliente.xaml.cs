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
        /// <summary>
        /// Objeto que referencia al padre
        /// </summary>
        private WPFCliente oPadre;


        public WPFAltaCliente(WPFCliente padre)
        {
            InitializeComponent();
            oPadre = padre;
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

            if (validarCampos())
            {
                if (clienteNoRepetido(txtDni.Text))
                {
                    MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtDni.Text + ", " + txtNombre.Text + ", " +
                            txtApellido.Text + ", " + txtTelefono.Text + ", " + txtEmail.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        Cliente cliente = new Cliente(Int32.Parse(txtDni.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text);
                        cliente.Cli_Disponible = true;
                        TrabajarClientes.Insert_Cliente(cliente);
                        MessageBox.Show("Cliente Guardado con exito");
                    }
                    oPadre.ActualizarDataGrid();
                    limpiarCampos();
                }
                else
                {
                    MessageBoxResult resultado = MessageBox.Show("El DNI ya se encuentra registrado.", "Atención");
                }
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }

        }

        /// <summary>
        /// Valida si el DNI ya se encuentra en la BD
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        private bool clienteNoRepetido(string dni)
        {
            return TrabajarClientes.buscarClientePorDni(dni) == null;
        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void limpiarCampos()
        {
            
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDni.Text = "0";
        }

        /// <summary>
        /// Validaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private bool validarCampos()
        {
            if (txtDni.Text == "" || int.Parse(txtDni.Text) < 10000000 || int.Parse(txtDni.Text) > 99999999 || txtNombre.Text == "" || txtNombre.Text.Length <5 || txtApellido.Text == "" || txtApellido.Text.Length < 5 || txtTelefono.Text == "" || txtTelefono.Text.Length < 5 || txtEmail.Text == "" || txtEmail.Text.Length < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Limita el ingreso de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Limita los caracteres que pueden ser agregados en el textbox
        /// 65 a 90 = A a Z
        /// 97 a 122 = a a z
        /// 164 y 165 = ñ y Ñ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewTextInputOnlyLetters(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122) || (character == 164) || (character == 165))
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Limita los caracteres que pueden ser agregados en el textbox
        /// 46 = Punto
        /// 48 a 57 = Números del 0 al 9
        /// 64 = @
        /// 65 a 90 = A a Z
        /// 97 a 122 = a a z
        /// 164 y 165 = ñ y Ñ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character == 46) || (character >= 48 && character <= 57) || (character >= 64 && character <= 90) || (character >= 97 && character <= 122) || (character == 164) || (character == 165))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
