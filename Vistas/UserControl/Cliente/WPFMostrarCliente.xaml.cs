using System;
using System.Windows;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarCliente.xaml
    /// </summary>
    public partial class WPFMostrarCliente
    {
        WPFCliente proyeccionPadre;
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
            proyeccionPadre = padre;
        }

        public WPFMostrarCliente(Cliente verCliente, WPFCliente padre)
        {
            InitializeComponent();
            cliente = new Cliente();

            if (verCliente != null)
            {
                cliente = verCliente;
                CargarFormularioModificarCliente();
                oPadre = padre;
            }
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

                ClasesBase.Cliente cliente = new ClasesBase.Cliente();


                Cliente cli = new Cliente();
                cli.Cli_DNI = int.Parse(txtDni.Text);
                cli.Cli_Apellido = txtApellido.Text;
                cli.Cli_Nombre = txtNombre.Text;
                cli.Cli_Telefono = txtTelefono.Text;
                cli.Cli_Email = txtEmail.Text;
                cli.Cli_Disponible = true;
                proyeccionPadre.modificarCliente(cliente);
                MessageBoxResult resultado = MessageBox.Show("Se modifico la pelicula con exito", "Atención");
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
                if (txtDni.Text == "" || txtApellido.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
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

    }
}
