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
            TrabajarUsuario.InsertarUsuario(oUsu);
            //Actualizar la lista
            //listaUsuarios = TrabajarUsuario.TraerUsuarios();
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
            btnModificarUsuario.Visibility = Visibility.Visible;
            //Cambiar los textbox
            stpFormulario.Visibility = Visibility.Hidden;
            stpContent.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Captura los valores de los textbox y los asigna a un objeto de tipo usuario.
        /// </summary>
        /// <returns></returns>
        private Usuario CapturarInputs()
        {
            Usuario oUsuario = new Usuario();
            //if (!String.IsNullOrEmpty(txtCodigo.Text))
            //{
            //    oUsuario.Usu_Id = int.Parse(txtCodigo.Text);
            //}
            oUsuario.Usu_NombreUsuario = txtUserNameFrm.Text;
            oUsuario.Usu_Password = txtPasswordFrm.Text;
            oUsuario.Usu_ApellidoNombre = txtApellidoFrm.Text + "," + txtNombreFrm.Text;
            oUsuario.Rol_Codigo = int.Parse(txtRolFrm.Text);
            return oUsuario;
        }


        /// <summary>
        /// Limpia los valores del text box
        /// </summary>
        private void LimpiarCampos()
        {
            txtApellidoFrm.Text = "";
            txtNombreFrm.Text = "";
            txtPasswordFrm.Text = "";
            txtRolFrm.Text = "";
            txtUserNameFrm.Text = "";
        }

        private void BtnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            //Prepara los botones de la vista
            stpContent.Visibility = Visibility.Hidden;
            stpFormulario.Visibility = Visibility.Visible;
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
            //Prepara la visibilidad de los botones
            //Botones de operaciones
            stpContent.Visibility = Visibility.Visible;
            stpFormulario.Visibility = Visibility.Hidden;
            btnEliminarUsuario.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardarModificacion.Visibility = Visibility.Hidden;
            btnGuardarUsuario.Visibility = Visibility.Hidden;

            //Botones de navegacion
            HabilitarNavegacion();
            
        }

        private void BtnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            //Asigna los valores del usuario existente en un formulario para editar
            txtApellidoFrm.Text = txtApellido.Text;
            txtNombreFrm.Text = txtNombre.Text;
            txtPasswordFrm.Text = txtPassword.Text;
            txtRolFrm.Text = txtRol.Text;
            txtUserNameFrm.Text = txtUserName.Text;

            //Prepara los botones de la vista
            //Botones de Operaciones
            btnCancelar.Visibility = Visibility.Visible;
            btnNuevoUsuario.Visibility = Visibility.Hidden;
            btnGuardarUsuario.Visibility = Visibility.Hidden;
            btnModificarUsuario.Visibility = Visibility.Hidden;
            btnGuardarModificacion.Visibility = Visibility.Visible;
            btnEliminarUsuario.Visibility = Visibility.Hidden;

            //Botones de Navegación
            DeshabilitarNavegacion();
            
        }

        private void BtnGuardarModificacion_Click(object sender, RoutedEventArgs e)
        {
            //Capturar los valores del textbox
            Usuario oUsu = CapturarInputs();
            oUsu.Usu_Disponible = true;
            //Guardar Usuario en la bd
            TrabajarUsuario.ActualizarUsuario(oUsu);
            //Actualizar la lista

            //Mostrar mensaje de exito
            MessageBox.Show("Usuario actualizado correctamente.");

            //Habilitar botones
            //Botones de Operaciones
            btnCancelar.Visibility = Visibility.Hidden;
            btnModificarUsuario.Visibility = Visibility.Visible;
            btnGuardarModificacion.Visibility = Visibility.Hidden;
            btnEliminarUsuario.Visibility = Visibility.Visible;

            //Botones de Navegación
            HabilitarNavegacion();

            //Cambiar los textbox
            stpFormulario.Visibility = Visibility.Hidden;
            stpContent.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Habilita los botones de navegación de la vista
        /// </summary>
        private void HabilitarNavegacion()
        {
            //Botones de Navegación
            btnPrimero.Visibility = Visibility.Visible;
            btnPrevio.Visibility = Visibility.Visible;
            btnSiguiente.Visibility = Visibility.Visible;
            btnUltimo.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Deshabilita los botones de navegación de la vista
        /// </summary>
        private void DeshabilitarNavegacion()
        {
            //Botones de Navegación
            btnPrimero.Visibility = Visibility.Hidden;
            btnPrevio.Visibility = Visibility.Hidden;
            btnSiguiente.Visibility = Visibility.Hidden;
            btnUltimo.Visibility = Visibility.Hidden;
        }
    }
}
