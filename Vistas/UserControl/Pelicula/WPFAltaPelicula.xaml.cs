using Microsoft.Win32;
using System;
using System.Windows;

namespace Vistas.UserControl.Pelicula
{
    /// <summary>
    /// Lógica de interacción para WPFAltaPelicula.xaml
    /// </summary>
    public partial class WPFAltaPelicula
    {
 
        public string name { get; set; }

        WPFPelicula padre;

        public WPFAltaPelicula(WPFPelicula formularioPadre)
        {
            InitializeComponent();
            padre = formularioPadre;

        }
        


        private void BtnAltaPelicula_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                try
                {
                    padre.altaPelicula(new ClasesBase.Pelicula(0,txtTitulo.Text,txtDuracion.Text,cmbGenero.Text,cmbClasificacion.Text));
                    MessageBoxResult resultado = MessageBox.Show("Se agrego la pelicula con exito", "Atención");
                    //limpiarCampos();
                }
                catch(Exception error)
                {
                    MessageBoxResult resultado = MessageBox.Show("Error al realizar el alta de Pelicula ", "Atención");
                }

            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }

        }

        private bool validarCampos()
        {
            if (txtTitulo.Text == "" || txtDuracion.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiarCampos()
        {
            txtTitulo.Text = "";
            txtDuracion.Text = "";
            txtImagenPeli.Text = "";
        }

    }
}
