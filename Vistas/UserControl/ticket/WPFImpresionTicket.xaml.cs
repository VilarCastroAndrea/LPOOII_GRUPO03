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
    /// Lógica de interacción para WPFImpresionTicket.xaml
    /// </summary>
    public partial class WPFImpresionTicket 
    {
        Ticket ticket1 = new Ticket();
        public WPFImpresionTicket(Ticket ticket)
        {
            InitializeComponent();
            ticket1 = ticket;
            //lblFecha.ToString = ticket.Tick_FechaVenta;
            //lblDNI = ticket.Cli_DNI;
            
        }


    }
}
