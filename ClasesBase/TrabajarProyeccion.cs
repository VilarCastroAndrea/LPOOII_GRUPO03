using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    class TrabajarProyeccion
    {
        /// <summary>
        /// Alta Proyeccion con stored procedure
        /// </summary>
        /// <param name="proyeccion"></param>
        public static void altaProyeccion(Proyeccion proyeccion)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sala", proyeccion.Sla_NroSala);
            cmd.Parameters.AddWithValue("@peliCodigo", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de proyeccion logica con stored procedure
        /// </summary>
        /// <param name="proyeccionCodigo"></param>
        /// <param name="disponible"></param>
        public static void bajaProyeccion(int proyeccionCodigo, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@proyeccionCodigo", proyeccionCodigo);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        /// <summary>
        /// Baja de proyeccion fisica con stored procedure
        /// </summary>
        /// <param name="proyeccionCodigo"></param>
        public static void bajaProyeccionFisica(int proyeccionCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaProyeccionFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@proyeccionCodigo", proyeccionCodigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        /// <summary>
        /// Lista todas las proyecciones
        /// </summary>
        /// <returns></returns>
        public static DataTable listarProyecciones()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarProyecciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar Proyecciones disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarProyeccionesDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarProyeccionDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Modificar Proyeccion con stored procedure
        /// </summary>
        /// <param name="proyeccion"></param>
        public static void modificarProyeccion(Proyeccion proyeccion)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigo", proyeccion.Proy_Codigo);
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@numeroSala", proyeccion.Sla_NroSala);
            cmd.Parameters.AddWithValue("@peliCodigo", proyeccion.Peli_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
