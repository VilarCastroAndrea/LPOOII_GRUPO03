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
    /// Lógica de interacción para WPFAltaTicket.xaml
    /// </summary>
    public partial class WPFAltaTicket 
    {
        Ticket ticket = new Ticket();
        public WPFAltaTicket()
        {
            InitializeComponent();
            cargarComboClientes();
            cargarComboButaca();
            cargarComboProyecciones();
        }

        private void cargarComboClientes()
        {
            cmbClientes.ItemsSource = TrabajarClientes.listarClientes();
            cmbClientes.SelectedValuePath = "Cli_DNI";
            cmbClientes.DisplayMemberPath = "Cli_Apellido";
        }

        private void cargarComboProyecciones()
        {
            cmbProyecciones.ItemsSource = TrabajarProyeccion.traerProyecciones();
            cmbProyecciones.SelectedValuePath = "Proy_Codigo";
            cmbProyecciones.DisplayMemberPath = "Proy_Codigo";
        }

        private void cargarComboButaca()
        {
            cmbButaca.ItemsSource = TrabajarButaca.traerButacas();
            cmbButaca.SelectedValuePath = "But_Id";
            cmbButaca.DisplayMemberPath = "But_Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ticket.Proy_Codigo = int.Parse(cmbProyecciones.SelectedValue.ToString());
            ticket.Cli_DNI = int.Parse(cmbClientes.SelectedValue.ToString());
            ticket.But_Id = int.Parse(cmbButaca.SelectedValue.ToString());
            ticket.Tick_FechaVenta = DateTime.Now;
            ticket.Tick_Estado = true;
            ticket.Usu_Id = 2;

            panelButacas.Children.Clear();
            panelButacas.Children.Add(new WPFImpresionTicket(ticket));
        }

        private void GroupBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
