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
            if (txtTitulo.Text == "" || txtTitulo.Text.Length <5 || txtDuracion.Text == "" || txtDuracion.Text.Length < 5)
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
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro de eliminar la Pelicula?", "Confirmar Eliminacion", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    proyeccionPadre.eliminarPelicula(peliculaSeleccionada);
                    MessageBox.Show("La Pelicula se ha eliminado correctamente");
                }
                catch(Exception error)
                {
                    MessageBox.Show("Ups! Ha Ocurrido un Error" + error);
                }

            }

        }

        private void BtnExaminarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpg Files |*.jpg; *.png;";
            openFileDialog1.ShowDialog();

            txtImagen.Text = openFileDialog1.FileName;
        }

        private void BtnExaminarVideo_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mp4 Files|*.mp4";
            openFileDialog.ShowDialog();

            txtVideo.Text = openFileDialog.FileName;
        }
    }
}
