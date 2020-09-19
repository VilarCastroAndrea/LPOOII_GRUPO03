using System.Windows;
namespace Vistas.UserControl.Proyeccion
{
    /// <summary>
    /// Lógica de interacción para WPFProyeccion.xaml
    /// </summary>
    public partial class WPFProyeccion
    {
        public WPFProyeccion()
        {
            InitializeComponent();
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion());
        }

        private void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFMostrarProyeccion());
        }

        private void BtnAltaCliente_Click(object sender, RoutedEventArgs e)
        {
            panelProyeccion.Children.Clear();
            panelProyeccion.Children.Add(new WPFAltaProyeccion());
        }
    }
}
