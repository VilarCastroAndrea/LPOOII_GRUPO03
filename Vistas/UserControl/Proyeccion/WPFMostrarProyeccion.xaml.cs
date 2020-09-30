using System.Collections.Generic;
using System.Windows;

namespace Vistas.UserControl.Proyeccion

{
    /// <summary>
    /// Lógica de interacción para WPFAltaProyeccion.xaml
    /// </summary>
    public partial class WPFMostrarProyeccion
    {
        List<ClasesBase.Pelicula> listaPeliculas = new List<ClasesBase.Pelicula>();
        List<ClasesBase.Sala> listaSalas = new List<ClasesBase.Sala>();
        ClasesBase.Proyeccion proyeccionMostrar;
        WPFProyeccion proyeccionPadre;
        /// <summary>
        /// constructor con clase para modificar y clase padre para llamar a sus acciones
        /// </summary>
        /// <param name="verProyeccion"></param>
        /// <param name="proyeccion"></param>
        public WPFMostrarProyeccion(ClasesBase.Proyeccion verProyeccion, WPFProyeccion proyeccion)
        {
            proyeccionMostrar = verProyeccion;
            InitializeComponent();
            cargarPeliculas();
            cargarSalas();
            cargarComboPeliculas();
            cargarComboSalas();
            if (proyeccionMostrar != null)
            {
                txtFecha.Text = proyeccionMostrar.Proy_Fecha;
                txtHora.Text = proyeccionMostrar.Proy_Hora;
                txtSala.SelectedItem = proyeccionMostrar.Sla_NroSala.ToString();
                txtTitulo.SelectedItem = proyeccionMostrar.Peli_Codigo.ToString();
                proyeccionPadre = proyeccion;
            }


        }

        /// <summary>
        /// carga el combobox de peliculas
        /// </summary>
        private void cargarComboPeliculas()
        {
            txtTitulo.ItemsSource = listaPeliculas;
            txtTitulo.DisplayMemberPath = "Peli_Titulo";
            txtTitulo.SelectedValue = "Peli_Codigo";
            txtTitulo.SelectedIndex = 0;
        }

        /// <summary>
        /// carga el combobox de salas
        /// </summary>
        private void cargarComboSalas()
        {
            txtSala.ItemsSource = listaSalas;
            txtSala.DisplayMemberPath = "Sla_Descripcion";
            txtSala.SelectedValue = "Sla_NroSala";
            txtSala.SelectedIndex = 0;
        }



        /// <summary>
        /// genera salas estaticas
        /// </summary>
        private void cargarSalas()
        {
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


        /// <summary>
        /// llama al metodo de la clase padre para modificar una proyeccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //            MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea Modificar esta proyeccion?" + txtFecha.Text + ", " + txtHora.Text + ", " +
            //txtSala.Text + ", " + txtTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //            if (resultado == MessageBoxResult.Yes)
            //            {
            //                MessageBox.Show("Proyeccion Modificada con exito");
            //                //ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(0, txtFecha.Text, txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text));
            //                proyeccionPadre.modificarProyeccion(new ClasesBase.Proyeccion(proyeccionMostrar.Proy_Codigo, txtFecha.Text
            //                    , txtHora.Text, int.Parse(txtSala.SelectedIndex.ToString()), int.Parse(txtTitulo.SelectedIndex.ToString()), true));
            //            }
        }
        /// <summary>
        /// elimina una proyeccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBoja_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea borrar esta proyeccion?" + txtFecha.Text + ", " + txtHora.Text + ", " +
         txtSala.Text + ", " + txtTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {

                MessageBox.Show("Proyeccion Eliminada con exito");
                //ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(0, txtFecha.Text, txtHora.Text, int.Parse(txtSala.Text), int.Parse(txtTitulo.Text));
                proyeccionPadre.borrarProyeccion(new ClasesBase.Proyeccion(proyeccionMostrar.Proy_Codigo, txtFecha.Text
                    , txtHora.Text, int.Parse(txtSala.SelectedIndex.ToString()), int.Parse(txtTitulo.SelectedIndex.ToString()), true));
            }
        }
    }
}
