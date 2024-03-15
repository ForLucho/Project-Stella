using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        DataTable tabla = new DataTable();
        public void editProfile(string idusuario, string contrasenia, string descripcion, string nombre, string apellido, string correo)
        {
            using (var connection = GetConnection()){
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "update USUARIO set " +
                        "CONTRASENIA= @contrasenia, DESCRIPCION=@descripcion, NOMBRE=@nombre, APELLIDO=@apellido, CORREO=@correo where ID_USUARIO=@idusuario";
                    command.Parameters.AddWithValue("@idusuario", idusuario);
                    command.Parameters.AddWithValue("@contrasenia", contrasenia);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }  
        }  
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from USUARIO where ID_USUARIO=@user and CONTRASENIA=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read()){
                            UserLoginCache.ID_USUARIO = reader.GetString(0);
                            UserLoginCache.PAIS = reader.GetString(1);
                            UserLoginCache.CORREO = reader.GetString(2);
                            UserLoginCache.NOMBRE = reader.GetString(3);
                            UserLoginCache.APELLIDO = reader.GetString(4);
                            UserLoginCache.CONTRASENIA= reader.GetString(5);
                            UserLoginCache.DIAINICIO = reader.GetInt32(6);
                            UserLoginCache.MESINICIO = reader.GetInt32(7);
                            UserLoginCache.ANIOINICIO = reader.GetInt32(8);
                            UserLoginCache.DESCRIPCION = reader.GetString(9);
                            UserLoginCache.TIPOUSUARIO = reader.GetString(14);
                        }
                        return true;
                    }
                    else
                        return false;


                }
            }
        }
        public void InsertUser(string idusuario, string pais, string correo, string nombre, string apellido, string contrasenia, int day, int moth, int year, string description, string type)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into USUARIO (ID_USUARIO,PAIS,CORREO,NOMBRE,APELLIDO,CONTRASENIA,DIAINICIO,MESINICIO,ANIOINICIO,DESCRIPCION,TIPOUSUARIO) values ('" + idusuario + "','" + pais + "','" + correo + "','" + nombre + "','" + apellido + "', '" + contrasenia + "'," + day + "," + moth + "," + year + ",'" + description + "', '" + type + "')";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    comando.Parameters.AddWithValue("@pais", pais);
                    comando.Parameters.AddWithValue("@correo", correo);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@apellido", apellido);
                    comando.Parameters.AddWithValue("@contrasenia", contrasenia);
                    comando.Parameters.AddWithValue("@day", day);
                    comando.Parameters.AddWithValue("@moth", moth);
                    comando.Parameters.AddWithValue("@year", year);
                    comando.Parameters.AddWithValue("@description", description);
                    comando.Parameters.AddWithValue("@type", type);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void InsertMedal(string tipomedalla, string idusuario, int idactividad)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into MEDALLA (TIPOMEDALLA,ID_USUARIO,ID_ACTIVIDAD)  values ('" + tipomedalla + "','" + idusuario + "'," + idactividad + ")";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@tipomedalla", tipomedalla);
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    comando.Parameters.AddWithValue("@idactividad", idactividad);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void DeleteMedal(int idac)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete MEDALLA where ID_ACTIVIDAD=@idac";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idac", idac);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public DataTable MostrarMedallas(string idusuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "Select *from MEDALLA where ID_USUARIO=@idusuario";
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    SqlDataReader read = comando.ExecuteReader();
                    tabla.Load(read);
                    return tabla;
                }
            }
        }
        public bool LoadUser(string user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from USUARIO where ID_USUARIO=@user";
                    command.Parameters.AddWithValue("@user", user);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.ID_USUARIO = reader.GetString(0);
                            UserCache.PAIS = reader.GetString(1);
                            UserCache.CORREO = reader.GetString(2);
                            UserCache.NOMBRE = reader.GetString(3);
                            UserCache.APELLIDO = reader.GetString(4);
                            UserCache.CONTRASENIA = reader.GetString(5);
                            UserCache.DIAINICIO = reader.GetInt32(6);
                            UserCache.MESINICIO = reader.GetInt32(7);
                            UserCache.ANIOINICIO = reader.GetInt32(8);
                            UserCache.DESCRIPCION = reader.GetString(9);
                            UserCache.TIPOUSUARIO = reader.GetString(14);
                        }
                        return true;
                    }
                    else
                        return false;

                
                }   
            }
        }
    }
}

