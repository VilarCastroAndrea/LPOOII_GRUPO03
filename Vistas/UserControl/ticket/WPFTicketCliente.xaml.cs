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

namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicketCliente.xaml
    /// </summary>
    public partial class WPFTicketCliente 
    {
        public WPFTicketCliente()
        {
            InitializeComponent();
        }

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView item = (DataRowView)listaClienteTicket.SelectedItem;
            ClasesBase.Cliente cliente = new ClasesBase.Cliente();
            txtDNI.Text = Convert.ToString(item["DNI"]);
            txtApellido.Text = Convert.ToString(item["Apellido"]);
            txtNombre.Text = Convert.ToString(item["Nombre"]);
            WPFTicket ticketPadre = new WPFTicket();
            ticketPadre.cargarCliente(Convert.ToInt32(item["DNI"]));
        }
    }
}
