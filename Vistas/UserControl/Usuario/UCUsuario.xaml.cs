using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ClasesBase;
namespace Vistas.UserControl.Usuario
{
    /// <summary>
    /// Lógica de interacción para UCUsuario.xaml
    /// </summary>
    public partial class UCUsuario
    {

        private CollectionViewSource vistaColeccionFiltrada;//vista coleccion filtrada

        public UCUsuario()
        {
            InitializeComponent();
            cargar_combo_Rol();
            cargar_combo_Ro2();

            //se accede al recurso de CollectionViewSource
            //vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
            vistaColeccionFiltrada = (CollectionViewSource)(this.Resources["VISTA_USER"]);

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

            //object data provide
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<ClasesBase.Usuario>;

            //vista por defecto
            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);

        }

        private void BtnPrimero_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToFirst();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToLast();

        }

        private void BtnPrevio_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToPrevious();
            if (vista.IsCurrentBeforeFirst) {
                vista.MoveCurrentToLast();
            }
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToNext();
            if (vista.IsCurrentAfterLast) {
                vista.MoveCurrentToFirst();
            }
        }


        private void cargar_combo_Rol()
        {
            cmbRol.ItemsSource = TrabajarRol.listar_roles();
            cmbRol.SelectedValuePath = "Rol_Codigo";
            cmbRol.DisplayMemberPath = "Rol_Descripcion";

        }


        private void cargar_combo_Ro2()
        {
            cmbRol2.ItemsSource = TrabajarRol.listar_roles();
            cmbRol2.SelectedValuePath = "Rol_Codigo";
            cmbRol2.DisplayMemberPath = "Rol_Descripcion";

        }



        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClasesBase.Usuario usuario = new ClasesBase.Usuario();

            usuario.Usu_ApellidoNombre = txtNombreApellido.Text;
            usuario.Usu_NombreUsuario = txtUsuario.Text;
            usuario.Usu_Password = txtPassword.Text;
            usuario.Usu_Disponible = true;
            usuario.Rol_Codigo = (int)cmbRol.SelectedValue;

            usuario.Usu_Id = TrabajarUsuario.insertar_usuario(usuario).Usu_Id;
            listaUsuario.Add(usuario);

            MessageBox.Show("Usuario Agregado Correctamente");
            vista.MoveCurrentToLast();

            limpiarCampos();
        }


        private void limpiarCampos() {

            txtNombreApellido.Text = null;
            txtUsuario.Text = null;
            txtPassword.Text = null;
            cmbRol.SelectedIndex = -1;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TrabajarUsuario.eliminar_usuario(id);

            //recorre la lista buscando el id
            for (int i = 0; i < listaUsuario.Count; i++) {
                if (listaUsuario[i].Usu_Id == id) {
                    //elimina el elemento
                    listaUsuario.RemoveAt(i);
                }
            }

            MessageBox.Show("Usuario Eliminado Correctamente");
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            ClasesBase.Usuario usuario = new ClasesBase.Usuario();

            int id = Convert.ToInt32(txtId.Text);

            usuario.Usu_Id = id;
            usuario.Usu_ApellidoNombre = txtNombreApellido2.Text;
            usuario.Usu_NombreUsuario = txtUsuario2.Text;
            usuario.Usu_Password = txtPassword2.Text;
            usuario.Usu_Disponible = true;
            usuario.Rol_Codigo = (int)cmbRol2.SelectedValue;

            TrabajarUsuario.actualizar_usuario(usuario);

            //recorre la lista buscando el id
            for (int i = 0; i < listaUsuario.Count; i++){
                if (listaUsuario[i].Usu_Id == id)
                {
                    //reemplaza los valores en la lista
                    listaUsuario[i].Usu_ApellidoNombre = usuario.Usu_ApellidoNombre;
                    listaUsuario[i].Usu_Password = usuario.Usu_Password;
                    listaUsuario[i].Usu_NombreUsuario = usuario.Usu_NombreUsuario;
                    listaUsuario[i].Rol_Codigo = usuario.Rol_Codigo;

                    MessageBox.Show("UsuarioActualizado Correctamente");
                    //vuelve a la misma posicion de la lista
                    vista.MoveCurrentToLast();
                    vista.MoveCurrentToPosition(i);
                }
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

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {
            ClasesBase.Usuario usuario = e.Item as ClasesBase.Usuario;

            //se realiza la busqueda por nombre de usuario
            /*
            if (usuario.Usu_NombreUsuario.StartsWith(txtBuscarUsuario.Text, StringComparison.CurrentCultureIgnoreCase)) {
                e.Accepted = true;

            }
            else {
                e.Accepted = false; 
            }
            
    */

        }

    }
}
