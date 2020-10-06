using System;
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

        public WPFMostrarCliente()
        {
            cliente = new Cliente();
            InitializeComponent();
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
    }
}
