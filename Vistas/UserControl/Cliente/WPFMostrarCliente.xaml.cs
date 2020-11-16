using System;
using System.Windows;
using System.Windows.Input;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarCliente.xaml
    /// </summary>
    public partial class WPFMostrarCliente
    {


        /// <summary>
        /// Cliente para realizar el alta
        /// </summary>
        private Cliente cliente;

        /// <summary>
        /// Objeto WPFCliente para tener referencia al padre
        /// </summary>
        private WPFCliente oPadre;

        public WPFMostrarCliente(WPFCliente padre)
        {
            InitializeComponent();
            cliente = new Cliente();
            oPadre = padre;

        }

        public WPFMostrarCliente(Cliente verCliente, WPFCliente padre)
        {
            InitializeComponent();
            cliente = new Cliente();

            if (verCliente != null)
            {
                cliente = verCliente;
                CargarFormularioModificarCliente();
            }
            oPadre = padre;
        }

        /// <summary>
        /// Carga el formulario de modificar cliente
        /// con los valores del cliente.
        /// </summary>
        private void CargarFormularioModificarCliente()
        {
            txtDni.Text = cliente.Cli_DNI.ToString();
            txtApellido.Text = cliente.Cli_Apellido;
            txtNombre.Text = cliente.Cli_Nombre;
            txtTelefono.Text = cliente.Cli_Telefono;
            txtEmail.Text = cliente.Cli_Email;
        }

        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                
                ClasesBase.Cliente cli = new ClasesBase.Cliente();

                cli.Cli_DNI = cliente.Cli_DNI;
                cli.Cli_Apellido = txtApellido.Text;
                cli.Cli_Nombre = txtNombre.Text;
                cli.Cli_Telefono = txtTelefono.Text;
                cli.Cli_Email = txtEmail.Text;
                cli.Cli_Disponible = true;
                oPadre.modificarCliente(cli);
                MessageBoxResult resultado = MessageBox.Show("Se modifico la cliente con exito", "Atención");
                oPadre.ActualizarDataGrid();
                limpiarcampos();
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }
            //TrabajarClientes.ActualizarCliente(cli);

            //    MessageBox.Show("Se modifico el registro");
            //    //Se debe mostrar el formulario de alta cliente para que se actualize el grid en caso contrario sale error
            //    oPadre.ActualizarDataGrid();
            //    limpiarcampos();
            //}
        }

        private void BtnBaja_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Desea eliminar este cliente? " + txtDni.Text + ", " + txtNombre.Text + ", " +
                             txtApellido.Text + ", " + txtTelefono.Text + ", " + txtEmail.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                Cliente cli = new Cliente();
                cli.Cli_DNI = int.Parse(txtDni.Text);
                cli.Cli_Apellido = txtApellido.Text;
                cli.Cli_Nombre = txtNombre.Text;
                cli.Cli_Telefono = txtTelefono.Text;
                cli.Cli_Email = txtEmail.Text;
                cli.Cli_Disponible = false;

                try
                {
                    TrabajarClientes.eliminarClienteFisico(cli.Cli_DNI);
                }
                catch
                {
                    TrabajarClientes.EliminarCliente(cli);
                }
                oPadre.ActualizarDataGrid();
                limpiarcampos();
            }
        }

        private bool validarCampos()
        {
            if (txtDni.Text == "" || txtApellido.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || int.Parse(txtDni.Text) < 10000000 || int.Parse(txtDni.Text) > 99999999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiarcampos()
        {
            txtDni.Text = null;
            txtApellido.Text = null;
            txtNombre.Text = null;
            txtTelefono.Text = null;
            txtEmail.Text = null;
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
    }
}
