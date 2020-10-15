﻿using System;
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
        /// <summary>
        /// Obtie los usuarios de la base de datos
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();

            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Usuario u = new Usuario();
                    u.Usu_Id = int.Parse(dr["USU_ID"].ToString());
                    u.Usu_NombreUsuario = dr["USU_NombreUsuario"].ToString();
                    u.Usu_Password = dr["USU_Password"].ToString();
                    u.Usu_ApellidoNombre = dr["USU_ApellidoNombre"].ToString();
                    u.Rol_Codigo = int.Parse(dr["ROL_Codigo"].ToString());
                    u.Usu_Disponible = bool.Parse(dr["USU_Disponible"].ToString());
                    listaUsuarios.Add(u);
                }
            }
            
            return listaUsuarios;
        }

        /// <summary>
        /// Inserta un usuario en la base de datos
        /// </summary>
        /// <param name="usu"></param>
        public static void InsertarUsuario(Usuario usu)
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

        /// <summary>
        /// Elimina un usuario de la base de datos
        /// </summary>
        /// <param name="usu"></param>
        public static void EliminarUsuario(Usuario usu)
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Usuario WHERE CLI_ID = @id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@id", usu.Usu_Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Actualiza un usuario de la base de datos
        /// </summary>
        /// <param name="usu"></param>
        public static void ActualizarUsuario(Usuario usu)
        {
            SqlConnection conn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Usuario set " +
                              "USU_NombreUsuario=@nombUsu, USU_Password=@pass," +
                              " USU_ApellidoNombre=@apNomb, ROL_Codigo=@rol, " +
                              "USU_Disponible=@disp " +
                              "WHERE USU_ID=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@id", usu.Usu_Id);
            cmd.Parameters.AddWithValue("@nombUsu", usu.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pass", usu.Usu_Password);
            cmd.Parameters.AddWithValue("@apNomb", usu.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", usu.Rol_Codigo);
            cmd.Parameters.AddWithValue("@disp", usu.Usu_Disponible);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
