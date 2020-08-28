namespace ClasesBase
{
    public class Usuario
    {
        private int usu_Id;
        private string usu_NombreUsuario;
        private string usu_Password;
        private string usu_ApellidoNombre;
        private int rol_Codigo;

        public int Usu_Id { get => usu_Id; set => usu_Id = value; }
        public string Usu_NombreUsuario { get => usu_NombreUsuario; set => usu_NombreUsuario = value; }
        public string Usu_Password { get => usu_Password; set => usu_Password = value; }
        public string Usu_ApellidoNombre { get => usu_ApellidoNombre; set => usu_ApellidoNombre = value; }
        public int Rol_Codigo { get => rol_Codigo; set => rol_Codigo = value; }
    }
}
