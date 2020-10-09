using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarCliente
    {
        public Cliente TraerCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.Cli_DNI = 0;
            oCliente.Cli_Nombre = "";
            oCliente.Cli_Apellido = "";
            oCliente.Cli_Telefono = "";
            return oCliente;
        }
    }
}
