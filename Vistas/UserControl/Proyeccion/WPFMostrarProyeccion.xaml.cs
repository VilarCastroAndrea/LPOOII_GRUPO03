
using System.Collections.Generic;
using System.Windows;

namespace Vistas.UserControl.Proyeccion

{
    using ClasesBase;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Controls;

    /// <summary>
    /// Lógica de interacción para WPFAltaProyeccion.xaml
    /// </summary>
    public partial class WPFMostrarProyeccion
    {
        ObservableCollection<Pelicula> listaPeliculas = new ObservableCollection<Pelicula>();
        ObservableCollection<Sala> listaSalas = new ObservableCollection<Sala>();
        Proyeccion proyeccionMostrar;
        WPFProyeccion proyeccionPadre;

        /// <summary>
        /// constructor con clase para modificar y clase padre para llamar a sus acciones
        /// </summary>
        /// <param name="verProyeccion"></param>
        /// <param name="proyeccion"></param>
        public WPFMostrarProyeccion(Proyeccion verProyeccion, WPFProyeccion proyeccion)
        {
            InitializeComponent();
            proyeccionPadre = proyeccion;
            proyeccionMostrar = verProyeccion;
            cargarComboPeliculas();
            cargarComboSalas();
            cargarFormulario();

        }

        /// <summary>
        /// Carga el formulario con una proyeccion seleccionada
        /// </summary>
        private void cargarFormulario()
        {
            try
            {
                txtFecha.Text = proyeccionMostrar.Proy_Fecha;
                txtHora.Text = proyeccionMostrar.Proy_Hora;

                //Seleccionar el cmb de SALAS
                Sala auxSala = listaSalas.First(s => s.Sla_NroSala == proyeccionMostrar.Sla_NroSala);
                cmbSala.SelectedIndex = listaSalas.IndexOf(auxSala);


                //Seleccionar el cmb de PELICULAS
                Pelicula auxPeli = listaPeliculas.First(p => p.Peli_Codigo == proyeccionMostrar.Peli_Codigo);
                cmbTitulo.SelectedIndex = listaPeliculas.IndexOf(auxPeli);
            }
            catch
            {
                System.Console.WriteLine("Error en Cargar formulario - modificar proyeccion");
            }
        }


        /// <summary>
        /// carga el combobox de peliculas
        /// </summary>
        private void cargarComboPeliculas()
        {
            listaPeliculas = TrabajarPelicula.traerPeliculas();
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
            listaSalas = TrabajarSala.traerSalas();
            cmbSala.ItemsSource = listaSalas;
            cmbSala.DisplayMemberPath = "Sla_Descripcion";
            cmbSala.SelectedValue = "Sla_NroSala";
            cmbSala.SelectedIndex = 0;
        }


        /// <summary>
        /// llama al metodo de la clase padre para modificar una proyeccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea Modificar esta proyeccion?" + txtFecha.Text + ", " + txtHora.Text + ", " +
            cmbSala.Text + ", " + cmbTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                Proyeccion nuevaProyeccion = new Proyeccion();
                nuevaProyeccion.Proy_Codigo = proyeccionMostrar.Proy_Codigo;
                nuevaProyeccion.Peli_Codigo = ((Pelicula)cmbTitulo.SelectedItem).Peli_Codigo;
                nuevaProyeccion.Proy_Disponible = proyeccionMostrar.Proy_Disponible;
                nuevaProyeccion.Proy_Fecha = txtFecha.Text;
                nuevaProyeccion.Proy_Hora = txtHora.Text;
                nuevaProyeccion.Sla_NroSala = ((Sala)cmbSala.SelectedItem).Sla_NroSala;

                TrabajarProyeccion.modificarProyeccion(nuevaProyeccion);
                
                proyeccionPadre.refrescarDataGrid();
                //proyeccionPadre.modificarProyeccion(nuevaProyeccion);
                LimpiarFormulario();
                MessageBox.Show("Proyeccion Modificada con exito");
            }
        }

        /// <summary>
        /// Limpia los campos del formulario y reinicia la instancia de proyeccionMostrar
        /// </summary>
        private void LimpiarFormulario()
        {
            proyeccionMostrar = new Proyeccion();
            cmbTitulo.SelectedIndex = 0;
            txtFecha.Text = "";
            txtHora.Text = "";
            cmbSala.SelectedIndex = 0;
        }

        /// <summary>
        /// elimina una proyeccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBoja_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea borrar esta proyeccion?" + txtFecha.Text + ", " + txtHora.Text + ", " +
         cmbSala.Text + ", " + cmbTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                TrabajarProyeccion.bajaProyeccionFisica(proyeccionMostrar.Proy_Codigo);
                proyeccionPadre.refrescarDataGrid();
                LimpiarFormulario();
                MessageBox.Show("Proyeccion Eliminada con exito");
            }
        }

        /// <summary>
        /// Muestra informacion de la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMasInfo_Click(object sender, RoutedEventArgs e)
        {
            WPFMasInformacion masInfo = new WPFMasInformacion(proyeccionMostrar);
            masInfo.Show();
        }
    }
}
