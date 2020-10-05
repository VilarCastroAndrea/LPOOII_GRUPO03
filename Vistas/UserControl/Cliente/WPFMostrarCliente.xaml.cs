using System;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarCliente.xaml
    /// </summary>
    public partial class WPFMostrarCliente
    {
        ClasesBase.Cliente cliente;
        public WPFMostrarCliente()
        {
            cliente = new ClasesBase.Cliente();
            InitializeComponent();
        }

        public WPFMostrarCliente(ClasesBase.Cliente verCliente, WPFCliente padre)
        {
            InitializeComponent();
            cliente = new ClasesBase.Cliente();
            if (verCliente != null)
            {
                cliente = verCliente;
                CargarFormularioModificarCliente();

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
