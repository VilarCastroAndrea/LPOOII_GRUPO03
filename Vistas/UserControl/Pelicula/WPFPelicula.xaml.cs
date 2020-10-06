using System;
using System.Data;
using Vistas.UserControl.Pelicula;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFPelicula.xaml
    /// </summary>
    public partial class WPFPelicula
    {

        public WPFPelicula()
        {
            InitializeComponent();
            panelPelicula.Children.Clear();
            panelPelicula.Children.Add(new WPFAltaPelicula());
        }

        private void BtnModificarPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelPelicula.Children.Clear();
            DataRowView item = (DataRowView)listPeliculas.SelectedItem;
            ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
            pelicula.Peli_Codigo = Convert.ToInt32(item["Codigo"]);
            pelicula.Peli_Clasificacion= Convert.ToString(item["Clasificacion"]);
            pelicula.Peli_Duracion = Convert.ToString(item["Duracion"]);
            pelicula.Peli_Genero = Convert.ToString(item["Genero"]);
   //         pelicula.Peli_Imagen = Convert.ToString(item["Imagen"]);
            pelicula.Peli_Titulo= Convert.ToString(item["Titulo"]);

            panelPelicula.Children.Add(new WPFMostrarPelicula(pelicula,this));
        }




        public void modificarPelicula(ClasesBase.Pelicula pelicula)
        {
            ClasesBase.TrabajarPelicula.modificarPelicula(pelicula);
            panelPelicula.Children.Clear();
            panelPelicula.Children.Add(new WPFAltaPelicula());
        }



        public void eliminarPelicula(ClasesBase.Pelicula pelicula)
        {
            try
            {
                ClasesBase.TrabajarPelicula.bajaPeliculaFisica(pelicula.Peli_Codigo);
            }
            catch
            {
                ClasesBase.TrabajarPelicula.bajaPelicula(pelicula.Peli_Codigo, true);
            }
            finally
            {
                panelPelicula.Children.Clear();
                panelPelicula.Children.Add(new WPFAltaPelicula());
            }
        }


        private void BtnAltaPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelPelicula.Children.Clear();
            panelPelicula.Children.Add(new WPFAltaPelicula());
        }

        private void Peliculas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
