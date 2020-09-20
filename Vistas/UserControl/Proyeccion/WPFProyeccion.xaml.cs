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

        private void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion(new ClasesBase.Proyeccion()));
        }

        private void BtnAltaCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFAltaProyeccion(this));
        }

        private void DgvListaDeProyecciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add( new WPFMostrarProyeccion((ClasesBase.Proyeccion)dgvListaDeProyecciones.SelectedItem));
        }
    }
}
