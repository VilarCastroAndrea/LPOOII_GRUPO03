namespace ClasesBase
{
    public class Proyeccion
    {
        private int proy_Codigo;
        private string proy_Fecha;
        private string proy_Hora;
        private int sla_NroSala;
        private int peli_Codigo;
        private bool proy_Disponible;

        public Proyeccion()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="proy_Codigo"></param>
        /// <param name="proy_Fecha"></param>
        /// <param name="proy_Hora"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="peli_Codigo"></param>
        public Proyeccion(int proy_Codigo, string proy_Fecha, string proy_Hora, int sla_NroSala, int peli_Codigo)
        {
            this.proy_Codigo = proy_Codigo;
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.sla_NroSala = sla_NroSala;
            this.peli_Codigo = peli_Codigo;
            this.proy_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="proy_Codigo"></param>
        /// <param name="proy_Fecha"></param>
        /// <param name="proy_Hora"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="peli_Codigo"></param>
        /// <param name="proy_Disponible"></param>
        public Proyeccion(int proy_Codigo, string proy_Fecha, string proy_Hora, int sla_NroSala, int peli_Codigo, bool proy_Disponible)
        {
            this.proy_Codigo = proy_Codigo;
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.sla_NroSala = sla_NroSala;
            this.peli_Codigo = peli_Codigo;
            this.proy_Disponible = proy_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public string Proy_Fecha { get => proy_Fecha; set => proy_Fecha = value; }
        public string Proy_Hora { get => proy_Hora; set => proy_Hora = value; }
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public bool Proy_Disponible { get => proy_Disponible; set => proy_Disponible = value; }
    }
}
