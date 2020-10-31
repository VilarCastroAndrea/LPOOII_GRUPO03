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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.UserControl.Usuario
{
    /// <summary>
    /// Lógica de interacción para WPFUsuario.xaml
    /// </summary>
    public partial class WPFUsuario
    {
        public WPFUsuario()
        {
            InitializeComponent();
            panelUsuario.Children.Clear();
            panelUsuario.Children.Add(new WPFMostrarUsuario());
        }

        private void BtnMostrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelUsuario.Children.Clear();
            panelUsuario.Children.Add(new WPFMostrarUsuario());
        }

        private void BtnAltaAltaUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelUsuario.Children.Clear();
            panelUsuario.Children.Add(new WPFAltaUsuario());
        }

        private void BtnListarUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelUsuario.Children.Clear();
            panelUsuario.Children.Add(new WPFListarUsuario());
        }

    }
}
