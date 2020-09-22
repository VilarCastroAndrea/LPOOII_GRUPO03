namespace Vistas.UserControl
{
    /// <summary>
    /// Lógica de interacción para UCLogin.xaml
    /// </summary>
    public partial class UCLogin
    {
        public UCLogin()
        {
            InitializeComponent();
        }
        public string Usuario
        {
            get { return txtbUsuario.Text; }

        }

        public string Contraseña
        {
            get { return txtbContraseña.Password; }
        }


    }
}
