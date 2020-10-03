﻿using ClasesBase;
using System;
using System.Windows;
using System.Windows.Input;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFAltaCliente.xaml
    /// </summary>
    public partial class WPFAltaCliente
    {
        public WPFAltaCliente()
        {
            InitializeComponent();
        }

   
        /// <summary>
        /// Alta de cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAlta_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_DNI = Convert.ToInt32(txtDni.Text);
            cliente.Cli_Email = txtEmail.Text;
            cliente.Cli_Disponible = true;
            cliente.Cli_Telefono = txtTelefono.Text;

            TrabajarCliente.insertarCliente(cliente);


        }

    

    }
}
