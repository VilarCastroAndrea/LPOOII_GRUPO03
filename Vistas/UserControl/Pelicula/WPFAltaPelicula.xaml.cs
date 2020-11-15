﻿using Microsoft.Win32;
using System;
using System.Windows;

namespace Vistas.UserControl.Pelicula
{
    /// <summary>
    /// Lógica de interacción para WPFAltaPelicula.xaml
    /// </summary>
    public partial class WPFAltaPelicula
    {
 
        public string name { get; set; }

        WPFPelicula padre;

        public WPFAltaPelicula(WPFPelicula formularioPadre)
        {
            InitializeComponent();
            padre = formularioPadre;
            txtTitulo.Text = "";
            txtDuracion.Text = "";
        }
        


        private void BtnAltaPelicula_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                try
                {
                    ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
                  // pelicula.Peli_Codigo = peliculaSeleccionada.Peli_Codigo; ;
                    pelicula.Peli_Titulo = txtTitulo.Text;
                    pelicula.Peli_Duracion = txtDuracion.Text;
                    pelicula.Peli_Genero = cmbGenero.Text;
                    pelicula.Peli_Clasificacion = cmbClasificacion.Text;
                    pelicula.Peli_Imagen = txtImagen.Text;
                    pelicula.Peli_Avance = txtVideo.Text;
                    pelicula.Peli_Disponible = true;


                    padre.altaPelicula(pelicula);
                    MessageBoxResult resultado = MessageBox.Show("Se agrego la pelicula con exito", "Atención");
                    //limpiarCampos();
                }
                catch(Exception error)
                {
                    MessageBoxResult resultado = MessageBox.Show("Error al realizar el alta de Pelicula ", "Atención");
                }
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            }
        }

        private bool validarCampos()
        {
            if (txtTitulo.Text == "" || txtTitulo.Text.Length < 5 || txtDuracion.Text == "" || txtDuracion.Text.Length < 5 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiarCampos()
        {
            txtTitulo.Text = "";
            txtDuracion.Text = "";
            txtImagen.Text = "";
            txtVideo.Text = "";
            cmbClasificacion.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
        }

        private void BtnExaminarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // openFileDialog1.ShowDialog();

            // openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";

            //  openFileDialog1.DefaultExt = ".jpeg";

            openFileDialog1.Filter = "Jpg Files |*.jpg; *.png;";
            openFileDialog1.ShowDialog();

            txtImagen.Text = openFileDialog1.FileName;
        }

        private void BtnExaminarVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // openFileDialog.ShowDialog();

            // openFileDialog.Filter = "Pdf Files|*.pdf";

            //openFileDialog.DefaultExt = ".jpeg";

            openFileDialog.Filter = "Mp4 Files|*.mp4";
            openFileDialog.ShowDialog();

            txtVideo.Text = openFileDialog.FileName;
        }
    }
}
