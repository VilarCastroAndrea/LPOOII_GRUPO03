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

namespace Vistas.UserControl.Usuario
{
    /// <summary>
    /// Lógica de interacción para WinVistaPrevia.xaml
    /// </summary>
    public partial class WinVistaPrevia : Window
    {

        public WinVistaPrevia(ListView listUsuarios)
        {
            InitializeComponent();
            lstUsuarios.ItemsSource = listUsuarios.ItemsSource;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog() == true)
            {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }
    }
}
