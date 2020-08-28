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

        public int Tick_Nro { get => tick_Nro; set => tick_Nro = value; }
        public DateTime Tick_FechaVenta { get => tick_FechaVenta; set => tick_FechaVenta = value; }
        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public int But_Fila { get => but_Fila; set => but_Fila = value; }
        public int But_Nro { get => but_Nro; set => but_Nro = value; }
    }
}
