﻿using ClasesBase;
using System;
using System.Collections;
using System.Windows;
using System.Configuration;
using System.Collections.Specialized;

namespace Vistas
{

    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public ArrayList usuarios = new ArrayList();

        public Login()
        {
            InitializeComponent();
            
            ReproducirEfectoSonidoRelativo();
        }

        /// <summary>
        /// Reproduce un audio en mp3 mediante url relativa
        /// </summary>
        private void ReproducirEfectoSonidoRelativo()
        {
            bool reproducirSonido = Properties.UserConfig.Default.iniciarSonido;
            if (reproducirSonido)
            {
                string path = "";
                int op = Properties.UserConfig.Default.urlRelativa;
                switch (op)
                {
                    case 0:
                        path = "utils/Efectos/EfectoSonido1.mp3";
                        break;
                    case 1:
                        path = "utils/Efectos/XPStartUp.mp3";
                        break;
                    case 2:
                        path = "utils/Efectos/big_music_logo.mp3";
                        break;
                }
                Uri uriSonido;
                if (Uri.TryCreate(path, UriKind.Relative, out uriSonido))
                {
                    mediaElement.Source = uriSonido;
                    mediaElement.Play();
                }
            }
        }


        /// <summary>
        /// Compara los datos ingresados en el login y si son correctos guarda el usuario que ingreso y 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TrabajarUsuario.validarUsuario(login.Usuario,login.Contraseña) == true)
            {
                
                MainWindow menu = new MainWindow();
                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("No se encontro el usuario " + login.Usuario, "Error");
            }
        }

        /// <summary>
        /// Abre la ventana de configuracion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            VentanaConfig vc = new VentanaConfig();
            vc.Show();
        }
    }
}
