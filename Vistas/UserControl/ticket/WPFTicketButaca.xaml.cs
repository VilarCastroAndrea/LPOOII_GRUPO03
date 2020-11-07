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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;
namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicketButaca.xaml
    /// </summary>
    public partial class WPFTicketButaca 
    {
        Ticket ticket1 = new Ticket(); 
        public WPFTicketButaca(Ticket ticket)
        {
            InitializeComponent();
            ticket1 = ticket;
            txtProyeccion.Text = Convert.ToString(ticket.Proy_Codigo);
            txtCliente.Text = Convert.ToString(ticket.Cli_DNI);
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            WPFTicketImpresion impresion = new WPFTicketImpresion(ticket1);
            impresion.Show();
        }
    }
}
