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

        private List<Ticket> listaDeTicketsVendidos = new List<Ticket>();
        private int[,] seleccionAsientos;
        private List<Butaca> listaDeButacas = new List<Butaca>();
        private List<Butaca> listaDeButacasSeleccionadas = new List<Butaca>();
        private ClasesBase.Proyeccion proyeccionSeleccionada;
        private int filasMax;
        private int columnasMax;
        private MainWindow ventanaPadre;


        public WPFTicketButaca(Ticket ticket, MainWindow padre)
        {
            InitializeComponent();
            ticket1 = ticket;
            proyeccionSeleccionada = TrabajarProyeccion.buscarProyeccion(ticket.Proy_Codigo);
            generarButacas();
            ventanaPadre = padre;
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtTotal.Text != "")
            {
                MessageBoxResult resultado = MessageBox.Show("¿Esta seguro que desea adquirir estas butacas?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    foreach (var item in grdButacas.Children)
                    {

                        if (seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] == 1)
                        {
                            seleccionAsientos[obtenerFilaBoton(((Button)item).Content.ToString()), obtenerColumnaBoton(((Button)item).Content.ToString())] = 2;
                            foreach (Butaca butaca in listaDeButacas)
                            {
                                if (((Button)item).Content.ToString().Contains(butaca.But_Fila) && ((Button)item).Content.ToString().Contains(butaca.But_Nro.ToString()))
                                {
                                    listaDeButacasSeleccionadas.Add(butaca);
                                }
                            }

                        }
                    }
                    validarAsientos();

                    foreach (Butaca butaca in listaDeButacasSeleccionadas)
                    {
                        ticket1.But_Id = butaca.But_Id;
                        ticket1.Tick_Precio = double.Parse(txtTotal.Text);
                        WPFTicketImpresion impresion = new WPFTicketImpresion(ticket1);
                        impresion.Show();
                    }

                    ventanaPadre.refrescarTicket();
                }
            }
            else
            {
                MessageBox.Show("DEBE COMPLETAR PRECIO", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void generarButacas()
        {
            //Determina la cantidad de filas y columnas que posee la sala
            columnasMax = 0;
            filasMax = 0;
            //TODO OBTENER BUTACA POR SALA DE PROYECCION:SALA
            listaDeButacas = TrabajarButaca.obtenerButacasPorSala(proyeccionSeleccionada.Sla_NroSala);
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
                grdButacas.ColumnDefinitions.Add(gridCol);
            }

            //crea las filas en el grid
            for (int i = 0; i < filasMax; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grdButacas.RowDefinitions.Add(gridRow);
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
                    grdButacas.Children.Add(butaca);
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

            int fila = 0;
            int columna = -1;
            listaDeTicketsVendidos = TrabajarTicket.traerTicketPorProyeccion(proyeccionSeleccionada.Proy_Codigo);
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
                        seleccionAsientos[obtenerFilaBoton(butaca.But_Fila), butaca.But_Nro-1] = 2;
                    }
                }
            }

        }

        /// <summary>
        /// valida todos los asientos en funcion de su disponibilidad con un color que represente la misma 
        /// </summary>
        private void validarAsientos()
        {

            foreach (var item in grdButacas.Children)
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
        int cantButaca = 0;

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
            {
                MessageBox.Show("Asiento Ocupado");
                MessageBoxResult resultado = MessageBox.Show("¿Desea liberar este aciento que ya fue vendido?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    foreach (Ticket ticketVendido in listaDeTicketsVendidos)
                    {
                        Butaca butacaVendida = TrabajarButaca.buscarButaca(ticketVendido.But_Id);

                        if (((Button)sender).Content.ToString().Contains(butacaVendida.But_Fila) && ((Button)sender).Content.ToString().Contains(butacaVendida.But_Nro.ToString()))
                        {
                            TrabajarTicket.bajaTicketFisica(ticketVendido.Tick_Nro);
                        }
                    }
                    seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 0;
                }
            }
            else
            {
                if (seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] == 1)
                {
                    seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 0;
                    cantButaca--;
                }
                else
                {
                    cantButaca++;
                    seleccionAsientos[obtenerFilaBoton(((Button)sender).Content.ToString()), obtenerColumnaBoton(((Button)sender).Content.ToString())] = 1;

                    
                }
                lblTotal.Text = (double.Parse(txtTotal.Text) * cantButaca).ToString();
            }
                validarAsientos();
        }



        }
    }
