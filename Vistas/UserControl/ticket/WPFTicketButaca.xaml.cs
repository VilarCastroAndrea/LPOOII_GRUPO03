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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;
namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicketButaca.xaml
    /// </summary>
    public partial class WPFTicketButaca 
    {
        Ticket ticket1 = new Ticket();
        Style appButtonStyle = (Style)Application.Current.Resources["ButtonButaca"];

        private int[,] seleccionAsientos;
        private List<Butaca> listaDeButacas = new List<Butaca>();
        private ClasesBase.Proyeccion proyeccionSeleccionada;
        private int filasMax;
        private int columnasMax;
        public WPFTicketButaca(Ticket ticket, ClasesBase.Proyeccion proyeccion)
        {
            InitializeComponent();
            ticket1 = ticket;
            generarButacas();
            proyeccionSeleccionada = proyeccion;
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            WPFTicketImpresion impresion = new WPFTicketImpresion(ticket1);
            impresion.Show();
        }

        private void generarButacas()
        {
            //Determina la cantidad de filas y columnas que posee la sala
            columnasMax = 0;
            filasMax = 0;
            //TODO OBTENER BUTACA POR SALA DE PROYECCION:SALA
            //listaDeButacas = TrabajarButaca.obtenerButacasPorSala(proyeccionSeleccionada.Sla_NroSala);
            listaDeButacas = TrabajarButaca.obtenerButacasPorSala(1);
            foreach (Butaca butaca in listaDeButacas)
            {
                if (butaca.But_Nro == 1)
                {
                    filasMax = filasMax + 1;
                }
                if (butaca.But_Nro > columnasMax)
                {
                    columnasMax = butaca.But_Nro;
                }


            }



            //inicializacion de 
            seleccionAsientos = new int[filasMax, columnasMax];

            //codigo ascci de letra A
            int abc = 65;

            //crea las columnas en el grid
            for (int i = 0; i < columnasMax; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(gridCol);
            }

            //crea las filas en el grid
            for (int i = 0; i < filasMax; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }




            inicializarSeleccionAsientos(seleccionAsientos, filasMax, columnasMax);
            cargarAsientos(seleccionAsientos);

            //agrega  los botones a la fila y columna correspondiente
            for (int i = 0; i < filasMax; i++)
            {
                char c = (char)(abc + i);
                for (int j = 0; j < columnasMax; j++)
                {
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

        private void inicializarSeleccionAsientos(int[,] seleccionAsientos, int filas, int columnas)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    seleccionAsientos[i, j] = 0;
                }
            }
        }

        private void cargarAsientos(int[,] seleccionAsientos)
        {
            List<Ticket> listaDeTicketsVendidos = new List<Ticket>();
            int fila = 0;
            int columna = -1;
            //listaDeTicketsVendidos = TrabajarTicket.traerTicketPorProyeccion(proyeccionSeleccionada.Proy_Codigo);
            listaDeTicketsVendidos = TrabajarTicket.traerTicketPorProyeccion(1);
            foreach (Butaca butaca in listaDeButacas)
            {
                columna++;
                if (columna > columnasMax)
                {
                    columna = 0;
                    fila++;
                }
                foreach (Ticket ticket in listaDeTicketsVendidos)
                {
                    if (butaca.But_Id == ticket.But_Id && seleccionAsientos[fila, columna] != 2)
                    {
                        seleccionAsientos[fila, columna] = 2;

                    }
                }
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
                if (seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 0)
                {
                    ((Button)item).Background = null;
                }
                else
                {
                    if (seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 1)
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
            if (seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] == 2)
                MessageBox.Show("Asiento Ocupado");
            else
            {
                if (seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] == 1)
                {
                    seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 0;
                }
                else
                {
                    seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 1;
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

                if (seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 1)
                {
                    seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] = 2;
                }
            }
            validarAsientos();
        }
        

        /// <summary>
        /// Devuelve una letra segun el numero que recibe por parametro
        /// </summary>
        /// <param name="numero">numero</param>
        /// <returns></returns>
        public string devolverLetra(int num)
        {
            char letra = ' ';
            if (num >= 0 && num <= 26)
            {
                num = num - 1;
                letra = (char)(num + 65);
            }
            else
            {
                MessageBox.Show("Debe ingresar un numero entre 1 y 26");
            }
            return letra.ToString();

        }
    }
}
