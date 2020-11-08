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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas.UserControl.ticket
{
    /// <summary>
    /// Lógica de interacción para WPFTicket.xaml
    /// </summary>
    public partial class WPFTicket 
    {
        Ticket ticket = new Ticket();
        
        public WPFTicket()
        {
            InitializeComponent();
            panelTicket.Children.Clear();
            panelTicket.Children.Add(new WPFTicketProyeccion(this));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panelTicket.Children.Clear();
            panelTicket.Children.Add(new WPFTicketProyeccion(this));
        }

        private void BtnCLiente_Click(object sender, RoutedEventArgs e)
        {
            panelTicket.Children.Clear();
            panelTicket.Children.Add(new WPFTicketCliente(this));
        }

        private void BtnButaca_Click(object sender, RoutedEventArgs e)
        {
            panelTicket.Children.Clear();
            panelTicket.Children.Add(new WPFTicketButaca(ticket));
        }

        public void cargarProyeccion(int ticketProyeccion)
        {
            ticket.Proy_Codigo = ticketProyeccion;
        }

        public void cargarCliente(int DNI)
        {
            ticket.Cli_DNI = DNI;
        }
    }
}
