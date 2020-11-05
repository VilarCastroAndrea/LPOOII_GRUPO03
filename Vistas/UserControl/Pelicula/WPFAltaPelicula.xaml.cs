using Microsoft.Win32;
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

        }
        


        private void BtnAltaPelicula_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos() == true)
            {
                try
                {
                    ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
                    
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
            if (txtTitulo.Text == "" || txtDuracion.Text == "")
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
        }

        private void BtnExaminarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";

            openFileDialog1.DefaultExt = ".jpeg";

            txtImagen.Text = openFileDialog1.FileName;
        }

        private void BtnExaminarVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialogVideo = new OpenFileDialog();

            openFileDialogVideo.ShowDialog();

            openFileDialogVideo.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";

            openFileDialogVideo.DefaultExt = ".mp4";

            txtVideo.Text = openFileDialogVideo.FileName;
        }
    }
}
