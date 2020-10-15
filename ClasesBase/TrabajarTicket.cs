using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    class TrabajarTicket
    {
        /// <summary>
        /// Alta Ticket con stored procedure
        /// </summary>
        /// <param name="ticket"></param>
        public static void altaTicket(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fechaVenta", ticket.Tick_FechaVenta);
            cmd.Parameters.AddWithValue("@cliDni", ticket.Cli_DNI);
            cmd.Parameters.AddWithValue("@butacaId", ticket.But_Id);
            cmd.Parameters.AddWithValue("@proyeccionCodigo", ticket.Proy_Codigo);
            cmd.Parameters.AddWithValue("@usuId", ticket.Usu_Id);
            cmd.Parameters.AddWithValue("@estado", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de ticket logica con stored procedure
        /// </summary>
        /// <param name="numeroTicket"></param>
        /// <param name="estado"></param>
        public static void bajaTicket(int numeroTicket, bool estado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numeroTicket", numeroTicket);
            cmd.Parameters.AddWithValue("@estado", estado);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        /// <summary>
        /// Baja de ticket fisica con stored procedure
        /// </summary>
        /// <param name="ticketNumero"></param>
        public static void bajaTicketFisica(int ticketNumero)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaTicketFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@ticketNumero", ticketNumero);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        /// <summary>
        /// Lista todos los tickets
        /// </summary>
        /// <returns></returns>
        public static DataTable listarTickets()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarTickets";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar Tickets disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarTicketDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarTicketDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@estado", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Modificar Ticket con stored procedure
        /// </summary>
        /// <param name="ticket"></param>
        public static void modificarProyeccion(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numero", ticket.Tick_Nro);
            cmd.Parameters.AddWithValue("@fechaVenta", ticket.Tick_FechaVenta);
            cmd.Parameters.AddWithValue("@cliDni", ticket.Cli_DNI);
            cmd.Parameters.AddWithValue("@butacaId", ticket.But_Id);
            cmd.Parameters.AddWithValue("@proyeccionCodigo", ticket.Proy_Codigo);
            cmd.Parameters.AddWithValue("@usuId", ticket.Usu_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
