using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarPelicula
    {
        /// <summary>
        /// Alta pelicula con stored procedure
        /// </summary>
        /// <param name="cliente"></param>
        public static void altaPelicula(Pelicula pelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@titulo", pelicula.Peli_Titulo);
            cmd.Parameters.AddWithValue("@duracion", pelicula.Peli_Duracion);
            cmd.Parameters.AddWithValue("@genero", pelicula.Peli_Genero);
            cmd.Parameters.AddWithValue("@clasificacion", pelicula.Peli_Clasificacion);
            cmd.Parameters.AddWithValue("@disponible", pelicula.Peli_Disponible);
            cmd.Parameters.AddWithValue("@imagen", pelicula.Peli_Imagen);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de pelicula con stored procedure
        /// </summary>
        /// <param name="codigoPelicula"></param>
        /// <param name="disponible"></param>
        public static void bajaPelicula(int codigoPelicula, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigoPelicula", codigoPelicula);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        /// <summary>
        /// Baja de pelicula fisica con stored procedure
        /// </summary>
        /// <param name="codigoPelicula"></param>
        /// <param name="dis"></param>
        public static void bajaPeliculaFisica(int codigoPelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaPeliculaFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigoPelicula", codigoPelicula);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }




        /// <summary>
        /// Modificar pelicula con stored procedure
        /// </summary>
        /// <param name="pelicula"></param>
        public static void modificarPelicula(Pelicula pelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@titulo", pelicula.Peli_Titulo);
            cmd.Parameters.AddWithValue("@duracion", pelicula.Peli_Duracion);
            cmd.Parameters.AddWithValue("@genero", pelicula.Peli_Genero);
            cmd.Parameters.AddWithValue("@clasificacion", pelicula.Peli_Clasificacion);
            cmd.Parameters.AddWithValue("@imagen", pelicula.Peli_Imagen);
            cmd.Parameters.AddWithValue("@codigoPelicula", pelicula.Peli_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Lista todas las peliculas
        /// </summary>
        /// <returns></returns>
        public static DataTable ListaPelicula()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarPeliculas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar peliculas disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable ListaPeliculaDisponible()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarPeliculaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        /// <summary>
        /// Busca Pelicula por titulo y clasificacion
        /// </summary>
        /// <param name="sPattern"></param>
        /// <returns></returns>
        public static DataTable buscarPelicula(string sPattern)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@titulo", "%" + sPattern + "%");
            cmd.Parameters.AddWithValue("@clasificacion", "%" + sPattern + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        /// <summary>
        /// Busca pelicula por titulo y clasificacion no borrado
        /// </summary>
        /// <param name="sPattern"></param>
        /// <returns></returns>
        public static DataTable buscarPeliculaDisponible(string sPattern)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarPeliculaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            cmd.Parameters.AddWithValue("@titulo", "%" + sPattern + "%");
            cmd.Parameters.AddWithValue("@clasificacion", "%" + sPattern + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Inicializa un objeto pelicula para mostrarlo en la vista
        /// </summary>
        /// <returns></returns>
        public Pelicula IniciarPelicula()
        {
            return new Pelicula();
        }
    }
}