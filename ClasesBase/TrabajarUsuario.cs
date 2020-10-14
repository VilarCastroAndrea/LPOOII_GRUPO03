using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarUsuario
    {

        public static ObservableCollection<Usuario>traerUsuarios(){
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Usuario usuario = null;
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["USU_Id"];
                usuario.Usu_ApellidoNombre = (string)reader["USU_ApellidoNombre"];
                usuario.Usu_NombreUsuario = (string)reader["USU_NombreUsuario"];
                usuario.Usu_Password = (string)reader["USU_Password"];
                usuario.Rol_Codigo = (int)reader["ROL_Codigo"];
                usuario.Usu_Disponible = (bool)reader["USU_Disponible"];

                listaUsuario.Add(usuario);
            }

            conn.Close();

            Console.Write("PASOOOOOOOO");
            return listaUsuario;
        }


        public static void insertar_usuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuario(USU_NombreUsuario,USU_Password,USU_ApellidoNombre,ROL_Codigo,USU_Disponible) values(@usu,@contrasena,@nombre,@rol,@disponible)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@usu", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@contrasena", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@nombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol_Codigo);
            cmd.Parameters.AddWithValue("@disponible", usuario.Usu_Disponible);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminar_usuario(int id)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE Usuario WHERE USU_Id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void actualizar_usuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Usuario set USU_NombreUsuario=@usu,USU_Password=@contra,USU_ApellidoNombre=@nombre,ROL_Codigo=@rol WHERE USU_Id=@id";
            cmd.Parameters.AddWithValue("@usu", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@contra", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@nombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol_Codigo);
            cmd.Parameters.AddWithValue("@id", usuario.Usu_Id);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



    }
}
