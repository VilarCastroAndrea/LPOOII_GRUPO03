using System.Data;
using System.Windows.Controls;
using ClasesBase;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFCliente.xaml
    /// </summary>
    public partial class WPFCliente
    {
        public WPFCliente()
        {
            InitializeComponent();
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFMostrarCliente());
            
        }

        private void BtnModificarCliente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFMostrarCliente());
        }

        private void BtnAltaCliente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFAltaCliente(this));
        }

        private void DgClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid) sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                Cliente clienteSeleccionado = ConvertirDRVaCliente(row_selected);
                panelCliente.Children.Clear();
                panelCliente.Children.Add(new WPFMostrarCliente(clienteSeleccionado, this));
            }

        }

        /// <summary>
        /// Convierte un objeto DataRowView a un Objeto Cliente
        /// </summary>
        /// <param name="row">DataRowView que representa la fila seleccionada en el data grid</param>
        /// <returns></returns>
        private Cliente ConvertirDRVaCliente(DataRowView row)
        {
            Cliente c = new Cliente();
            c.Cli_DNI = int.Parse(row["CLI_DNI"].ToString());
            c.Cli_Apellido = row["CLI_Apellido"].ToString();
            c.Cli_Nombre = row["CLI_Nombre"].ToString();
            c.Cli_Telefono = row["CLI_Telefono"].ToString();
            c.Cli_Email = row["CLI_Email"].ToString();
            return c;
        }

        /// <summary>
        /// Actualiza el DataGrid
        /// </summary>
        public void ActualizarDataGrid()
        {
            //Como actualizar?
        }
    }
}
