using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        /// <summary>
        /// Alta usuario con stored procedure
        /// </summary>
        /// <param name="usuario"></param>
        public static void altaUsuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@apellidoNombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codigo", usuario.Rol_Codigo);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de usuario logica con stored procedure
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="disponible"></param>
        public static void bajaUsuario(int idUsuario, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usuarioId", idUsuario);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        /// <summary>
        /// Baja de usuario fisica con stored procedure
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="dis"></param>
        public static void bajaUsuarioFisica(int usuarioId)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaUsuarioFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }




        /// <summary>
        /// Modificar usuario con stored procedure
        /// </summary>
        /// <param name="usuario"></param>
        public static void modificarUsuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", usuario.Usu_Id);
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@apellidoNombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codigoRol", usuario.Rol_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Lista todos los Usuarios
        /// </summary>
        /// <returns></returns>
        public static DataTable listarUsuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioss";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar Usuarios disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarUsuariosDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Coleccion de Usuarios
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuario()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioss";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["USU_Id"];
                usuario.Usu_ApellidoNombre = (string)reader["USU_ApellidoNombre"];
                usuario.Usu_NombreUsuario = (string)reader["USU_NombreUsuario"];
                usuario.Usu_Password = (string)reader["USU_Password"];
                usuario.Rol_Codigo = (int)reader["ROL_Codigo"];
                usuario.Usu_Disponible = (bool)reader["USU_Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            
            return coleccionUsuarios;
        }
    }
}
