﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistas.rsc
{
    public static class UsuarioLogin
    {
        public static int usu_Id { get; set; }
        public static string usu_NombreUsuario { get; set; }
        public static string usu_Password { get; set; }
        public static string usu_ApellidoNombre { get; set; }
        public static int rol_Codigo { get; set; }
        public static bool usu_Disponible { get; set; }
    }
}
