using System.Collections.Generic;

namespace Vistas.UserControl.Proyeccion
{
    using ClasesBase;
    using System.Windows;

    /// <summary>
    /// Lógica de interacción para WPFMostrarProyeccion.xaml
    /// </summary>
    public partial class WPFAltaProyeccion
    {
        private WPFProyeccion proyeccionPadre;

        public WPFAltaProyeccion(WPFProyeccion proyeccion)
        {
            proyeccionPadre = proyeccion;
            InitializeComponent();
            cargarComboPeliculas();
            cargarComboSalas();
        }
        /// <summary>
        /// carga el combobox de peliculas
        /// </summary>
        private void cargarComboPeliculas()
        {
            cmbTitulo.ItemsSource = TrabajarPelicula.traerPeliculas();
            cmbTitulo.DisplayMemberPath = "Peli_Titulo";
            cmbTitulo.SelectedValue = "Peli_Codigo";
            cmbTitulo.SelectedIndex = 0;
        }

        /// <summary>
        /// carga el combobox de salas
        /// </summary>
        private void cargarComboSalas()
        {
            cmbSala.ItemsSource = TrabajarSala.traerSalas();
            cmbSala.DisplayMemberPath = "Sla_Descripcion";
            cmbSala.SelectedValue = "Sla_NroSala";
            cmbSala.SelectedIndex = 0;
        }

        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCamposVacios() != true)
            {
                MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtFecha.Text + ", " + txtHora.Text + ", " +
             cmbSala.Text + ", " + cmbTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    //Carga los inputs
                    Proyeccion nuevaProyeccion = new Proyeccion();
                    nuevaProyeccion.Peli_Codigo = ((Pelicula)cmbTitulo.SelectedValue).Peli_Codigo;
                    nuevaProyeccion.Proy_Disponible = true;
                    nuevaProyeccion.Proy_Fecha = txtFecha.Text;
                    nuevaProyeccion.Proy_Hora = txtHora.Text;
                    nuevaProyeccion.Sla_NroSala = ((Sala)cmbSala.SelectedValue).Sla_NroSala;

                    //Agrega a la base de datos
                    TrabajarProyeccion.altaProyeccion(nuevaProyeccion);

                    MessageBox.Show("Proyeccion Guardada con exito");

                    //Agrega en el data grid
                    proyeccionPadre.refrescarDataGrid();
                    limpiarCampos();
                }
            }
        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void limpiarCampos()
        {
            txtFecha.Text = "";
            txtHora.Text = "";
            cmbSala.Text = "";
            cmbTitulo.Text = "";
        }


        private bool validarCamposVacios()
        {
            if (txtFecha.Text == "" && txtHora.Text == "" && cmbSala.Text == "" && cmbTitulo.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
