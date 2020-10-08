using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarClientes
    {
        /// <summary>
        /// Trae una lista de clientes de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static DataTable TraerClientes()
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return (dt);
        }

        /// <summary>
        /// Trae un cliente de la base de datos a partir de su DNI.
        /// </summary>
        /// <param name="dniCliente">Dni del cliente</param>
        /// <returns></returns>
        public static DataTable TraerClienteByDni(int dniCliente)
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " CLI_Apellido as 'Apellido', CLI_Nombre as 'Nombre', ";
            cmd.CommandText += " CLI_Telefono as 'Telefono', ";
            cmd.CommandText += " CLI_Email as 'Email' ";
            cmd.CommandText += " FROM Cliente as C";
            cmd.CommandText += " WHERE";
            cmd.CommandText += " CLI_DNI = @dni ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@dni", dniCliente);

            //Ejecutar consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }



        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="cli">Nuevo objeto tipo cliente</param>
        public static void Insert_Cliente(Cliente cli)
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Cliente(CLI_DNI, CLI_Nombre, CLI_Apellido, CLI_Telefono, CLI_Email, CLI_Disponible) values(@dni, @nom, @ape, @tel, @ema, @dis)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@dni", cli.Cli_DNI);
            cmd.Parameters.AddWithValue("@nom", cli.Cli_Nombre);
            cmd.Parameters.AddWithValue("@ape", cli.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", cli.Cli_Telefono);
            cmd.Parameters.AddWithValue("@ema", cli.Cli_Email);
            cmd.Parameters.AddWithValue("@dis", cli.Cli_Disponible);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Elimina un Cliente por su DNI
        /// </summary>
        /// <param name="cliente"></param>
        public static void EliminarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Cliente WHERE CLI_DNI=@dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Actualiz un Cliente por su DNI
        /// </summary>
        /// <param name="cliente"></param>
        public static void ActualizarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Cliente set CLI_Nombre=@nombre,CLI_Apellido=@apellido,CLI_Telefono=@tel, CLI_Email=@email WHERE CLI_DNI=@dni";

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", cliente.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", cliente.Cli_Email);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        /// <summary>
        /// Inicializa un cliente para el formulario
        /// </summary>
        /// <returns></returns>
        public Cliente IniciarCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.Cli_DNI = 0;
            oCliente.Cli_Apellido = "";
            oCliente.Cli_Nombre = "";
            oCliente.Cli_Telefono = "";
            return oCliente;

        }



        /// <summary>
        /// Devuelve un objeto cliente de la base de datos 
        /// a partir de su DNI
        /// </summary>
        /// <param name="dniCliente">DNI del cliente</param>
        /// <returns></returns>
        public static Cliente TraerCliente(string dniCliente)
        {
            Cliente cli = new Cliente();
            if (!String.IsNullOrEmpty(dniCliente))
            {

                int dni = int.Parse(dniCliente);
                DataTable dt = TraerClienteByDni(dni);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    cli.Cli_Apellido = dr["Apellido"].ToString();
                    cli.Cli_Nombre = dr["Nombre"].ToString();
                    cli.Cli_Telefono = dr["Telefono"].ToString();
                    cli.Cli_Email = dr["Email"].ToString();
                    return cli;
                }
            }
            return cli;
        }
    }
}
