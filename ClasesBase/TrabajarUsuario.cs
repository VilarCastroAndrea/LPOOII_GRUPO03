using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
    }
}
