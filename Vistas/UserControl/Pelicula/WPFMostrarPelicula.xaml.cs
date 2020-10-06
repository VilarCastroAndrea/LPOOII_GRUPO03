using Microsoft.Win32;
using System;
using System.Windows;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFMostrarPelicula.xaml
    /// </summary>
    public partial class WPFMostrarPelicula
    {
        ClasesBase.Pelicula peliculaSeleccionada;
        WPFPelicula proyeccionPadre;
        public WPFMostrarPelicula(ClasesBase.Pelicula selectedItem,WPFPelicula padre)
        {
            InitializeComponent();
            txtDuracion.Text = selectedItem.Peli_Duracion;
            txtImagenPeli.Text = selectedItem.Peli_Imagen;
            txtTitulo.Text = selectedItem.Peli_Titulo;
            cmbClasificacion.Text = selectedItem.Peli_Clasificacion;
            cmbGenero.Text = selectedItem.Peli_Genero;
            peliculaSeleccionada = selectedItem;
            proyeccionPadre = padre;
        }

        private void BtnModificarPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {

                proyeccionPadre.modificarPelicula(new ClasesBase.Pelicula(1, txtTitulo.Text, txtDuracion.Text, cmbGenero.Text, cmbClasificacion.Text, txtImagenPeli.Text));
                    MessageBoxResult resultado = MessageBox.Show("Se modifico la pelicula con exito", "Atención");
                    limpiarCampos();
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }
        }

        private bool validarCampos()
        {
            if (txtTitulo.Text == "" || txtDuracion.Text == "" || txtImagenPeli.Text == "")
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

        private void ExaminarImg_Click(object sender, RoutedEventArgs e)
        {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";
                openFileDialog1.DefaultExt = ".jpeg";
                txtImagenPeli.Text = openFileDialog1.FileName;
        }

        private void BtnBajaPelicula_Click(object sender, RoutedEventArgs e)
        {
            proyeccionPadre.eliminarPelicula(peliculaSeleccionada);
        }
    }
}
