using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Common.Cache;


namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        //Attributes
        private string idusuario;
        private string contrasenia;
        private string descripcion;
        private string nombre;
        private string apellido;
        private string correo;

        public UserModel(string idusuario, string contrasenia, string descripcion, string nombre, string apellido, string correo)
        {
            this.idusuario = idusuario;
            this.contrasenia = contrasenia;
            this.descripcion = descripcion;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
        }

        public UserModel()
        {

        }

        public string editUserProfile() {
            try
            {
                userDao.editProfile(idusuario, contrasenia, descripcion, nombre, apellido, correo);
                LoginUser(idusuario,contrasenia);
                return "Your profile as been successfully update";
            }
            catch (Exception ex)
            {
                return "Username is already registered, try another "+ex;
            }

        }

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public bool editPassword(string user, string pass)
        {
            if (user == UserLoginCache.ID_USUARIO){
            
            }
            return true;

        }

        public void InsertUS(string idusuario, string pais, string correo, string nombre, string apellido, string contrasenia, string day, string moth, string year, string description, string type)
        {
            userDao.InsertUser(idusuario, pais, correo, nombre, apellido, contrasenia, Convert.ToInt32(day), Convert.ToInt32(moth), Convert.ToInt32(year), description, type);
        }
        public void InsertME(string tipomedalla, string idusuario, string idactividad)
        {
            userDao.InsertMedal(tipomedalla, idusuario, Convert.ToInt32(idactividad));
        }
        public void DeleteME(string idac)
        {
            userDao.DeleteMedal(Convert.ToInt32(idac));
        }

        public DataTable ShowMedallas(string idusuario)
        {
            DataTable tabla = new DataTable();
            tabla = userDao.MostrarMedallas(idusuario);
            return tabla;
        }
        public void CargarUsuario(string user)
        {
            userDao.LoadUser(user);
        }
    }
}
