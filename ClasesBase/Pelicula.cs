namespace ClasesBase
{
    public class Pelicula
    {
        private int peli_Codigo;
        private string peli_Titulo;
        private string peli_Duracion;
        private int gnr_Id;
        private int cls_Id;
        private bool peli_Disponible;
        private string peli_Imagen;

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
        /// <param name="peli_Imagen"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, int gnr_Id, int cls_Id, string peli_Imagen)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.gnr_Id = gnr_Id;
            this.cls_Id = cls_Id;
            this.peli_Disponible = true;
            this.Peli_Imagen1 = peli_Imagen;
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
        /// <param name="peli_Imagen"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, int gnr_Id, int cls_Id, bool peli_Disponible, string peli_Imagen)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.gnr_Id = gnr_Id;
            this.cls_Id = cls_Id;
            this.peli_Disponible = peli_Disponible;
            this.Peli_Imagen1 = peli_Imagen;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public string Peli_Titulo { get => peli_Titulo; set => peli_Titulo = value; }
        public string Peli_Duracion { get => peli_Duracion; set => peli_Duracion = value; }
        public int Gnr_Id { get => gnr_Id; set => gnr_Id = value; }
        public int Cls_Id { get => cls_Id; set => cls_Id = value; }
        public bool Peli_Disponible { get => peli_Disponible; set => peli_Disponible = value; }
        public string Peli_Imagen1 { get => peli_Imagen; set => peli_Imagen = value; }
    }
}
