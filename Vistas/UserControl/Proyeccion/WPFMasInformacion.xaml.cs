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
using ClasesBase;

namespace Vistas.UserControl.Proyeccion
{
    /// <summary>
    /// Lógica de interacción para WPFMasInformacion.xaml
    /// </summary>
    public partial class WPFMasInformacion : Window
    {
        ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
        ClasesBase.Proyeccion pro = new ClasesBase.Proyeccion();
        ClasesBase.Sala sala = new ClasesBase.Sala();
        public WPFMasInformacion(ClasesBase.Proyeccion proyeccion)
        {
            InitializeComponent();
            pelicula = ClasesBase.TrabajarPelicula.buscarPelicula(proyeccion.Peli_Codigo.ToString());
            sala = ClasesBase.TrabajarSala.buscarSala(proyeccion.Sla_NroSala.ToString());
            pro = proyeccion;
            cargarInformacion();
        }

        public void cargarInformacion()
        {
            txtPelicula.Text = pelicula.Peli_Titulo;
            txtGenero.Text = pelicula.Peli_Genero;
            txtClasificacion.Text = pelicula.Peli_Clasificacion;
            txtFecha.Text = pro.Proy_Fecha;
            txtHora.Text = pro.Proy_Hora;
            txtDuracion.Text = pelicula.Peli_Duracion;
            txtSala.Text = sala.Sla_Descripcion;

            try
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(pelicula.Peli_Imagen);
                b.EndInit();
                imgPelicula.Stretch = Stretch.Fill;
                imgPelicula.Source = b;
            }
            catch
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri("/../../../Img/logo.png", UriKind.Relative);
                b.EndInit();
                imgPelicula.Stretch = Stretch.Fill;
                imgPelicula.Source = b;
            }


            try
            {
                TransformGroup tg = new TransformGroup();
                videoPelicula.RenderTransform = tg;
                videoPelicula.Source = new Uri(pelicula.Peli_Avance);
            }
            catch
            {
                TransformGroup tg = new TransformGroup();
                videoPelicula.RenderTransform = tg;
                videoPelicula.Source = new Uri("/../../../Videos/noVideo.mp4", UriKind.Relative);
            }
  
        }
    }
}
