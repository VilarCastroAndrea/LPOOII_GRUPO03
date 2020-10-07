using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Vistas.UserControl.Pelicula
{
    /// <summary>
    /// Lógica de interacción para WPFAltaPelicula.xaml
    /// </summary>
    public partial class WPFAltaPelicula
    {
        //Clasificacion clasificacion = new Clasificacion();
        //Genero genero = new Genero();
        //ArrayList clasificaciones = new ArrayList();
        //List<Genero> generos = new List<Genero>();
        public WPFAltaPelicula()
        {
            InitializeComponent();
            //crearClasificaciones();
            //cargarComboClasificacion();
            //crearGeneros();
            //cargarComboGenero();
        }

        //private void crearGeneros()
        //{
        //    generos.Add(new Genero(0, "Comedia"));
        //    generos.Add(new Genero(1, "Terror"));
        //    generos.Add(new Genero(2, "Ciencia Ficcion"));
        //    generos.Add(new Genero(3, "Musicales"));
        //}

        //private void cargarComboGenero()
        //{
        //    cmbGenero.ItemsSource = generos;
        //    cmbGenero.DisplayMemberPath = "Gnr_Descripcion";
        //    cmbGenero.SelectedValue = "Gnr_Id";
        //    cmbGenero.SelectedIndex = 0;
        //}

        //private void crearClasificaciones()
        //{
        //    clasificaciones.Add(new Clasificacion(0, "A"));
        //    clasificaciones.Add(new Clasificacion(1, "B"));
        //    clasificaciones.Add(new Clasificacion(2, "B15"));
        //    clasificaciones.Add(new Clasificacion(3, "C"));
        //}

        //private void cargarComboClasificacion()
        //{
        //    cmbClasificacion.ItemsSource = clasificaciones;
        //    cmbClasificacion.DisplayMemberPath = "Cls_Descripcion";
        //    cmbClasificacion.SelectedValue = "Cls_Id";
        //    cmbClasificacion.SelectedIndex = 0;
        //}

        private void BtnAltaPelicula_Click(object sender, RoutedEventArgs e)
        {
            //if (validarCampos() == true)
            //{
            //    MessageBoxResult resultado = MessageBox.Show("Los siguientes datos son correctos? " + txtTitulo.Text + ", " + txtDuracion.Text + ", " +
            //    Int32.Parse(cmbGenero.SelectedIndex.ToString()) + ", " + Int32.Parse(cmbClasificacion.SelectedIndex.ToString()) + ", " + txtImagenPeli.Text, "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    if (resultado == MessageBoxResult.Yes)
            //    {
            //        MessageBox.Show("Pelicula Guardado con exito");
            //        //Pelicula nuevaPelicula = new Pelicula(0, txtTitulo.Text, txtDuracion.Text, Int32.Parse(cmbGenero.SelectedIndex.ToString()), Int32.Parse(cmbClasificacion.SelectedIndex.ToString()), txtImagenPeli.Text);
            //    }
            //    limpiarCampos();
            //}
            //else
            //{
            //    MessageBoxResult resultado = MessageBox.Show("Formulario incompleto ", "Atención");
            //}

        }

        private bool validarCampos()
        {
            if (txtTitulo.Text == "" || txtDuracion.Text == "" || txtImagenPeli.Text == "")
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
            txtImagenPeli.Text = "";
        }

        private void ExaminarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp”";
            openFileDialog1.DefaultExt = ".jpeg";
            txtImagenPeli.Text = openFileDialog1.FileName;
            Image.Source = new BitmapImage(new System.Uri(openFileDialog1.FileName));
        }

        /// <summary>
        /// REVISAR NO TERMINADO!
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        public string EncodeImage(Image imagen)
        {
            return "qwe";
        }
    }
}
