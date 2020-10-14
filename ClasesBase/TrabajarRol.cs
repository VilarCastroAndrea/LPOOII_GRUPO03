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
    public class TrabajarRol
    {


        public static ObservableCollection<Rol> listar_roles()
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Rol";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Rol rol = null;
            ObservableCollection<Rol> listaRoles = new ObservableCollection<Rol>();

            while (reader.Read())
            {
                rol = new Rol();
                rol.Rol_Codigo = (int)reader["ROL_Codigo"];
                rol.Rol_Descripcion = (string)reader["Rol_Descripcion"];
        
                listaRoles.Add(rol);
            }

            conn.Close();

            Console.Write("PASOOOOOOOO");
            return listaRoles;
        }
    }
}
