using ClasesBase;
using System;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarCliente.xaml
    /// </summary>
    public partial class WPFMostrarCliente
    {
        public WPFMostrarCliente()
        {
            InitializeComponent();
        }

        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_DNI = Convert.ToInt32(txtDni.Text);
            cliente.Cli_Email = txtEmail.Text;
            cliente.Cli_Disponible = true;
            cliente.Cli_Telefono = txtTelefono.Text;

            TrabajarCliente.modificarCliente(cliente);

            limpiarCampos();

        }


        private void limpiarCampos() {
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtDni.Text = null;
            txtEmail.Text = null;
            txtTelefono.Text = null;
        }
    }
}
