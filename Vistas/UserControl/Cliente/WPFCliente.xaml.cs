namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFCliente.xaml
    /// </summary>
    public partial class WPFCliente
    {
        public WPFCliente()
        {
            InitializeComponent();
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFMostrarCliente());
        }

        private void BtnModificarCliente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFMostrarCliente());
           
        }

        private void BtnAltaCliente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panelCliente.Children.Clear();
            panelCliente.Children.Add(new WPFAltaCliente(this));
        }
    }
}
