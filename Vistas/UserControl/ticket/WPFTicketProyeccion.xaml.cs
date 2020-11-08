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
using ClasesBase;

namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicketProyeccion.xaml
    /// </summary>
    public partial class WPFTicketProyeccion 
    {
        WPFTicket ticketPadre = new WPFTicket();
        public WPFTicketProyeccion()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView item = (DataRowView)listaProyeccion.SelectedItem;
            ClasesBase.Proyeccion proyeccion = new ClasesBase.Proyeccion();
            ticketPadre.cargarProyeccion(Convert.ToInt32(item["Codigo"]));
            txtNombrePelicula.Text = Convert.ToString(item["Titulo de la Pelicula"]);
            txtFecha.Text = Convert.ToString(item["Fecha"]);
            txtHora.Text = Convert.ToString(item["Hora"]);
            txtSala.Text = Convert.ToString(item["Descripcion de Sala"]);
            
            
        }
        
    }
}
