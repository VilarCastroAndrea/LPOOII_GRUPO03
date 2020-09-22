using ClasesBase;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace Vistas.UserControl.Proyeccion
{
    /// <summary>
    /// Lógica de interacción para WPFProyeccion.xaml
    /// </summary>
    public partial class WPFProyeccion
    {
        private List<ClasesBase.Proyeccion> listaDeProyecciones;

        public WPFProyeccion()
        {
            InitializeComponent();
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFAltaProyeccion(this));
            listaDeProyecciones = new List<ClasesBase.Proyeccion>();
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones;
        }

        public void agregarProyeccion(ClasesBase.Proyeccion nuevaProyeccion)
        {
            listaDeProyecciones.Add(nuevaProyeccion);
            dgvListaDeProyecciones.ItemsSource = null;
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones; ;

        }

        public void borrarProyeccion(ClasesBase.Proyeccion proyeccionEliminar)
        {
            for (int i = 0; i < listaDeProyecciones.Count; i++)
            {
                if (listaDeProyecciones[i].Proy_Codigo == proyeccionEliminar.Proy_Codigo) // there will only one item with Number = 1   
                {
                    listaDeProyecciones.Remove(listaDeProyecciones[i]);
                }
            }
            btnAltaCliente.Focus();
            refrescarDataGrid();
            abrirVentanaAlta(new WPFAltaProyeccion(this));
        }

        private void abrirVentanaAlta(WPFAltaProyeccion altaProyeccio)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(altaProyeccio);
        }

        public void modificarProyeccion(ClasesBase.Proyeccion proyeccionModificar)
        {
            foreach(ClasesBase.Proyeccion proyeccion in listaDeProyecciones)
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

        private void refrescarDataGrid()
        {
            dgvListaDeProyecciones.ItemsSource = null;
            dgvListaDeProyecciones.ItemsSource = listaDeProyecciones;
        }

        private void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion(new ClasesBase.Proyeccion(), this));
        }

        private void BtnAltaCliente_Click(object sender, RoutedEventArgs e)
        {
            abrirVentanaAlta(new WPFAltaProyeccion(this));
        }

        private void DgvListaDeProyecciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add( new WPFMostrarProyeccion((ClasesBase.Proyeccion)dgvListaDeProyecciones.SelectedItem, this));
        }
    }
}
