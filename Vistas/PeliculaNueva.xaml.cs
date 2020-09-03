using ClasesBase;
using Microsoft.Win32;
using System;
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
        BitmapImage bitmapImage;

        public PeliculaNueva()
        {
            InitializeComponent();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”" ;

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

            

            ImageSource imageSource = new BitmapImage(new Uri(pelicula.Peli_Imagen1));

            imgprueba.Source = imageSource;
            

            

        }
    }
}
