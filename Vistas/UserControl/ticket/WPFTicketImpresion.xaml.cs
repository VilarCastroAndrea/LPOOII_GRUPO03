﻿using System;
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
using ClasesBase;

namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicketImpresion.xaml
    /// </summary>
    public partial class WPFTicketImpresion : Window
    {
        Ticket ticket1 = new Ticket();
        ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
        ClasesBase.Proyeccion proyeccion = new ClasesBase.Proyeccion();
        ClasesBase.Cliente cliente = new ClasesBase.Cliente();
        ClasesBase.Butaca butaca = new ClasesBase.Butaca();
        ClasesBase.Sala sala = new ClasesBase.Sala();

        public WPFTicketImpresion(Ticket ticket)
        {
            InitializeComponent();
            ticket1 = ticket;
            ticket1.Tick_FechaVenta = DateTime.Now;
            ticket1.Usu_Id = UsuarioLogin.usu_Id;
            proyeccion = TrabajarProyeccion.buscarProyeccion(ticket.Proy_Codigo);
            pelicula = TrabajarPelicula.buscarPelicula(proyeccion.Peli_Codigo.ToString());
            cliente = TrabajarClientes.buscarClientePorDni(ticket.Cli_DNI.ToString());
            butaca = TrabajarButaca.buscarButaca(ticket.But_Id);
            sala = TrabajarSala.buscarSala(proyeccion.Sla_NroSala.ToString());
            asignarVlores();
        }

        public void asignarVlores()
        {
            txtNroTicket.Text = (TrabajarTicket.altaTicket(ticket1)).ToString();
            txtFechaTicket.Text = DateTime.Now.ToString();
            txtnombrePelicula.Text = pelicula.Peli_Titulo;
            txtFecha.Text = proyeccion.Proy_Fecha;
            txtHora.Text = proyeccion.Proy_Hora;
            txtButaca.Text = butaca.But_Fila + butaca.But_Nro;
            txtApeliidoCliente.Text = cliente.Cli_Apellido;
            txtNombreCliente.Text = cliente.Cli_Nombre;
            txtDNICliente.Text = cliente.Cli_DNI.ToString();
            txtSala.Text = sala.Sla_Descripcion;
            txtPrecio.Text = ticket1.Tick_Precio.ToString()+ "$";
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog() == true)
            {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
                this.Close();
            }
        }
    }
}
