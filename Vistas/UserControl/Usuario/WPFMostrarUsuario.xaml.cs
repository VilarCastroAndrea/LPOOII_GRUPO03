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
    /// Lógica de interacción para WPFMostrarUsuario.xaml
    /// </summary>
    public partial class WPFMostrarUsuario 
    {
        CollectionView vista;
        ObservableCollection<ClasesBase.Usuario> listaUsuario;
        public WPFMostrarUsuario()
        {
            InitializeComponent();
            cargarComboRol();
        }

        private void UserControlUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<ClasesBase.Usuario>;
            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvasContent.DataContext);
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            ClasesBase.Usuario usuario = new ClasesBase.Usuario();
            int id = Convert.ToInt32(txtId.Text);

            usuario.Usu_Id = id;
            usuario.Usu_ApellidoNombre = txtApellidoNombre.Text;
            usuario.Usu_NombreUsuario = txtNombreUsuario.Text;
            usuario.Usu_Password = txtPassword.Text;
            usuario.Usu_Disponible = true;
            usuario.Rol_Codigo = (int)cmbRol.SelectedValue;

            TrabajarUsuario.modificarUsuario(usuario);

            for (int i = 0; i < listaUsuario.Count; i++)
            {
                if (listaUsuario[i].Usu_Id == id)
                {
                    //reemplaza los valores en la lista
                    listaUsuario[i].Usu_ApellidoNombre = usuario.Usu_ApellidoNombre;
                    listaUsuario[i].Usu_Password = usuario.Usu_Password;
                    listaUsuario[i].Usu_NombreUsuario = usuario.Usu_NombreUsuario;
                    listaUsuario[i].Rol_Codigo = usuario.Rol_Codigo;
                }
            }
        }

        private void cargarComboRol()
        {
            cmbRol.ItemsSource = TrabajarRol.listarRoles();
            cmbRol.SelectedValuePath = "Rol_Codigo";
            cmbRol.DisplayMemberPath = "Rol_Descripcion";
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TrabajarUsuario.bajaUsuario(id, false);
            //recorre la lista buscando el id
            for (int i = 0; i < listaUsuario.Count; i++)
            {
                if (listaUsuario[i].Usu_Id == id)
                {
                    //elimina el elemento
                    listaUsuario.RemoveAt(i);
                }
            }
            MessageBox.Show("Usuario Eliminado Correctamente");
        }

        private void BtnPrimera_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToFirst();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToLast();
        }

        private void BtnAnteriror_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToPrevious();
            if (vista.IsCurrentBeforeFirst)
            {
                vista.MoveCurrentToLast();
            }
        }

        private void BtnSig_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToNext();
            if (vista.IsCurrentAfterLast)
            {
                vista.MoveCurrentToFirst();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

       

    }
}
