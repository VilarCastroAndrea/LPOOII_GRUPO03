using ClasesBase;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

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
            listaSalas.Add(new ClasesBase.Sala(1, 15, "Prueba 1"));
            listaSalas.Add(new ClasesBase.Sala(2, 20, "Prueba 2"));
            listaSalas.Add(new ClasesBase.Sala(3, 30, "Prueba 3"));
        }

        /// <summary>
        /// genera peliculas al de forma estatica
        /// </summary>
        private void cargarPeliculas()
        {
            listaPeliculas.Add(new ClasesBase.Pelicula(1,"Shreck","12:00",1,1,""));
            listaPeliculas.Add(new ClasesBase.Pelicula(2, "La Mascara", "12:00", 1, 1, ""));
            listaPeliculas.Add(new ClasesBase.Pelicula(3, "Mulan", "12:00", 1, 1, ""));
        }

        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (validarCamposVacios() != true)
            {
                MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtFecha.Text + ", " + txtHora.Text + ", " +
             txtSala.Text + ", " + txtTitulo.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {

                    MessageBox.Show("Proyeccion Guardada con exito");
                    ClasesBase.Proyeccion nuevaProyeccion = new ClasesBase.Proyeccion(0, txtFecha.Text, txtHora.Text, int.Parse(txtSala.SelectedIndex.ToString()), int.Parse(txtTitulo.SelectedIndex.ToString()));
                    proyeccionPadre.agregarProyeccion(nuevaProyeccion);
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
            txtSala.Text = "";
            txtTitulo.Text = "";
        }


        private bool validarCamposVacios()
        {
            if (txtFecha.Text == "" && txtHora.Text == "" && txtSala.Text == "" && txtTitulo.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
