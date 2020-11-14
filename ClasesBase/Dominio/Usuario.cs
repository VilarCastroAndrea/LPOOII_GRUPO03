using System;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged, IDataErrorInfo
    {
        private int usu_Id;
        private string usu_NombreUsuario;
        private string usu_Password;
        private string usu_ApellidoNombre;
        private int rol_Codigo;
        private bool usu_Disponible;

        public Usuario()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="usu_NombreUsuario"></param>
        /// <param name="usu_Password"></param>
        /// <param name="usu_ApellidoNombre"></param>
        /// <param name="rol_Codigo"></param>
        public Usuario(string usu_NombreUsuario, string usu_Password, string usu_ApellidoNombre, int rol_Codigo)
        {
            this.usu_NombreUsuario = usu_NombreUsuario;
            this.usu_Password = usu_Password;
            this.usu_ApellidoNombre = usu_ApellidoNombre;
            this.rol_Codigo = rol_Codigo;
            this.usu_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="usu_NombreUsuario"></param>
        /// <param name="usu_Password"></param>
        /// <param name="usu_ApellidoNombre"></param>
        /// <param name="rol_Codigo"></param>
        /// <param name="usu_Disponible"></param>
        public Usuario(string usu_NombreUsuario, string usu_Password, string usu_ApellidoNombre, int rol_Codigo, bool usu_Disponible)
        {
            this.usu_NombreUsuario = usu_NombreUsuario;
            this.usu_Password = usu_Password;
            this.usu_ApellidoNombre = usu_ApellidoNombre;
            this.rol_Codigo = rol_Codigo;
            this.usu_Disponible = usu_Disponible;
        }

        

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Usu_Id { get => usu_Id; set => usu_Id = value; }
        public string Usu_NombreUsuario { get => usu_NombreUsuario; set => usu_NombreUsuario = value; }
        public string Usu_Password { get => usu_Password; set => usu_Password = value; }
        public string Usu_ApellidoNombre { get => usu_ApellidoNombre; set => usu_ApellidoNombre = value; }
        public int Rol_Codigo { get => rol_Codigo; set => rol_Codigo = value; }
        public bool Usu_Disponible { get => usu_Disponible; set => usu_Disponible = value; }

        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_error = null;
                switch (columnName)
                {
                    case "Usu_NombreUsuario":
                        msg_error = validar_NombreUsuario();
                        break;
                    case "Usu_Password":
                        msg_error = validar_Password();
                        break;
                    case "Usu_ApellidoNombre":
                        msg_error = validar_ApellidoNombre();
                        break;
                }
                return msg_error;
            }
        }

        private string validar_ApellidoNombre()
        {
             if (string.IsNullOrEmpty(Usu_ApellidoNombre))
            {
                return "El APELLIDO Y NOMBRE es obligatorio.";
            }
            else if (Usu_ApellidoNombre.Length > 50 || Usu_ApellidoNombre.Length < 5)
            {
                return "El Apellido y nombre es incorrecto";
            }
            return null;
        }

        private string validar_Password()
        {
            if (string.IsNullOrEmpty(Usu_Password))
            {
                return "LA CONTRASEÑA es obligatoria.";
            }
            else if (Usu_Password.Length > 50)
            {
                return "La CONTRASEÑA no debe superar los 50 caracteres.";
            }
            else if (Usu_Password.Length < 5)
            {
                return "La CONTRASEÑA debe ser mayor a 5 caracteres.";
            }
            return null;
        }

        private string validar_NombreUsuario()
        {
            if (string.IsNullOrEmpty(Usu_NombreUsuario))
            {
                return "El NOMBRE DE USUARIO es obligatorio.";
            }
            else if (Usu_NombreUsuario.Length > 50 || Usu_NombreUsuario.Length < 5)
            {
                return "El NOMBRE DE USUARIO es incorrecto";
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
