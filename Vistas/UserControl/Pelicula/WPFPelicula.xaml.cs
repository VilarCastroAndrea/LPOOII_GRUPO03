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
            panelPelicula.Children.Add(new WPFMostrarPelicula());
        }

        private void BtnModificarPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelPelicula.Children.Clear();
            panelPelicula.Children.Add(new WPFMostrarPelicula());
        }

        private void BtnAltaPelicula_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelPelicula.Children.Clear();
            panelPelicula.Children.Add(new WPFAltaPelicula());
        }
    }
}
