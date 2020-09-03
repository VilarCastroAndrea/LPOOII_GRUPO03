using System;
using System.Windows;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login login = new Login();
        public MainWindow()
        {
            InitializeComponent();
            Console.Write(login.logueado);
            usuario.Content = login.logueado.Usu_NombreUsuario;

        }
    }
}
