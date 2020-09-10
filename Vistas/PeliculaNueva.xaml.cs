using ClasesBase;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para PeliculaNueva.xaml
    /// </summary>
    public partial class PeliculaNueva : Window
    {
        Clasificacion clasificacion = new Clasificacion();
        Genero genero = new Genero();
        ArrayList clasificaciones = new ArrayList();
        List<Genero> generos = new List<Genero>();

        public PeliculaNueva()
        {
            InitializeComponent();
            crearClasificaciones();
            cargarComboClasificacion();
            crearGeneros();
            cargarComboGenero();
        }

        private void cargarComboClasificacion()
        {
            cmbClasificacion.ItemsSource = clasificaciones;
            cmbClasificacion.DisplayMemberPath = "Cls_Descripcion";
            cmbClasificacion.SelectedValue = "Cls_Id";
            cmbClasificacion.SelectedIndex = 0;

        }

        private void cargarComboGenero()
        {
            cmbGenero.ItemsSource = generos;
            cmbGenero.DisplayMemberPath = "Gnr_Descripcion";
            cmbGenero.SelectedValue = "Gnr_Id";
            cmbGenero.SelectedIndex = 0;
        }

        private void crearClasificaciones()
        {
            clasificaciones.Add(new Clasificacion(0, "A"));
            clasificaciones.Add(new Clasificacion(1, "B"));
            clasificaciones.Add(new Clasificacion(2, "B15"));
            clasificaciones.Add(new Clasificacion(3, "C"));
        }

        private void crearGeneros()
        {
            generos.Add(new Genero(0, "Comedia"));
            generos.Add(new Genero(1, "Terror"));
            generos.Add(new Genero(2, "Ciencia Ficcion"));
            generos.Add(new Genero(3, "Musicales"));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";

            openFileDialog1.DefaultExt = ".jpeg";

            txtImagenPeli.Text = openFileDialog1.FileName;

            ImageSource imageSource = new BitmapImage(new Uri(txtImagenPeli.Text));

            imgPeli.Source = imageSource;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.Peli_Titulo = txtPeliTitulo.Text;
            pelicula.Peli_Duracion = txtPeliDuracion.Text;
            pelicula.Peli_Imagen1 = txtImagenPeli.Text;
            //ImageSource imageSource = new BitmapImage(new Uri(pelicula.Peli_Imagen1));
            // imgprueba.Source = imageSource;
            MessageBoxResult messageBoxResult = MessageBox.Show("Estas seguro?", "Agregar Pelicula", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MessageBox.Show(
                     "Pelcula\n" +
                     "Titulo : " + pelicula.Peli_Titulo + "\n" +
                     "Duracion:" + pelicula.Peli_Duracion + "min\n" +
                     "Clasificacion: " + cmbClasificacion.Text + "\n" +
                     "Genero: " + cmbGenero.Text
                    );
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtPeliTitulo.Text = "";
            txtPeliDuracion.Text = "";
            txtImagenPeli.Text = "";
        }
    }
}
