using ClasesBase;
using System.Collections.Generic;
using System.Windows;


namespace Vistas.UserControl.Proyeccion
{
    /// <summary>
    /// Lógica de interacción para WPFProyeccion.xaml
    /// </summary>
    public partial class WPFProyeccion
    {
        /// <summary>
        /// simulacion de bd
        /// </summary>
        //private List<ClasesBase.Proyeccion> listaDeProyecciones;
        //private bool selecciono = false;
        public int index = 0;
        /// <summary>
        /// al iniciar se inicializara una lista de proyecciones y se cargara en el data grid view
        /// </summary>
        public WPFProyeccion()
        {
            InitializeComponent();
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFAltaProyeccion(this));
            //listaDeProyecciones = new List<ClasesBase.Proyeccion>();
            dgvListaDeProyecciones.ItemsSource = TrabajarProyeccion.traerProyecciones();
        }


        /// <summary>
        /// abre el alta de proyecciones
        /// </summary>
        /// <param name="altaProyeccio"></param>
        private void abrirVentanaAlta(WPFAltaProyeccion altaProyeccio)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(altaProyeccio);
        }

        /// <summary>
        /// refresca el data grid para ver los cambios en la lista
        /// </summary>
        public void refrescarDataGrid()
        {
            dgvListaDeProyecciones.ItemsSource = null;
            dgvListaDeProyecciones.ItemsSource = TrabajarProyeccion.traerProyecciones();
        }

        /// <summary>
        /// accede a la seccion de modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion(new ClasesBase.Proyeccion(), this));
        }

        /// <summary>
        /// abre la ventana de alta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAltaCliente_Click(object sender, RoutedEventArgs e)
        {
            abrirVentanaAlta(new WPFAltaProyeccion(this));
        }


        /// <summary>
        /// al seleccionar un item habilita la modificacion del mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvListaDeProyecciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion((ClasesBase.Proyeccion)dgvListaDeProyecciones.SelectedItem, this));
        }
    }
}
