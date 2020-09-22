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
        private List<ClasesBase.Proyeccion> listaDeProyecciones;
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
            listaDeProyecciones = new List<ClasesBase.Proyeccion>();
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones;
        }


        /// <summary>
        /// agrega una proyeccion a la vista
        /// </summary>
        /// <param name="nuevaProyeccion"></param>
        public void agregarProyeccion(ClasesBase.Proyeccion nuevaProyeccion)
        {
            listaDeProyecciones.Add(nuevaProyeccion);
            dgvListaDeProyecciones.ItemsSource = null;
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones; ;

        }


        /// <summary>
        /// borra una proyeccion de la lista
        /// </summary>
        /// <param name="proyeccionEliminar"></param>
        public void borrarProyeccion(ClasesBase.Proyeccion proyeccionEliminar)
        {
            for (int i = 0; i < listaDeProyecciones.Count; i++)
            {
                if (listaDeProyecciones[i].Proy_Codigo == proyeccionEliminar.Proy_Codigo)
                {
                    listaDeProyecciones.Remove(listaDeProyecciones[i]);
                }
            }
            btnAltaCliente.Focus();
            refrescarDataGrid();
            abrirVentanaAlta(new WPFAltaProyeccion(this));
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
        /// modifica una proyeccion enviada ppor el usuario
        /// </summary>
        /// <param name="proyeccionModificar"></param>
        public void modificarProyeccion(ClasesBase.Proyeccion proyeccionModificar)
        {
            foreach (ClasesBase.Proyeccion proyeccion in listaDeProyecciones)
            {
                if (proyeccionModificar.Proy_Codigo == proyeccion.Proy_Codigo)
                {
                    proyeccion.Peli_Codigo = proyeccionModificar.Peli_Codigo;
                    proyeccion.Proy_Disponible = proyeccionModificar.Proy_Disponible;
                    proyeccion.Proy_Fecha = proyeccionModificar.Proy_Fecha;
                    proyeccion.Proy_Hora = proyeccionModificar.Proy_Hora;
                    proyeccion.Sla_NroSala = proyeccionModificar.Sla_NroSala;
                }
            }
            refrescarDataGrid();
        }

        /// <summary>
        /// refresca el data grid para ver los cambios en la lista
        /// </summary>
        private void refrescarDataGrid()
        {
            dgvListaDeProyecciones.ItemsSource = null;
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones;
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
