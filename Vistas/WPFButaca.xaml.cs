using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFButaca.xaml
    /// </summary>
    public partial class WPFButaca : UserControl
    {
        Style appButtonStyle = (Style)Application.Current.Resources["ButtonButaca"];

        //Matriz utilizada como bd ficticia
        private int[,] baseDeDatosFicticia;

        public WPFButaca()
        {
            InitializeComponent();
            butacas();
        }

        private void butacas()
        {

            int columnas = 15;
            int filas = 6;
            //inicializacion de la base de datos
            baseDeDatosFicticia = new int[filas, columnas];
            //codigo ascci de letra A
            int abc = 65;

            //crea las columnas en el grid
            for (int i = 0; i < columnas; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(gridCol);
            }

            //crea las filas en el grid
            for (int i = 0; i < filas; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }

            //agrega  los botones a la fila y columna correspondiente
            for (int i = 0; i < filas; i++)
            {
                char c = (char)(abc + i);
                for (int j = 0; j < columnas; j++)
                {
                    //inicializa los acientos como disponibles (0)
                    baseDeDatosFicticia[i, j] = 0;
                    //creacion de botones dinamicos dentro del bucle for
                    Button butaca = new Button();
                    butaca.Content = c + "," + (j + 1);
                    butaca.Width = 30;
                    butaca.Height = 30;
                    butaca.Style = appButtonStyle;
                    //asignacion del evento click en el boton dinamico
                    butaca.Click += Butaca_Click;
                    Grid.SetRow(butaca, i);
                    Grid.SetColumn(butaca, j);
                    grid.Children.Add(butaca);
                }
                validarAsientos();
            }

        }

        /// <summary>
        /// valida todos los asientos en funcion de su disponibilidad con un color que represente la misma 
        /// </summary>
        private void validarAsientos()
        {

            foreach (var item in grid.Children)
            {
                //Si el aciento no esta ocupado el boton obtendra un estilo que muestre su disponibilidad

                //Debido a que la informacion (fila y columna) se encuentra en el boton, tomo dicho 
                //boton y lo utilizo para consultar en la matriz su disponiibilidad 
                //(0 Disponible, 1 Seleccionado y 2 Ocupado) y le pone un color en funcion de la misma
                if (baseDeDatosFicticia[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 0)
                {
                    ((Button)item).Style = appButtonStyle;
                }
                else
                {
                    if (baseDeDatosFicticia[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 1)
                    {
                        ((Button)item).Background = Brushes.Green;
                    }
                    else
                    {
                        ((Button)item).Background = Brushes.Red;
                    }
                }

            }
        }

        /// <summary>
        /// al mandarle el contenido del boton a esta funcion devuelve la fila del boton
        /// </summary>
        /// <param name="botonFilaColumna"></param>
        /// <returns></returns>
        private int obtenerFilaBoton(string botonFilaColumna)
        {
            string[] valores = botonFilaColumna.Split(',');
            int aux = char.Parse(valores[0]);
            return aux - 65;
        }

        /// <summary>
        /// al mandarle el contenido del boton a esta funcion devuelve la columna del boton
        /// </summary>
        /// <param name="botonFilaColumna"></param>
        /// <returns></returns>
        private int obtenerColumnaBoton(string botonFilaColumna)
        {
            string[] valores = botonFilaColumna.Split(',');
            return int.Parse(valores[1]) - 1;
        }



        /// <summary>
        /// al hacer click en algun boton que representa las butacas
        /// verifica si el mismo esta oocupado, disponible y seleccionado para
        /// realizar una accion correspondiente ya sea mostrar un cartel de error o
        /// cambiar el color del boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Butaca_Click(object sender, RoutedEventArgs e)
        {
            if (baseDeDatosFicticia[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] == 2)
                MessageBox.Show("Asiento Ocupado");
            else
            {
                if (baseDeDatosFicticia[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] == 1)
                {
                    baseDeDatosFicticia[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 0;
                }
                else
                {
                    baseDeDatosFicticia[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 1;
                }
            }
            validarAsientos();
        }

        /// <summary>
        /// guarda los botones que fueron seleccionados y pasa su disponibilidad a ocupado
        /// una vez realizado eso vuellve a validar los asientos comparandolos con la bd ficticia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in grid.Children)
            {

                if (baseDeDatosFicticia[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 1)
                {
                    baseDeDatosFicticia[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] = 2;
                }


            }
            validarAsientos();
        }


    }
}
