using ClasesBase;
using System.Collections.Generic;
using System.Windows;


namespace Vistas.UserControl.Proyeccion
{
    using ClasesBase;
    using ClasesBase.DTO;
    using System;
    using System.Data;
    using System.Windows.Data;

    /// <summary>
    /// Lógica de interacción para WPFProyeccion.xaml
    /// </summary>
    public partial class WPFProyeccion
    {
        /// <summary>
        /// Vista para filtrar
        /// </summary>
        private CollectionViewSource vistaColeccionFiltrada;

        
        /// <summary>
        /// al iniciar se inicializara una lista de proyecciones y se cargara en el data grid view
        /// </summary>
        public WPFProyeccion()
        {
            InitializeComponent();
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFAltaProyeccion(this));

            vistaColeccionFiltrada = (CollectionViewSource)(this.Resources["VISTA_PROY"]);
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
            dgvListaDeProyecciones.ItemsSource = TrabajarProyeccion.traerDTOProyecciones();
        }

        /// <summary>
        /// accede a la seccion de modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DTOProyeccion dto = (DTOProyeccion)dgvListaDeProyecciones.SelectedItem;
                Proyeccion p = GenerarProyeccion(dto);
                panelProyeccion.Children.Clear();
                panelProyeccion.Children.Add(new WPFMostrarProyeccion(p, this));
            }
            catch
            {
                MessageBoxResult resultado = MessageBox.Show("Debe seleccionar una PROYECCION para modificar.", "Atención");
            }
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
            try
            {
                DTOProyeccion dto = (DTOProyeccion)dgvListaDeProyecciones.SelectedItem;
                Proyeccion p = GenerarProyeccion(dto);
                panelProyeccion.Children.Clear();
                panelProyeccion.Children.Add(new WPFMostrarProyeccion(p, this));
            }
            catch
            {
                System.Console.WriteLine("Error en seletionChanged de proyeccion");
            }

        }

        /// <summary>
        /// Genera una proyeccion a partir de un DTOProyeccion
        /// </summary>
        /// <returns></returns>
        private Proyeccion GenerarProyeccion(DTOProyeccion dto)
        {
            Proyeccion p = new Proyeccion();
            p.Proy_Codigo = dto.Proy_Codigo;
            p.Proy_Fecha = dto.Proy_Fecha;
            p.Proy_Hora = dto.Proy_Hora;
            p.Proy_Disponible = dto.Proy_Disponible;
            p.Peli_Codigo = dto.Peli_Codigo;
            p.Sla_NroSala = dto.Sla_NroSala;
            //DataRowView drv = (DataRowView)dgvListaDeProyecciones.SelectedItem;
            //p.Peli_Codigo = int.Parse(drv["Codigo de Pelicula"].ToString());
            //p.Proy_Codigo = int.Parse(drv["Codigo"].ToString());
            //p.Proy_Disponible = bool.Parse(drv["Disponible"].ToString());
            //p.Proy_Fecha = drv["Fecha"].ToString();
            //p.Proy_Hora = drv["Hora"].ToString();
            //p.Sla_NroSala = int.Parse(drv["Numero de Sala"].ToString());
            return p;

        }

        private void TxtFiltrar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
                vistaColeccionFiltrada.Filter += new FilterEventHandler(filtroL);
        }

        private void filtroL(object sender, FilterEventArgs e)
        {
            DTOProyeccion dtoProy = (DTOProyeccion)e.Item;
            if(dtoProy.Peli_Titulo.StartsWith(txtFiltrar.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void eventVistaProyeccion_Filter(object sender, FilterEventArgs e)
        {
            DTOProyeccion dtoProyeccion = e.Item as DTOProyeccion;
        }

        
    }
}
