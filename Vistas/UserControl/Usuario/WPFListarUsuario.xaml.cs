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
using ClasesBase;
using System.Collections.ObjectModel;
namespace Vistas.UserControl.Usuario
{
    /// <summary>
    /// Lógica de interacción para WPFListarUsuario.xaml
    /// </summary>
    public partial class WPFListarUsuario
    {
        private CollectionViewSource vistaColeccionFiltrada;//vista coleccion filtrada

        public WPFListarUsuario()
        {
            InitializeComponent();
            //se accede al recurso de CollectionViewSource
            //vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
            vistaColeccionFiltrada = (CollectionViewSource)(this.Resources["VISTA_USER"]);
        }

       

        ObservableCollection<ClasesBase.Usuario> listaUsuario;

        private void UserControlUsuario_Loaded(object sender, RoutedEventArgs e)
        {

            //object data provide
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<ClasesBase.Usuario>;

            ////vista por defecto
            //vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);

        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {
            ClasesBase.Usuario usuario = e.Item as ClasesBase.Usuario;

            //se realiza la busqueda por nombre de usuario
           
            if (usuario.Usu_NombreUsuario.StartsWith(txtBuscarUsuario.Text, StringComparison.CurrentCultureIgnoreCase)) {
                e.Accepted = true;

            }
            else {
                e.Accepted = false; 
            }
            


        }

        private void TxtBuscarUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (vistaColeccionFiltrada != null) {
                //se invoca al metodo sa medida que vayamos escribiendo
               //vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
              

                Console.WriteLine("Cambio");

            }
            */
            if (vistaColeccionFiltrada != null)
                vistaColeccionFiltrada.Filter += new FilterEventHandler(filtroL);

        }

        private void filtroL(object sender, FilterEventArgs e)
        {
            ClasesBase.Usuario usu = (ClasesBase.Usuario)e.Item;
            if (usu.Usu_NombreUsuario.StartsWith(txtBuscarUsuario.Text, StringComparison.CurrentCultureIgnoreCase))
                e.Accepted = true;
            else
                e.Accepted = false;
        }


    }
}