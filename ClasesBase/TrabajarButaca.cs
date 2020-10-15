using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    class TrabajarButaca
    {
        /// <summary>
        /// Alta butaca con stored procedure
        /// </summary>
        /// <param name="butaca"></param>
        public static void altaButaca(Butaca butaca)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fila", butaca.But_Fila);
            cmd.Parameters.AddWithValue("@numero", butaca.But_Nro);
            cmd.Parameters.AddWithValue("@sala", butaca.Sla_NroSala);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de butaca logica con stored procedure
        /// </summary>
        /// <param name="butId"></param>
        /// <param name="disponible"></param>
        public static void bajaUsuario(int butId, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@butId", butId);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        /// <summary>
        /// Baja de butaca fisica con stored procedure
        /// </summary>
        /// <param name="butId"></param>
        public static void bajaUsuarioFisica(int butId)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaButacaFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", butId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }


        /// <summary>
        /// Lista todas las butacas
        /// </summary>
        /// <returns></returns>
        public static DataTable listarButacas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarButacas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar butacas disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarButacasDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarButacaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Modificar butaca con stored procedure
        /// </summary>
        /// <param name="butaca"></param>
        public static void modificarButaca(Butaca butaca)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", butaca.But_Id);
            cmd.Parameters.AddWithValue("@fila", butaca.But_Fila);
            cmd.Parameters.AddWithValue("@numero", butaca.But_Nro);
            cmd.Parameters.AddWithValue("@numeroSala", butaca.Sla_NroSala);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
