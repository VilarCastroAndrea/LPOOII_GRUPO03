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
    /// Lógica de interacción para WPFAltaTicket.xaml
    /// </summary>
    public partial class WPFAltaTicket 
    {
        public WPFAltaTicket()
        {
            InitializeComponent();
            cargarComboClientes();
        }

        private void cargarComboClientes()
        {
            cmbClientes.ItemsSource = TrabajarClientes.listarClientes();
            cmbClientes.SelectedValuePath = "Cli_DNI";
            cmbClientes.DisplayMemberPath = "Cli_Apellido";
        }

        private void cargarComboProyecciones()
        {
            cmbClientes.ItemsSource = TrabajarProyeccion.traerProyecciones();
            cmbClientes.SelectedValuePath = "Pro_Codigo";
            cmbClientes.DisplayMemberPath = "Peli_Codigo";
        }
    }
}
