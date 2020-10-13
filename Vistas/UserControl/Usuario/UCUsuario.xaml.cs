using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
namespace Vistas.UserControl.Usuario

{
    /// <summary>
    /// Lógica de interacción para UCUsuario.xaml
    /// </summary>
    public partial class UCUsuario
    {
        public UCUsuario()
        {
            InitializeComponent();
        }

        CollectionView vista;
        ObservableCollection<ClasesBase.Usuario> listaUsuario;

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("PASO 1");
            MessageBox.Show("Primero");

        }

        private void UserControlUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<ClasesBase.Usuario>;

            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);

        }

        private void BtnPrimero_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Primero");

        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ultimo");

        }
    }
}
