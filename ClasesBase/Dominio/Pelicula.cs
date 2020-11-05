using System.ComponentModel;

namespace ClasesBase
{
    public class Pelicula : IDataErrorInfo
    {
        private int peli_Codigo;
        private string peli_Titulo;
        private string peli_Duracion;
        private string peli_Genero;
        private string peli_Clasificacion;
        private bool peli_Disponible;
        private string peli_Imagen;
        private string peli_Avance;


        public Pelicula()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="peli_Codigo"></param>
        /// <param name="peli_Titulo"></param>
        /// <param name="peli_Duracion"></param>
        /// <param name="gnr_Id"></param>
        /// <param name="cls_Id"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_genero, string peli_clasificacion)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.Peli_Genero = peli_genero;
            this.Peli_Clasificacion = peli_clasificacion;
            this.peli_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="peli_Codigo"></param>
        /// <param name="peli_Titulo"></param>
        /// <param name="peli_Duracion"></param>
        /// <param name="gnr_Id"></param>
        /// <param name="cls_Id"></param>
        /// <param name="peli_Disponible"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_genero, string peli_clasificacion, bool peli_Disponible)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.Peli_Genero = peli_genero;
            this.Peli_Clasificacion = peli_clasificacion;
            this.peli_Disponible = peli_Disponible;
        }

        

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public string Peli_Titulo { get => peli_Titulo; set => peli_Titulo = value; }
        public string Peli_Duracion { get => peli_Duracion; set => peli_Duracion = value; }
        public bool Peli_Disponible { get => peli_Disponible; set => peli_Disponible = value; }
        public string Peli_Genero { get => peli_Genero; set => peli_Genero = value; }
        public string Peli_Clasificacion { get => peli_Clasificacion; set => peli_Clasificacion = value; }
        public string Peli_Imagen { get => peli_Imagen; set => peli_Imagen = value; }
        public string Peli_Avance { get => peli_Avance; set => peli_Avance = value; }


        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_error = null;
                switch (columnName)
                {
                    case "Peli_Titulo":
                        msg_error = validar_Titulo();
                        break;
                    case "Peli_Duracion":
                        msg_error = validar_Duracion();
                        break;
                }
                return msg_error;
            }
        }

        private string validar_Titulo()
        {
            if (string.IsNullOrEmpty(Peli_Titulo))
            {
                return "El TITULO es obligatorio.";
            }
            return null;
        }

        private string validar_Duracion()
        {
            if (string.IsNullOrEmpty(Peli_Duracion))
            {
                return "La DURACION es obligatoria.";
            }
            return null;
        }
    }
}
