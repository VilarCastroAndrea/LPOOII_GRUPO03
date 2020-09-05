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

            int columnas = 20;
            int filas = 10;
            //codigo ascci de letra A
            int abc = 65; 

            //crea las columnas en el grid
            for (int i=0; i<columnas;i++) {
                ColumnDefinition gridCol = new ColumnDefinition();
                 grid.ColumnDefinitions.Add(gridCol);
            }

            //crea las filas en el grid
            for (int i = 0; i < filas; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }


            string ocupado1 = "A1";
            string ocupado2 = "C6";
            string ocupado3 = "C7";
            //agrega  los botones a la fila y columna correspondiente
            for (int i=0; i<filas; i++) {
                char c = (char) (abc+i);
                for (int j=0; j<columnas; j++) {
                    Button butaca = new Button();
                    butaca.Content = c +" "+ (j+1);
                    butaca.Name = c +""+(j + 1);
                    butaca.Background = Brushes.LightGray;
                    butaca.BorderBrush = Brushes.White;
                    //controla butacas ocupadas hardcodeado
                    if (ocupado1.Equals(butaca.Name) || (ocupado2.Equals(butaca.Name)||(ocupado3.Equals(butaca.Name) ) )) {
                        butaca.Background = Brushes.Red;
                    }

                    //evento clic para cada boton
                    butaca.Click += (s, e) => {
                        MessageBox.Show("Soy el boton :"+ butaca.Name);

                        //colores de butacas segun ocupacion, seleccion, y desocupado
                         if (butaca.Background == Brushes.LightGray)
                        {
                            butaca.Background = Brushes.Green;
                        }
                        else {
                            if (butaca.Background == Brushes.Green)
                            {
                                butaca.Background = Brushes.LightGray;
                            }
                            else {
                                MessageBox.Show("No puedes seleccionar esta butaca, ya esta ocupada");
                            }
                        }
                       
                    };

                    Grid.SetRow(butaca, i);
                    Grid.SetColumn(butaca, j);
                    grid.Children.Add(butaca);
                }
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
