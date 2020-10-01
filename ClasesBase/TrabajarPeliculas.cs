using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarPeliculas
    {

        public TrabajarPeliculas() { }

        public DataTable traerPeliculas()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cinesConnectionString1);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Pelicula";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return (dt);
        }
    }
}
