namespace ClasesBase
{
    public class Butaca
    {
        private int but_Id;
        private string but_Fila;
        private int but_Nro;
        private int sla_NroSala;
        private bool but_Disponible;

        public Butaca()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="but_Fila"></param>
        /// <param name="but_Nro"></param>
        /// <param name="sla_NroSala"></param>
        public Butaca(string but_Fila, int but_Nro, int sla_NroSala)
        {
            this.But_Fila = but_Fila;
            this.But_Nro = but_Nro;
            this.Sla_NroSala = sla_NroSala;
            this.But_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="but_Fila"></param>
        /// <param name="but_Nro"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="but_Disponible"></param>
        public Butaca(string but_Fila, int but_Nro, int sla_NroSala, bool but_Disponible)
        {
            this.But_Fila = but_Fila;
            this.But_Nro = but_Nro;
            this.Sla_NroSala = sla_NroSala;
            this.But_Disponible = but_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int But_Id { get => but_Id; set => but_Id = value; }
        public string But_Fila { get => but_Fila; set => but_Fila = value; }
        public int But_Nro { get => but_Nro; set => but_Nro = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public bool But_Disponible { get => but_Disponible; set => but_Disponible = value; }

    }
}
