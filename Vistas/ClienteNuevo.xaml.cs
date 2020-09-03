using ClasesBase;
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
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ClienteNuevo.xaml
    /// </summary>
    public partial class ClienteNuevo : Window
    {
        public ClienteNuevo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_DNI =  Convert.ToInt32(txtDni.Text);
            cliente.Cli_Email = txtEmail.Text;
            cliente.Cli_Telefono = txtTelefono.Text;
            cliente.Cli_Disponible = true;

            MessageBoxResult messageBoxResult = MessageBox.Show("Estas seguro?", "Agregar cliente", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes) {
                MessageBox.Show(
                     "Cliente\n" +
                     "Apellido y Nombre : " + cliente.Cli_Apellido + ", " + cliente.Cli_Nombre + "\n" +
                     "D.N.I :" + cliente.Cli_DNI + "\n" +
                     "E-mail : " + cliente.Cli_Email + "\n" +
                     "telefono : " + cliente.Cli_Telefono + "\n" +
                     "disponible : " + cliente.Cli_Disponible
                    );

                limpiarCampos();
            }



        }

        /// <summary>
        /// Este metodo limpia los campos de la ventana de alta de cliente
        /// </summary>
        private void limpiarCampos() {
            txtApellido.Text = null;
            txtDni.Text = null;
            txtEmail.Text = null;
            txtTelefono.Text = null;
            txtNombre.Text = null;
        }
    }
}
