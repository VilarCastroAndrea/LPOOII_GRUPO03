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

       
    }
}
