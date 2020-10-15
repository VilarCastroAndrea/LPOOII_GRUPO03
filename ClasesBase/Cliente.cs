using System;
using System.ComponentModel;
namespace ClasesBase
{
    public class Cliente : IDataErrorInfo
    {
        private int cli_DNI;
        private string cli_Nombre;
        private string cli_Apellido;
        private string cli_Telefono;
        private string cli_Email;
        private bool cli_Disponible;

        public Cliente()
        {
        }

        /// <summary>
        /// Alta
        /// </summary>
        /// <param name="cli_DNI"></param>
        /// <param name="cli_Nombre"></param>
        /// <param name="cli_Apellido"></param>
        /// <param name="cli_Telefono"></param>
        /// <param name="cli_Email"></param>
        public Cliente(int cli_DNI, string cli_Nombre, string cli_Apellido, string cli_Telefono, string cli_Email)
        {
            this.cli_DNI = cli_DNI;
            this.cli_Nombre = cli_Nombre;
            this.cli_Apellido = cli_Apellido;
            this.cli_Telefono = cli_Telefono;
            this.cli_Email = cli_Email;
            this.cli_Disponible = true;
        }

        /// <summary>
        /// Modificacion
        /// </summary>
        /// <param name="cli_DNI"></param>
        /// <param name="cli_Nombre"></param>
        /// <param name="cli_Apellido"></param>
        /// <param name="cli_Telefono"></param>
        /// <param name="cli_Email"></param>
        /// <param name="cli_Disponible"></param>
        public Cliente(int cli_DNI, string cli_Nombre, string cli_Apellido, string cli_Telefono, string cli_Email, bool cli_Disponible)
        {
            this.cli_DNI = cli_DNI;
            this.cli_Nombre = cli_Nombre;
            this.cli_Apellido = cli_Apellido;
            this.cli_Telefono = cli_Telefono;
            this.cli_Email = cli_Email;
            this.cli_Disponible = cli_Disponible;
        }

        //public string this[string columnName] => throw new System.NotImplementedException();

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public string Cli_Nombre { get => cli_Nombre; set => cli_Nombre = value; }
        public string Cli_Apellido { get => cli_Apellido; set => cli_Apellido = value; }
        public string Cli_Telefono { get => cli_Telefono; set => cli_Telefono = value; }
        public string Cli_Email { get => cli_Email; set => cli_Email = value; }
        public bool Cli_Disponible { get => cli_Disponible; set => cli_Disponible = value; }

        //Implementacion
       // public string Error => throw new System.NotImplementedException();

        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                //throw new System.NotImplementedException();
                string msg_error = null;
                switch (columnName)
                {
                    case "Cli_DNI":
                        msg_error = validar_Dni();
                        break;
                    case "Cli_Apellido":
                        msg_error = validar_Apellido();
                        break;
                    case "Cli_Nombre":
                        msg_error = validar_Nombre();
                        break;
                    case "Cli_Telefono":
                        msg_error = validar_Telefono();
                        break;
                }
                return msg_error;
            }
        }

        private string validar_Telefono()
        {
            if (String.IsNullOrEmpty(Cli_Telefono))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validar_Nombre()
        {
            if (String.IsNullOrEmpty(Cli_Nombre))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validar_Apellido()
        {
            if (String.IsNullOrEmpty(Cli_Apellido))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validar_Dni()
        {
            if (String.IsNullOrEmpty(Cli_DNI.ToString()))
            {
                return "El valor del campo es obligatorio";
            }
            else if(Cli_DNI < 10000000)
            {
                return "El DNI debe ser de 8 digitos";
            }
            else if(Cli_DNI > 99999999)
            {
                return "El DNI no debe superar los 8 digitos";
            }
            return null;
        }
    }
}
