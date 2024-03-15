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
    
    public class ActiviDao : ConnectionToSql
    {
        DataTable tabla = new DataTable();
        public DataTable Mostrar()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "Select *from ACTIVIDAD";
                    SqlDataReader read = comando.ExecuteReader();
                    tabla.Load(read);
                    return tabla;
                }
            }
        }
        public DataTable MostrarEjercicios(int ideje)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "Select *from EJERCICIO WHERE ID_ACTIVIDAD=" + ideje + "";
                    SqlDataReader read = comando.ExecuteReader();
                    tabla.Load(read);
                    return tabla;
                }
            }
        }
        public DataTable MostrarForos()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "Select *from CONSULTA";
                    SqlDataReader read = comando.ExecuteReader();
                    tabla.Load(read);
                    return tabla;
                }
            }
        }
        public DataTable MostrarRespu(int idcon)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "Select *from RESPUESTA WHERE ID_CONSULTA=" + idcon + "";
                    SqlDataReader read = comando.ExecuteReader();
                    tabla.Load(read);
                    return tabla;
                }
            }
        }
        int row = 6;
        public void InsertActivi(string titulo, string descripcion, int numenunciado, string usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into ACTIVIDAD (TITULO,DESCRIPCION,NUMENUNCIADOS,ID_USUARIO) values ('" + titulo+ "','"+descripcion+ "'," +numenunciado+ ",'" +usuario+ "')";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@numenunciado", numenunciado);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void DeleteActivi(int idac)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete ACTIVIDAD where ID_ACTIVIDAD=@idac";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idac", idac);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }

        public void InsertEjerci(int idactividad, string enunciado, string toption, string f1option, string f2option, string f3option)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into EJERCICIO (ID_ACTIVIDAD,ENUNCIADO,T_OPTION,F1_OPTION,F2_OPTION,F3_OPTION) values (" + idactividad + ",'" + enunciado + "','" + toption + "','" + f1option + "','" + f2option + "','" + f3option + "')";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idactividad", idactividad);
                    comando.Parameters.AddWithValue("@enunciado", enunciado);
                    comando.Parameters.AddWithValue("@toption", toption);
                    comando.Parameters.AddWithValue("@f1option", f1option);
                    comando.Parameters.AddWithValue("@f2option", f2option);
                    comando.Parameters.AddWithValue("@f3option", f3option);
                    row = row+1;
                    comando.CommandType = CommandType.Text;   
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void CargarEjercicios(int idact, int ideje)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM EJERCICIO WHERE ID_EJERCICIO=@ideje and ID_ACTIVIDAD=@idact";
                    command.Parameters.AddWithValue("@idact", idact);
                    command.Parameters.AddWithValue("@ideje", ideje);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ActiviEjerCache.ENUNCIADO = reader.GetString(3);
                            ActiviEjerCache.OPTIONTRUE = reader.GetString(4);
                            ActiviEjerCache.OPTIONFALSE1 = reader.GetString(5);
                            ActiviEjerCache.OPTIONFALSE2 = reader.GetString(6);
                            ActiviEjerCache.OPTIONFALSE3 = reader.GetString(7);


                        }

                }
            }
        }
        public void DeleteExercise(int idac)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete EJERCICIO where ID_ACTIVIDAD=@idac";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idac", idac);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public void InsertPublic(string idusuario, string titulo, int dia, int mes, int anio, string contenido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into CONSULTA (ID_USUARIO,TITULO,DIACONS,MESCONS,ANIOCONS,CONTENIDO) values ('" + idusuario + "','" + titulo + "'," + dia + "," + mes + "," + anio + ",'" + contenido + "')";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@dia", dia);
                    comando.Parameters.AddWithValue("@mes", mes);
                    comando.Parameters.AddWithValue("@anio", anio);
                    comando.Parameters.AddWithValue("@contenido", contenido);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void CargarPublicacion(int idcon)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM CONSULTA WHERE ID_CONSULTA=@idcon";
                    command.Parameters.AddWithValue("@idcon", idcon);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PubliCache.ID_USUARIO = reader.GetString(1);
                        PubliCache.TITULO = reader.GetString(2);
                        PubliCache.DIACONS = reader.GetInt32(3);
                        PubliCache.MESCONS = reader.GetInt32(4);
                        PubliCache.ANIOCONS = reader.GetInt32(5);
                        PubliCache.CONTENIDO = reader.GetString(6);

                    }

                }
            }
        }
        public void DeletePublication(int idco)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete CONSULTA where ID_CONSULTA=@idco";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idco", idco);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public void InsertComent(int idcon, string idusuario, string com, int dia, int mes, int anio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "insert into RESPUESTA (ID_CONSULTA,ID_USUARIO,CONTENIDO,DIARESP,MESRESP,ANIORESP) values (" + idcon + ",'" + idusuario + "','" + com + "'," + dia + "," + mes + "," + anio + ")";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcon", idcon);
                    comando.Parameters.AddWithValue("@idusuario", idusuario);
                    comando.Parameters.AddWithValue("@titulo", com);
                    comando.Parameters.AddWithValue("@dia", dia);
                    comando.Parameters.AddWithValue("@mes", mes);
                    comando.Parameters.AddWithValue("@anio", anio);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
            }
        }
        public void DeleteComment(int idpub, int idcom)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete RESPUESTA where ID_CONSULTA=@idpub and ID_RESPUESTA=@idcom";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idpub", idpub);
                    command.Parameters.AddWithValue("@idcom", idcom);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public void DeleteCommentPublication(int idco)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete RESPUESTA where ID_CONSULTA=@idco";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@idco", idco);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
    }
}

