namespace ClasesBase
{
    public class Genero
    {
        private int gnr_Id;
        private string gnr_Descripcion;
        private bool gnr_Disponible;

        public Genero()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="gnr_Id"></param>
        /// <param name="gnr_Descripcion"></param>
        public Genero(int gnr_Id, string gnr_Descripcion)
        {
            this.gnr_Id = gnr_Id;
            this.gnr_Descripcion = gnr_Descripcion;
            this.gnr_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="gnr_Id"></param>
        /// <param name="gnr_Descripcion"></param>
        /// <param name="gnr_Disponible"></param>
        public Genero(int gnr_Id, string gnr_Descripcion, bool gnr_Disponible)
        {
            this.gnr_Id = gnr_Id;
            this.gnr_Descripcion = gnr_Descripcion;
            this.gnr_Disponible = gnr_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Gnr_Id { get => gnr_Id; set => gnr_Id = value; }
        public string Gnr_Descripcion { get => gnr_Descripcion; set => gnr_Descripcion = value; }
        public bool Gnr_Disponible { get => gnr_Disponible; set => gnr_Disponible = value; }
    }
}
