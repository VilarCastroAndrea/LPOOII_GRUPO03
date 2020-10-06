using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarCliente
    {
        /// <summary>
        /// Obtiene todos los clientes de la base de datos 
        /// </summary>
        /// <returns></returns>
        public DataTable obtenerClientes() {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            dataAdapter.Fill(dataTable);
            return (dataTable);
        }

        public static void insertarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Cliente (CLI_DNI,CLI_Nombre,CLI_Apellido,CLI_Telefono,CLI_Disponible,CLI_Email) values(@dni,@nombre,@apellido,@tel,@disponible,@email)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", cliente.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", cliente.Cli_Email);
            cmd.Parameters.AddWithValue("@disponible", cliente.Cli_Disponible);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void modificarCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Cliente set CLI_Nombre=@nombre,CLI_Apellido=@apellido,CLI_Telefono=@tel,CLI_Email=@email  WHERE CLI_DNI=@dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", cliente.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", cliente.Cli_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public Cliente buscarCliente(string dni) {
            int dnibuscar;

            if (string.IsNullOrEmpty(dni))
            {
                dnibuscar = 0;
            }
            else {
              dnibuscar  = Int32.Parse(dni);
            }
           

            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente WHERE CLI_DNI=@dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@dni",dnibuscar);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Cliente cliente = null;

            if (reader.Read()) {
                cliente = new Cliente();
                cliente.Cli_DNI = (int)reader["CLI_DNI"];
                cliente.Cli_Nombre = (string)reader["CLI_Nombre"];
                cliente.Cli_Apellido = (string)reader["CLI_Apellido"];
                cliente.Cli_Telefono = (string)reader["CLI_Telefono"];
                cliente.Cli_Email = (string)reader["CLI_Email"];

            }

            conn.Close();

            return cliente;
        }




    }
}
