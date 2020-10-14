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
    using ClasesBase;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Lógica de interacción para UCUsuario.xaml
    /// </summary>
    public partial class UCUsuario
    {
        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuarios;

        public UCUsuario()
        {
            InitializeComponent();
            //Estas instrucciones van debajo del Initialize sino da error.
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuarios = odp.Data as ObservableCollection<Usuario>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(stpContent.DataContext);
        }

        private void BtnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            //Capturar los valores del textbox
            Usuario oUsu = CapturarInputs();
            oUsu.Usu_Disponible = true;
            //Guardar Usuario en la bd
            //TrabajarUsuario.InsertarUsuario(oUsu);
            //Actualizar la lista
            listaUsuarios.Add(oUsu);
            Vista.MoveCurrentToLast();
            //Mostrar mensaje de exito
            MessageBox.Show("Usuario agregado correctamente.");
            //Habilitar botones
            btnEliminarUsuario.Visibility = Visibility.Visible;
            btnPrimero.Visibility = Visibility.Visible;
            btnPrevio.Visibility = Visibility.Visible;
            btnSiguiente.Visibility = Visibility.Visible;
            btnUltimo.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Captura los valores de los textbox y los asigna a un objeto de tipo usuario.
        /// </summary>
        /// <returns></returns>
        private Usuario CapturarInputs()
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Usu_Id = int.Parse(txtCodigo.Text);
            oUsuario.Usu_NombreUsuario = txtUserName.Text;
            oUsuario.Usu_Password = txtPassword.Text;
            oUsuario.Usu_ApellidoNombre = txtApellido.Text + "," + txtNombre.Text;
            oUsuario.Rol_Codigo = int.Parse(txtCodigo.Text);
            return oUsuario;
        }


        /// <summary>
        /// Limpia los valores del text box
        /// </summary>
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtPassword.Text = "";
            txtRol.Text = "";
            txtUserName.Text = "";
        }

        private void BtnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            btnEliminarUsuario.Visibility = Visibility.Hidden;
            btnPrimero.Visibility = Visibility.Hidden;
            btnPrevio.Visibility = Visibility.Hidden;
            btnSiguiente.Visibility = Visibility.Hidden;
            btnUltimo.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Visible;
            LimpiarCampos();
        }

        private void BtnPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void BtnUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void BtnPrevio_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            btnEliminarUsuario.Visibility = Visibility.Visible;
            btnPrimero.Visibility = Visibility.Visible;
            btnPrevio.Visibility = Visibility.Visible;
            btnSiguiente.Visibility = Visibility.Visible;
            btnUltimo.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
        }
    }
}
