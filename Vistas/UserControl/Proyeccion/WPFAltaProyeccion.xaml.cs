using System.Collections.Generic;

namespace Vistas.UserControl.Proyeccion
{

    /// <summary>
    /// Lógica de interacción para WPFMostrarProyeccion.xaml
    /// </summary>
    public partial class WPFAltaProyeccion
    {
        private WPFProyeccion proyeccionPadre;

        List<ClasesBase.Pelicula> listaPeliculas = new List<ClasesBase.Pelicula>();
        List<ClasesBase.Sala> listaSalas = new List<ClasesBase.Sala>();
        public WPFAltaProyeccion(WPFProyeccion proyeccion)
        {
            proyeccionPadre = proyeccion;
            InitializeComponent();
            cargarPeliculas();
            cargarSalas();
            cargarComboPeliculas();
            cargarComboSalas();
        }
        /// <summary>
        /// carga el combobox de peliculas
        /// </summary>
        private void cargarComboPeliculas()
        {
            cmbTitulo.ItemsSource = listaPeliculas;
            cmbTitulo.DisplayMemberPath = "Peli_Titulo";
            cmbTitulo.SelectedValue = "Peli_Codigo";
            cmbTitulo.SelectedIndex = 0;
        }

        /// <summary>
        /// carga el combobox de salas
        /// </summary>
        private void cargarComboSalas()
        {
            cmbSala.ItemsSource = listaSalas;
            cmbSala.DisplayMemberPath = "Sla_Descripcion";
            cmbSala.SelectedValue = "Sla_NroSala";
            cmbSala.SelectedIndex = 0;
        }


        /// <summary>
        /// genera salas estaticas
        /// </summary>
        private void cargarSalas()
        {
            //Traer un 
            //listaSalas.Add(new ClasesBase.Sala(1, 15, "Prueba 1"));
            //listaSalas.Add(new ClasesBase.Sala(2, 20, "Prueba 2"));
            //listaSalas.Add(new ClasesBase.Sala(3, 30, "Prueba 3"));
        }

        /// <summary>
        /// genera peliculas al de forma estatica
        /// </summary>
        private void cargarPeliculas()
        {
            //listaPeliculas.Add(new ClasesBase.Pelicula(1, "Shreck", "12:00", 1, 1, ""));
            //listaPeliculas.Add(new ClasesBase.Pelicula(2, "La Mascara", "12:00", 1, 1, ""));
            //listaPeliculas.Add(new ClasesBase.Pelicula(3, "Mulan", "12:00", 1, 1, ""));
        }

        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (validarCamposVacios() != true)
            //{
            //    MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtFecha.Text + ", " + txtHora.Text + ", " +
            // cmbSala.Text + ", " + cmbTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    if (resultado == MessageBoxResult.Yes)
            //    {

            //        MessageBox.Show("Proyeccion Guardada con exito");
            //        ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(proyeccionPadre.index++, txtFecha.Text, txtHora.Text, int.Parse(cmbSala.SelectedIndex.ToString()), int.Parse(cmbTitulo.SelectedIndex.ToString()));
            //        proyeccionPadre.agregarProyeccion(nuevaProyeccion);
            //        limpiarCampos();
            //    }
            //}
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
