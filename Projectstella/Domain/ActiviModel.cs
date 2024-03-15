using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace Domain
{
    public class ActiviModel {
        
        ActiviDao actiDao = new ActiviDao();


        private ActiviDao objetoCD = new ActiviDao();
        public DataTable MostrarActi()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarForo()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarForos();
            return tabla;
        }
        public DataTable MostrarTablaEjer(string ideje)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEjercicios(Convert.ToInt32(ideje));
            return tabla;
        }
        public DataTable MostrarResp(string idcon)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarRespu(Convert.ToInt32(idcon));
            return tabla;
        }
        public void MostrarEje(string idact, string ideje)
        {
            actiDao.CargarEjercicios(Convert.ToInt32(idact), Convert.ToInt32(ideje));
        }
        public void InsertarAC(string titulo, string descripcion, string numenunciado, string usuario)
        {
            objetoCD.InsertActivi(titulo, descripcion, Convert.ToInt32(numenunciado), usuario);
        }
        public void DeleteAC(string idac)
        {
            objetoCD.DeleteActivi(Convert.ToInt32(idac));
        }
        public void InsertarEJ(string idactividad, string enunciado, string toption, string f1option, string f2option, string f3option)
        {
            objetoCD.InsertEjerci(Convert.ToInt32(idactividad), enunciado, toption, f1option, f2option, f3option);
        }
        public void DeleteEJ(string idac)
        {
            objetoCD.DeleteExercise(Convert.ToInt32(idac));
        }
        public void InsertarPU(string idusuario, string titulo, string dia, string mes, string anio, string contenido)
        {
            objetoCD.InsertPublic(idusuario, titulo, Convert.ToInt32(dia), Convert.ToInt32(mes), Convert.ToInt32(anio), contenido);
        }
        public void DeletePU(string idac)
        {
            objetoCD.DeletePublication(Convert.ToInt32(idac));
        }
        public void MostrarPub(string idcon)
        {
            actiDao.CargarPublicacion(Convert.ToInt32(idcon));
        }
        public void InsertarCO(string idcon, string idusuario, string com, string dia, string mes, string anio)
        {
            objetoCD.InsertComent(Convert.ToInt32(idcon), idusuario, com, Convert.ToInt32(dia), Convert.ToInt32(mes), Convert.ToInt32(anio));
        }
        public void DeleteCO(string idpub,string idcom)
        {
            objetoCD.DeleteComment(Convert.ToInt32(idpub), Convert.ToInt32(idcom));
        }
        public void DeleteCOPU(string idco)
        {
            objetoCD.DeleteCommentPublication(Convert.ToInt32(idco));
        }

    }
}
