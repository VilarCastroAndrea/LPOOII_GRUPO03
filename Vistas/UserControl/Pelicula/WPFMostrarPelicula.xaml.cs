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
            txtTitulo.Text = selectedItem.Peli_Titulo;
            cmbClasificacion.SelectedValue = selectedItem.Peli_Clasificacion;
            cmbGenero.SelectedValue = selectedItem.Peli_Genero;
            peliculaSeleccionada = selectedItem;
            txtImagen.Text = selectedItem.Peli_Imagen;
            txtVideo.Text = selectedItem.Peli_Avance;
                  
            proyeccionPadre = padre;
        }

        private void BtnModificarPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {

                ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();

                pelicula.Peli_Codigo = peliculaSeleccionada.Peli_Codigo; 
                pelicula.Peli_Titulo = txtTitulo.Text;
                pelicula.Peli_Duracion = txtDuracion.Text;
                pelicula.Peli_Genero = cmbGenero.Text;
                pelicula.Peli_Clasificacion = cmbClasificacion.Text;
                pelicula.Peli_Imagen = txtImagen.Text;
                pelicula.Peli_Avance = txtVideo.Text;
                pelicula.Peli_Disponible = true;

                proyeccionPadre.modificarPelicula(pelicula);
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
            if (txtTitulo.Text == "" || txtTitulo.Text.Length <5 || txtDuracion.Text == "" || txtDuracion.Text.Length < 5 || txtImagen.Text == "" || txtImagen.Text.Length < 5 || txtVideo.Text == "" || txtVideo.Text.Length < 5)
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
        }

        private void BtnBajaPelicula_Click(object sender, RoutedEventArgs e)
        {
            proyeccionPadre.eliminarPelicula(peliculaSeleccionada);
        }

        private void BtnExaminarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";

            openFileDialog1.DefaultExt = ".jpeg";

            txtImagen.Text = openFileDialog1.FileName;
        }

        private void BtnExaminarVideo_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            openFileDialog.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";

            openFileDialog.DefaultExt = ".jpeg";

            txtVideo.Text = openFileDialog.FileName;
        }
    }
}
