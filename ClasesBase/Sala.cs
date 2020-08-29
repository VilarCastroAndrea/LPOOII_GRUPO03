namespace ClasesBase
{
    public class Sala
    {
        private int sla_NroSala;
        private int sla_CantButaca;
        private string sla_Descripcion;
        private bool sla_Disponible;

        public Sala()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="sla_NroSala"></param>
        /// <param name="sla_CantButaca"></param>
        /// <param name="sla_Descripcion"></param>
        public Sala(int sla_NroSala, int sla_CantButaca, string sla_Descripcion)
        {
            this.sla_NroSala = sla_NroSala;
            this.sla_CantButaca = sla_CantButaca;
            this.sla_Descripcion = sla_Descripcion;
            this.sla_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="sla_NroSala"></param>
        /// <param name="sla_CantButaca"></param>
        /// <param name="sla_Descripcion"></param>
        /// <param name="sla_Disponible"></param>
        public Sala(int sla_NroSala, int sla_CantButaca, string sla_Descripcion, bool sla_Disponible)
        {
            this.sla_NroSala = sla_NroSala;
            this.sla_CantButaca = sla_CantButaca;
            this.sla_Descripcion = sla_Descripcion;
            this.sla_Disponible = sla_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public int Sla_CantButaca { get => sla_CantButaca; set => sla_CantButaca = value; }
        public string Sla_Descripcion { get => sla_Descripcion; set => sla_Descripcion = value; }
        public bool Sla_Disponible { get => sla_Disponible; set => sla_Disponible = value; }
    }
}
