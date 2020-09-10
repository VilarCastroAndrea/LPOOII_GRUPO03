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
        private int[,] mat;
        public WPFButaca()
        {
            InitializeComponent();
            butacas();
        }

        private void butacas()
        {

            int columnas = 20;
            int filas = 10;
            mat = new int[filas, columnas];
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
                    mat[i, j] = 0;
                    Button butaca = new Button();
                    butaca.Content = c + "," + (j + 1);
                    butaca.Click += Butaca_Click;
                    Grid.SetRow(butaca, i);
                    Grid.SetColumn(butaca, j);
                    grid.Children.Add(butaca);
                }
                validarAsientos();
            }

        }


        private void validarAsientos()
        {

            foreach (var item in grid.Children)
            {
                if (mat[obtenerFila(((Button)item).Content.ToString()), obtenerColumna(((Button)item).Content.ToString())] == 0)
                {
                    ((Button)item).Background = Brushes.Gray;
                }
                else
                {
                    if (mat[obtenerFila(((Button)item).Content.ToString()), obtenerColumna(((Button)item).Content.ToString())] == 1)
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


        private int obtenerFila(string filaColumna)
        {
            string[] valores = filaColumna.Split(',');
            int aux = char.Parse(valores[0]);
            return aux - 65;
        }
        private int obtenerColumna(string filaColumna)
        {
            string[] valores = filaColumna.Split(',');
            return int.Parse(valores[1]) - 1;
        }




        private void Butaca_Click(object sender, RoutedEventArgs e)
        {
            if (mat[obtenerFila(((Button)sender).Content.ToString()), obtenerColumna(((Button)sender).Content.ToString())] == 2)
                MessageBox.Show("Asiento Ocupado");
            else
            {
                if (mat[obtenerFila(((Button)sender).Content.ToString()), obtenerColumna(((Button)sender).Content.ToString())] == 1)
                {
                    mat[obtenerFila(((Button)sender).Content.ToString()), obtenerColumna(((Button)sender).Content.ToString())] = 0;
                }
                else
                {
                    mat[obtenerFila(((Button)sender).Content.ToString()), obtenerColumna(((Button)sender).Content.ToString())] = 1;
                }
            }
            validarAsientos();
        }


        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in grid.Children)
            {

                if (mat[obtenerFila(((Button)item).Content.ToString()), obtenerColumna(((Button)item).Content.ToString())] == 1)
                {
                    mat[obtenerFila(((Button)item).Content.ToString()), obtenerColumna(((Button)item).Content.ToString())] = 2;


                }


            }
            validarAsientos();
        }


    }
}

