using System;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged
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
        public string Usu_NombreUsuario { get => usu_NombreUsuario;
            set
            {
                usu_NombreUsuario = value;
                Notificador(usu_NombreUsuario);
            }
        }
        public string Usu_Password { get => usu_Password;
            set
            {
                usu_Password = value;
                Notificador(usu_Password);
            }
        }

        public string Usu_ApellidoNombre { get => usu_ApellidoNombre; set => usu_ApellidoNombre = value; }
        public int Rol_Codigo { get => rol_Codigo; set => rol_Codigo = value; }
        public bool Usu_Disponible { get => usu_Disponible; set => usu_Disponible = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notificador(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
