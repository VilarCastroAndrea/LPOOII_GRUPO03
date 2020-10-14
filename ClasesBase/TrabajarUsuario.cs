using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();

            listaUsuarios.Add(new Usuario("admin","123","admin",0));
            listaUsuarios.Add(new Usuario("vendedor", "123", "vendedor", 1));

            return listaUsuarios;
        }

        public void InsertarUsuario(Usuario usu)
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO" +
                            " Usuario(USU_NombreUsuario, USU_Password, USU_ApellidoNombre, ROL_Codigo, USU_Disponible) " +
                            "values(@nombreUsu, @password, @apNombre, @rolCod, @disponible)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@nombreUsu", usu.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usu.Usu_Password);
            cmd.Parameters.AddWithValue("@apNombre", usu.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rolCod", usu.Rol_Codigo);
            cmd.Parameters.AddWithValue("@disponible", usu.Usu_Disponible);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
