namespace ClasesBase
{
    public class Cliente
    {
        private int cli_DNI;
        private string cli_Nombre;
        private string cli_Apellido;
        private string cli_Telefono;
        private string cli_Email;

        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public string Cli_Nombre { get => cli_Nombre; set => cli_Nombre = value; }
        public string Cli_Apellido { get => cli_Apellido; set => cli_Apellido = value; }
        public string Cli_Telefono { get => cli_Telefono; set => cli_Telefono = value; }
        public string Cli_Email { get => cli_Email; set => cli_Email = value; }
    }
}
