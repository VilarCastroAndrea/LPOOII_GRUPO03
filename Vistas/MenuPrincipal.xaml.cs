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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listViewMenu.SelectedIndex;
            moverCursoMenu(index);


            switch (index) {
                case 0: stackPanelPrincipal.Children.Clear();
                    stackPanelPrincipal.Children.Add(new Clientes());
                    break;
                case 1:
                    stackPanelPrincipal.Children.Clear();
                    stackPanelPrincipal.Children.Add(new Pelicula());
                    break;

                default:
                    break;
            }


        }

        private void moverCursoMenu(int index)
        {
          
        }
    }
}
