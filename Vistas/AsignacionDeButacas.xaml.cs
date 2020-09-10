using ClasesBase;
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

namespace Vistas
{

    /// <summary>
    /// Lógica de interacción para AsignacionDeButacas.xaml
    /// </summary>
    public partial class AsignacionDeButacas : UserControl
    {

        private int[,] mat;

        private Celda[,] celdas;

        private List<Butaca> butacasVendidas = new List<Butaca>();
        private List<Celda> celdasSelec = new List<Celda>();

        public AsignacionDeButacas()
        {
            InitializeComponent();
            CrearButacas();
           
        }


        private void CrearButacas() {

            int columnas = 20;
            int filas = 10;
            celdas = new Celda[filas, columnas];
            //mat = new int[filas, columnas];
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

            for(int i = 0; i < filas; i++)
            {
                char c = (char)(abc + i);
                for (int j = 0; j < columnas; j++)
                {
                    //Celda cel = new Celda();
                    //cel = celdas[i, j];
                    celdas[i, j] = new Celda();
                    celdas[i, j].IniciarButaca(new Butaca(c.ToString(), j+1 , 1), new Button());

                    celdas[i, j].BotonAsociado.Click += Butaca_Click;

                    Grid.SetRow(celdas[i, j].BotonAsociado, i);
                    Grid.SetColumn(celdas[i, j].BotonAsociado, j);
                    grid.Children.Add(celdas[i, j].BotonAsociado);
                }
            }
            validarAsientos();

        }

        private void validarAsientos()
        {
            //ANTES Obtener listado de butacas vendidas de la base de datos
           // IF AUXILIAR PARA DEMOSTRAR
           if(butacasVendidas.Count == 0)
            {
                butacasVendidas.Add(new Butaca("C", 3, 1));
                butacasVendidas.Add(new Butaca("C", 4, 1));
            }
            

            foreach (Butaca but in butacasVendidas)
            {
                int fil = char.Parse(but.But_Fila) - 64 - 1;
                int col = but.But_Nro - 1;
                celdas[fil, col].OcuparButaca();
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
            Brush color =  ((Button)sender).Background;
            if (color.Equals(Brushes.Red))
            {
                MessageBox.Show("Asiento Ocupado");
            }
            else
            {
                int fila = Grid.GetRow((Button)sender);
                int col = Grid.GetColumn((Button)sender);

                //Si el color de la celda es gris se guarda como posible compra
                if (color.Equals(Brushes.Gray))
                {
                    celdas[fila, col].SeleccionarButaca();
                    celdasSelec.Add(celdas[fila, col]);
                }
                //Si el boton es verde se vuelve a gris y se elimina de posible compra
                else if(color.Equals(Brushes.Green))
                {
                    celdas[fila, col].LiberarButaca();
                    celdasSelec.Remove(celdas[fila, col]);
                }

            }
        }


        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            foreach(Celda cel in celdasSelec)
            {
                cel.Butaca.But_Disponible = false;
                //Se guarda en la BD
                butacasVendidas.Add(cel.Butaca);
            }
            validarAsientos();
        }


    }
}
