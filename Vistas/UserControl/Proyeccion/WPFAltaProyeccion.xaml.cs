using ClasesBase;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Vistas.UserControl.Proyeccion
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarProyeccion.xaml
    /// </summary>
    public partial class WPFAltaProyeccion
    {
        private WPFProyeccion proyeccionPadre;

        public WPFAltaProyeccion(WPFProyeccion proyeccion)
        {
            proyeccionPadre = proyeccion;
            InitializeComponent();
        }

        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCamposVacios() != true)
            {
                MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtFecha.Text + ", " + txtHora.Text + ", " +
             txtSala.Text + ", " + txtTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {

                    MessageBox.Show("Proyeccion Guardada con exito");
                    ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(0, txtFecha.Text, txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text));
                    proyeccionPadre.agregarProyeccion(nuevaProyeccion);
                    limpiarCampos();
                }
            }
        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void limpiarCampos()
        {
            txtFecha.Text = "";
            txtHora.Text = "";
            txtSala.Text = "";
            txtTitulo.Text = "";
        }


        private bool validarCamposVacios()
        {
            if (txtFecha.Text == "" && txtHora.Text == "" && txtSala.Text == "" && txtTitulo.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
