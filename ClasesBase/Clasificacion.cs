namespace ClasesBase
{
    public class Clasificacion
    {
        private int cls_Id;
        private string cls_Descripcion;
        private bool cls_Disponible;

        public Clasificacion()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="cls_Id"></param>
        /// <param name="cls_Descripcion"></param>
        public Clasificacion(int cls_Id, string cls_Descripcion)
        {
            this.cls_Id = cls_Id;
            this.cls_Descripcion = cls_Descripcion;
            this.cls_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="cls_Id"></param>
        /// <param name="cls_Descripcion"></param>
        /// <param name="cls_Disponible"></param>
        public Clasificacion(int cls_Id, string cls_Descripcion, bool cls_Disponible)
        {
            this.cls_Id = cls_Id;
            this.cls_Descripcion = cls_Descripcion;
            this.cls_Disponible = cls_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Cls_Id { get => cls_Id; set => cls_Id = value; }
        public string Cls_Descripcion { get => cls_Descripcion; set => cls_Descripcion = value; }
        public bool Cls_Disponible { get => cls_Disponible; set => cls_Disponible = value; }
    }
}
