﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para WPFTicketProyeccion.xaml
    /// </summary>
    public partial class WPFTicketProyeccion 
    {

        WPFTicket ticketPadre;
        ClasesBase.Proyeccion proyeccion = new ClasesBase.Proyeccion();
        ClasesBase.Pelicula pelicula = new ClasesBase.Pelicula();
        public WPFTicketProyeccion(WPFTicket padre)
        {
            InitializeComponent();
            ticketPadre = padre;
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage b = new BitmapImage();
            DataRowView item = (DataRowView)listaProyeccion.SelectedItem;
            ticketPadre.cargarProyeccion(Convert.ToInt32(item["Codigo"]));
            txtNombrePelicula.Text = Convert.ToString(item["Titulo de la Pelicula"]);
            txtFecha.Text = Convert.ToString(item["Fecha"]);
            txtHora.Text = Convert.ToString(item["Hora"]);
            txtSala.Text = Convert.ToString(item["Descripcion de Sala"]);
            proyeccion = TrabajarProyeccion.buscarProyeccion(Convert.ToInt32(item["Codigo"]));
            pelicula = TrabajarPelicula.buscarPelicula(proyeccion.Peli_Codigo.ToString());

            b.BeginInit();
            if (pelicula.Peli_Imagen == null)
            {
                b.UriSource = new Uri("/../../../Img/logo.png", UriKind.Relative);
            }
            else
            {
                b.UriSource = new Uri(pelicula.Peli_Imagen);
            }
            b.EndInit();
            imgPelicula.Stretch = Stretch.Fill;
            imgPelicula.Source = b;
        }

        private void BtnMasInfo_Click(object sender, RoutedEventArgs e)
        {
            UserControl.Proyeccion.WPFMasInformacion masInfo = new UserControl.Proyeccion.WPFMasInformacion(proyeccion);
            masInfo.Show();
        }
    }
}
