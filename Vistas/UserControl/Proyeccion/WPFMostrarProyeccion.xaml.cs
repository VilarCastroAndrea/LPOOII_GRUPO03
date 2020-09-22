using ClasesBase;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows;
using System.Windows.Input;

namespace Vistas.UserControl.Proyeccion

{
    /// <summary>
    /// Lógica de interacción para WPFAltaProyeccion.xaml
    /// </summary>
    public partial class WPFMostrarProyeccion
    {
        ClasesBase.Proyeccion proyeccionMostrar;
        WPFProyeccion proyeccionPadre;

        public WPFMostrarProyeccion(ClasesBase.Proyeccion verProyeccion, WPFProyeccion proyeccion)
        {
            proyeccionMostrar = verProyeccion;
            InitializeComponent();
            if (proyeccionMostrar != null)
            {
                txtFecha.Text = proyeccionMostrar.Proy_Fecha;
                txtHora.Text = proyeccionMostrar.Proy_Hora;
                txtSala.Text = proyeccionMostrar.Sla_NroSala.ToString();
                txtTitulo.Text = proyeccionMostrar.Peli_Codigo.ToString();
                proyeccionPadre = proyeccion;
            }


        }

        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            proyeccionPadre.modificarProyeccion(new ClasesBase.Proyeccion(proyeccionMostrar.Proy_Codigo, txtFecha.Text
                , txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text),true));
        }

        private void BtnBoja_Click(object sender, System.Windows.RoutedEventArgs e)
        {

                MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea borrar esta proyeccion?" + txtFecha.Text + ", " + txtHora.Text + ", " +
             txtSala.Text + ", " + txtTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {

                    MessageBox.Show("Proyeccion Eliminada con exito");
                    ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(0, txtFecha.Text, txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text));
                proyeccionPadre.borrarProyeccion(new ClasesBase.Proyeccion(proyeccionMostrar.Proy_Codigo, txtFecha.Text
                    , txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text), true));
            }
            



        }
    }
}
