namespace ClasesBase
{
    public class Pelicula
    {
        private int peli_Codigo;
        private string peli_Titulo;
        private string peli_Duracion;
        private int gnr_Id;
        private int cls_Id;

        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public string Peli_Titulo { get => peli_Titulo; set => peli_Titulo = value; }
        public string Peli_Duracion { get => peli_Duracion; set => peli_Duracion = value; }
        public int Gnr_Id { get => gnr_Id; set => gnr_Id = value; }
        public int Cls_Id { get => cls_Id; set => cls_Id = value; }
    }
}
