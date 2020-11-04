using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using ClasesBase;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFCliente.xaml
    /// </summary>
    public partial class WPFCliente
    {
        MainWindow ventana;
        public WPFCliente(MainWindow main)
        {
            InitializeComponent();
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFAltaCliente());
            ventana = main;
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
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
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
            ventana.refrescarCliente();
        }

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                panelCliente.Children.Clear();

                DataRowView item = (DataRowView)Clientes.SelectedItem;
                ClasesBase.Cliente cliente = new ClasesBase.Cliente();
                cliente.Cli_DNI = Convert.ToInt32(item["DNI"]);
                cliente.Cli_Apellido = Convert.ToString(item["Apellido"]);
                cliente.Cli_Nombre = Convert.ToString(item["Nombre"]);
                cliente.Cli_Telefono = Convert.ToString(item["Telefono"]);
                cliente.Cli_Email = Convert.ToString(item["Email"]);
                panelCliente.Children.Add(new WPFMostrarCliente(cliente, this));

            }
            catch
            {
                MessageBoxResult resultado = MessageBox.Show("Debe seleccionar un cliente para modificarla", "Atención");
            }
        }
    }
}
