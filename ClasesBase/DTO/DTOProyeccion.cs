using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.DTO
{
    public class DTOProyeccion
    {
        private int proy_Codigo;
        private string proy_Fecha;
        private string proy_Hora;
        private bool proy_Disponible;

        private int peli_Codigo;
        private string peli_Titulo;
        private string peli_Duracion;
        private string peli_Genero;
        private string peli_Clasificacion;

        private int sla_NroSala;
        private string sla_Descripcion;

        public DTOProyeccion()
        {

        }

        public DTOProyeccion(string proy_Fecha, string proy_Hora, bool proy_Disponible, int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_Genero, string peli_Clasificacion, int sla_NroSala, string sla_Descripcion)
        {
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.proy_Disponible = proy_Disponible;
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.peli_Genero = peli_Genero;
            this.peli_Clasificacion = peli_Clasificacion;
            this.sla_NroSala = sla_NroSala;
            this.sla_Descripcion = sla_Descripcion;
        }

        public DTOProyeccion(int proy_Codigo, string proy_Fecha, string proy_Hora, bool proy_Disponible, int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_Genero, string peli_Clasificacion, int sla_NroSala, string sla_Descripcion)
        {
            this.proy_Codigo = proy_Codigo;
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.proy_Disponible = proy_Disponible;
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.peli_Genero = peli_Genero;
            this.peli_Clasificacion = peli_Clasificacion;
            this.sla_NroSala = sla_NroSala;
            this.sla_Descripcion = sla_Descripcion;
        }

        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public string Proy_Fecha { get => proy_Fecha; set => proy_Fecha = value; }
        public string Proy_Hora { get => proy_Hora; set => proy_Hora = value; }
        public bool Proy_Disponible { get => proy_Disponible; set => proy_Disponible = value; }
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public string Peli_Titulo { get => peli_Titulo; set => peli_Titulo = value; }
        public string Peli_Duracion { get => peli_Duracion; set => peli_Duracion = value; }
        public string Peli_Genero { get => peli_Genero; set => peli_Genero = value; }
        public string Peli_Clasificacion { get => peli_Clasificacion; set => peli_Clasificacion = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public string Sla_Descripcion { get => sla_Descripcion; set => sla_Descripcion = value; }
    }
}
