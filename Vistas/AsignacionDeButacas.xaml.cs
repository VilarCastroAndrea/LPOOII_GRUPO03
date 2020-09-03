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
    public partial class AsignacionDeButacas : Window
    {
       

        public AsignacionDeButacas()
        {
            InitializeComponent();
            butacas();
           
        }


        private void butacas() {

            int columnas = 5;
            int filas = 5;

            //creacion de las columnas en el grid
            for (int i=0; i<columnas;i++) {
                ColumnDefinition gridCol = new ColumnDefinition();
                 grid.ColumnDefinitions.Add(gridCol);
            }

            //columns
            /*
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);
            grid.ColumnDefinitions.Add(gridCol3);
            */

            //creacion de las filas en el grid
            for (int i = 0; i < filas; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }


            //rows
            /*
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            grid.RowDefinitions.Add(gridRow1);
            grid.RowDefinitions.Add(gridRow2);
            grid.RowDefinitions.Add(gridRow3);
            */



            //agrega  los botones a la fila y columna correspondiente
            int abc = 65;

            for (int i=0; i<filas; i++) {
                char c = (char) (abc+i);
                for (int j=0; j<columnas; j++) {
                    Button butaca = new Button();
                    butaca.Content = c +" "+ (j+1);
                    Grid.SetRow(butaca, i);
                    Grid.SetColumn(butaca, j);
                    grid.Children.Add(butaca);
                }
            }




            // Add second column header    
            /*
            Button butaca1 = new Button();
            butaca1.Content = "butaca1";
            Grid.SetRow(butaca1, 0);
            Grid.SetColumn(butaca1, 0);

            Button butaca2 = new Button();
            butaca2.Content = "butaca2";
            Grid.SetRow(butaca2, 0);
            Grid.SetColumn(butaca2, 1);

            Button butaca3 = new Button();
            butaca3.Content = "butaca3";
            Grid.SetRow(butaca3, 0);
            Grid.SetColumn(butaca3, 2);

            ///////////
            Button butaca4 = new Button();
            butaca4.Content = "butaca4";
            Grid.SetRow(butaca4, 1);
            Grid.SetColumn(butaca4, 0);

            Button butaca5 = new Button();
            butaca5.Content = "butaca5";
            Grid.SetRow(butaca5, 1);
            Grid.SetColumn(butaca5, 1);

            Button butaca6 = new Button();
            butaca6.Content = "butaca6";
            Grid.SetRow(butaca6, 1);
            Grid.SetColumn(butaca6, 2);



            //// Add column headers to the Grid    
            ///
            grid.Children.Add(butaca1);
            grid.Children.Add(butaca2);
            grid.Children.Add(butaca3);
            grid.Children.Add(butaca4);
            grid.Children.Add(butaca5);
            grid.Children.Add(butaca6);
            */

        }

    }
}
