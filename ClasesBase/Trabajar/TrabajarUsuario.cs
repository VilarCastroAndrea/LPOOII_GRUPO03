﻿using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System;

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


        /// Busca usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Usuario buscarUsuario(string id)
        {
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
            }
            cnn.Close();
            return usuario;
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
        /// Coleccion de Usuarios
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuario()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioss";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            cnn.Close();
            return coleccionUsuarios;
        }


        /// <summary>
        /// Coleccion de Usuarios
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuarioDisponible()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = Encryp.DesEncriptar((string)reader["Password"]);
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            cnn.Close();
            return coleccionUsuarios;
        }

        // <summary>
        /// Coleccion de Usuarios
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuarioDisponibleListView()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            cnn.Close();
            return coleccionUsuarios;
        }

        /// <summary>
        /// Inicializa un objeto del tipo usuario para las validaciones del formulario
        /// </summary>
        /// <returns></returns>
        public Usuario IniciarUsuario()
        {
            return new Usuario();
        }


        public static bool validarUsuario(string usuario, string contra)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "loginUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@nombre",usuario);
            cmd.Parameters.AddWithValue("@password", contra);
       
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
          
            if (reader.HasRows)
            {

                while (reader.Read())
                {   //almacena los datos en una clase para mantener la sesion
                    
                    UsuarioLogin.usu_Id = reader.GetInt32(0);
                    UsuarioLogin.usu_NombreUsuario = reader.GetString(1);
                    UsuarioLogin.usu_Password = reader.GetString(2);
                    UsuarioLogin.usu_ApellidoNombre = reader.GetString(3);
                    UsuarioLogin.rol_Codigo = reader.GetInt32(4);
                    UsuarioLogin.usu_Disponible = reader.GetBoolean(5);
                }
                cnn.Close();
                return true;
            }
            else
            {
                cnn.Close();
                return false;
            }
        }

    }
}
