using System;

namespace ClasesBase
{
    public class Ticket
    {
        private int tick_Nro;
        private DateTime tick_FechaVenta;
        private int cli_DNI;
        private int proy_Codigo;
        private int but_Id;
        private bool tick_Estado;
        private int usu_Id;

        public Ticket()
        {
        }

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
        public Ticket(int tick_Nro, DateTime tick_FechaVenta, int cli_DNI, int proy_Codigo, int but_Id, int usu_id)
        {
            this.tick_Nro = tick_Nro;
            this.tick_FechaVenta = tick_FechaVenta;
            this.cli_DNI = cli_DNI;
            this.proy_Codigo = proy_Codigo;
            this.but_Id = but_Id;
            this.tick_Estado = true;
            this.usu_Id = usu_id;
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
        public Ticket(int tick_Nro, DateTime tick_FechaVenta, int cli_DNI, int proy_Codigo, int but_Id, bool tick_Estado, int usu_id)
        {
            this.tick_Nro = tick_Nro;
            this.tick_FechaVenta = tick_FechaVenta;
            this.cli_DNI = cli_DNI;
            this.proy_Codigo = proy_Codigo;
            this.but_Id = but_Id;
            this.tick_Estado = tick_Estado;
            this.usu_Id = usu_id;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Tick_Nro { get => tick_Nro; set => tick_Nro = value; }
        public DateTime Tick_FechaVenta { get => tick_FechaVenta; set => tick_FechaVenta = value; }
        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public bool Tick_Estado { get => tick_Estado; set => tick_Estado = value; }
        public int Usu_Id { get => usu_Id; set => usu_Id = value; }
        public int But_Id { get => but_Id; set => but_Id = value; }
    }
}
