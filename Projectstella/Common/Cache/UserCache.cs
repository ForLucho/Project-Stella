using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserCache
    {
        public static string ID_USUARIO { get; set; }
        public static string CONTRASENIA { get; set; }
        public static string PAIS { get; set; }
        public static string CORREO { get; set; }
        public static string NOMBRE { get; set; }
        public static string APELLIDO { get; set; }
        public static object DIAINICIO { get; set; }
        public static object MESINICIO { get; set; }
        public static object ANIOINICIO { get; set; }
        public static string DESCRIPCION { get; set; }
        public static string TIPOUSUARIO { get; set; }
    }
}
