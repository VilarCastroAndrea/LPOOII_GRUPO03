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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Peliculas.xaml
    /// </summary>
    public partial class Peliculas : UserControl
    {
        public Peliculas()
        {
            InitializeComponent();
        }

        private void BtnNuevaPelicula_Click(object sender, RoutedEventArgs e)
        {
            PeliculaNueva peliculaNueva = new PeliculaNueva();
            peliculaNueva.Show();
        }
    }
}
