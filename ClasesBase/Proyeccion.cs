namespace ClasesBase
{
    public class Proyeccion
    {
        private int proy_Codigo;
        private string proy_Fecha;
        private string proy_Hora;
        private int sla_NroSala;
        private int peli_Codigo;

        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public string Proy_Fecha { get => proy_Fecha; set => proy_Fecha = value; }
        public string Proy_Hora { get => proy_Hora; set => proy_Hora = value; }
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
    }
}
