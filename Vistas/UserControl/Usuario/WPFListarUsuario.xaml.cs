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
    /// Lógica de interacción para WPFListarUsuario.xaml
    /// </summary>
    public partial class WPFListarUsuario 
    {
        private CollectionViewSource vistaColeccionFiltrada;

        public WPFListarUsuario()
        {
            InitializeComponent();
            vistaColeccionFiltrada = (CollectionViewSource)(this.Resources["VISTA_USER"]);
        }

        private void TxtFiltrar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
                vistaColeccionFiltrada.Filter += new FilterEventHandler(filtroL);
        }

        private void filtroL(object sender, FilterEventArgs e)
        {
            ClasesBase.Usuario usu = (ClasesBase.Usuario)e.Item;
            if (usu.Usu_NombreUsuario.StartsWith(txtFiltrar.Text, StringComparison.CurrentCultureIgnoreCase))
                e.Accepted = true;
            else
                e.Accepted = false;
        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {
            ClasesBase.Usuario usuario = e.Item as ClasesBase.Usuario;
        }
    }
}
