using System;

namespace ClasesBase
{
    public class Ticket
    {
        private int tick_Nro;
        private DateTime tick_FechaVenta;
        private int cli_DNI;
        private int proy_Codigo;
        private int sla_NroSala;
        private int but_Fila;
        private int but_Nro;
        private bool tick_Estado;

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="tick_Nro"></param>
        /// <param name="tick_FechaVenta"></param>
        /// <param name="cli_DNI"></param>
        /// <param name="proy_Codigo"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="but_Fila"></param>
        /// <param name="but_Nro"></param>
        public Ticket(int tick_Nro, DateTime tick_FechaVenta, int cli_DNI, int proy_Codigo, int sla_NroSala, int but_Fila, int but_Nro)
        {
            this.tick_Nro = tick_Nro;
            this.tick_FechaVenta = tick_FechaVenta;
            this.cli_DNI = cli_DNI;
            this.proy_Codigo = proy_Codigo;
            this.sla_NroSala = sla_NroSala;
            this.but_Fila = but_Fila;
            this.but_Nro = but_Nro;
            this.tick_Estado = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="tick_Nro"></param>
        /// <param name="tick_FechaVenta"></param>
        /// <param name="cli_DNI"></param>
        /// <param name="proy_Codigo"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="but_Fila"></param>
        /// <param name="but_Nro"></param>
        /// <param name="tick_Estado"></param>
        public Ticket(int tick_Nro, DateTime tick_FechaVenta, int cli_DNI, int proy_Codigo, int sla_NroSala, int but_Fila, int but_Nro, bool tick_Estado)
        {
            this.tick_Nro = tick_Nro;
            this.tick_FechaVenta = tick_FechaVenta;
            this.cli_DNI = cli_DNI;
            this.proy_Codigo = proy_Codigo;
            this.sla_NroSala = sla_NroSala;
            this.but_Fila = but_Fila;
            this.but_Nro = but_Nro;
            this.tick_Estado = tick_Estado;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Tick_Nro { get => tick_Nro; set => tick_Nro = value; }
        public DateTime Tick_FechaVenta { get => tick_FechaVenta; set => tick_FechaVenta = value; }
        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public int But_Fila { get => but_Fila; set => but_Fila = value; }
        public int But_Nro { get => but_Nro; set => but_Nro = value; }
        public bool Tick_Estado { get => tick_Estado; set => tick_Estado = value; }
    }
}
