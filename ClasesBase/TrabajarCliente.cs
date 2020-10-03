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


        public Cliente traerCliente() {
            Cliente cliente = new Cliente();

            cliente.Cli_Nombre = "";
            cliente.Cli_Apellido = "";
            cliente.Cli_Email = "";
            cliente.Cli_Telefono = "";


            return null;
        }




    }
}
