using System.Collections.Generic;

namespace Vistas.UserControl.Proyeccion
{
    using ClasesBase;
    using System;
    using System.Windows;

    /// <summary>
    /// Lógica de interacción para WPFMostrarProyeccion.xaml
    /// </summary>
    public partial class WPFAltaProyeccion
    {
        /// <summary>
        /// Referencia al UserControl Padre.
        /// </summary>
        private WPFProyeccion proyeccionPadre;

        public WPFAltaProyeccion(WPFProyeccion proyeccion)
        {
            proyeccionPadre = proyeccion;
            InitializeComponent();
            limpiarCampos();
            cargarComboPeliculas();
            cargarComboSalas();
        }
        /// <summary>
        /// carga el combobox de peliculas
        /// </summary>
        private void cargarComboPeliculas()
        {
            cmbTitulo.ItemsSource = TrabajarPelicula.TraerPeliculasDisponibles();
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

        /// <summary>
        /// Boton Alta, Genera un mensaje de confirmacion para agregar una PROYECCION
        /// De aceptar se guardaran los datos formularios en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCamposVacios() != true)
            {
                MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtFecha.Text + ", " + txtHora.Text + ", " +
             cmbSala.Text + ", " + cmbTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    DateTime date = ConvertToDateTime(txtFecha.Text);
                    if (date.CompareTo(DateTime.Today) >= 0)
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
                        limpiarCampos();
                        proyeccionPadre.refrescarDataGrid();
                        proyeccionPadre.ResetVentana();
                    }
                    else
                    {
                        MessageBox.Show("La fecha no debe ser menor al dia de hoy");
                    }
                }
            }
            else
            {
             MessageBox.Show("Formulario Incompleto");
            }
        }

        /// <summary>
        /// Convierte una fecha en formato STRING a DATETIME
        /// </summary>
        /// <param name="value">Fecha en formato string</param>
        /// <returns></returns>
        private DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate = new DateTime();
            try
            {
                convertedDate = Convert.ToDateTime(value);
            }
            catch
            {
                MessageBox.Show("Fecha Invalida");
            }
            return convertedDate;
        }

        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        private void limpiarCampos()
        {
            txtFecha.Text = "";
            txtHora.Text = "";
            cmbSala.Text = "";
            cmbTitulo.Text = "";
        }

        /// <summary>
        /// Verifica que los campos no  esten vacios.
        /// </summary>
        /// <returns></returns>
        private bool validarCamposVacios()
        {
            if (txtFecha.Text == "" || txtHora.Text == "" || cmbSala.Text == "" || cmbTitulo.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
