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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Configuration;
using System.Collections.Specialized;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaConfig.xaml
    /// </summary>
    public partial class VentanaConfig : Window
    {
        

        public VentanaConfig()
        {
            InitializeComponent();
            Console.WriteLine("TRUUUUEEEEE "+true.ToString());
            CargarConfiguracion();
        }

        /// <summary>
        /// Carga la configuracion establecida en app.config
        /// </summary>
        private void CargarConfiguracion()
        {
            string chkValor = ConfigurationManager.AppSettings.Get("reproducirSonidos");
            string urlSonido = ConfigurationManager.AppSettings.Get("URLSonidoInicial");

            //Carga el checkbox
            chkSonarInicio.IsChecked = chkValor.Equals(true.ToString());

            //Carga la url del la cancion.
            Uri uriAux;
            if(Uri.TryCreate(urlSonido, UriKind.Absolute, out uriAux))
            {
                string pathMp3 = uriAux.AbsolutePath;
                lblCancion.Content = "Sonido: " + pathMp3;
                CargarMedia(pathMp3);
            }
            else
            {
                lblCancion.Content = "Sonido:";
            }
        }

        /// <summary>
        /// Boton para cargar un archivo mp3.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileMp3 = new OpenFileDialog();

            fileMp3.Filter = "Musica mp3(*.mp3)|*.mp3";
            if (fileMp3.ShowDialog() == true)
            {
                string pathMp3 = fileMp3.FileName;

                //Guardar en app.config
                ConfigurationManager.AppSettings.Set("URLSonidoInicial", pathMp3);

                //Carga el MediaElement
                CargarMedia(pathMp3);
            }
        }

        /// <summary>
        /// Carga el reproductor media con un archivo MP3.
        /// </summary>
        /// <param name="pathExistente">URL existente del archivo mp3</param>
        private void CargarMedia(string pathExistente)
        {
            lblCancion.Content += pathExistente;
            media.LoadedBehavior = MediaState.Manual;
            media.Source = new Uri(pathExistente);
        }

        /// <summary>
        /// Boton de pausa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        /// <summary>
        /// Boton de Parar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        /// <summary>
        /// Boton de Reproducir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        /// <summary>
        /// Guarda el valor del chk y nada mas por ahora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string chkValor = chkSonarInicio.IsChecked.Value.ToString();
            ConfigurationManager.AppSettings.Set("reproducirSonidos", chkValor);
        }
    }
}
