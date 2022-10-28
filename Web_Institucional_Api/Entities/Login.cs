using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Web_Institucional_Api.Entities
{
    public class Login
    {
        public int cod_usuario { get; set; }

        public string nombre_completo { get; set; }

        public int LEGAJO { get; set; }

        public bool ADMINISTRADOR { get; set; }

        public string nombre { get; set; }

        public string PASSWD { get; set; }

        public string EMAIL { get; set; }

        public bool BAJA { get; set; }

        public int cod_oficina { get; set; }

        public string nombre_oficina { get; set; }
        public Login()
        {

        }
        public Login ValidUser(string user, string password, string nombreUsuario)
        {

            bool resultado = false;
            string md5Passwd = "";
            string md5Passwd_ = "";
            bool? mExiste = false;


            SqlCommand cmd;
            SqlDataReader sqlDataReader;
            SqlConnection cn = null;
            StringBuilder strSQL = new StringBuilder();

            MD5Encryption objMD5 = new MD5Encryption();

            user = user.Replace("'", "").Replace(",", "").Replace("=", "");

            strSQL.AppendLine("SELECT * From USUARIOS_V2 WHERE nombre = @user");
            //strSQL += "SELECT * From USUARIOS_V2 WHERE nombre='" + user + "'";
            cmd = new SqlCommand();
            Login obj = null;
            cmd.Parameters.Add(new SqlParameter("@user", user));
            try
            {
                cn = DALBase.getConnection("SIIMVA");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();

                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    int COD_USUARIO = sqlDataReader.GetOrdinal("COD_USUARIO");
                    int NOMBRE = sqlDataReader.GetOrdinal("NOMBRE");
                    int LEGAJO = sqlDataReader.GetOrdinal("LEGAJO");
                    int ADMINISTRADOR = sqlDataReader.GetOrdinal("ADMINISTRADOR");
                    int NOMBRE_COMPLETO = sqlDataReader.GetOrdinal("NOMBRE_COMPLETO");
                    int PASSWD = sqlDataReader.GetOrdinal("PASSWD");
                    int EMAIL = sqlDataReader.GetOrdinal("EMAIL");
                    int BAJA = sqlDataReader.GetOrdinal("BAJA");
                    int COD_OFICINA = sqlDataReader.GetOrdinal("COD_OFICINA");

                    while (sqlDataReader.Read())
                    {
                        mExiste = true;
                        nombreUsuario = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nombre"));
                        md5Passwd = sqlDataReader.GetString(sqlDataReader.GetOrdinal("passwd"));
                        md5Passwd_ = objMD5.EncryptMD5(password.Trim().ToUpper() + user.Trim().ToUpper());
                        if (md5Passwd == md5Passwd_)
                        {
                            obj = new Login();
                            if (!sqlDataReader.IsDBNull(ADMINISTRADOR))
                                obj.ADMINISTRADOR = sqlDataReader.GetBoolean(ADMINISTRADOR);
                            if (!sqlDataReader.IsDBNull(BAJA))
                                obj.BAJA = sqlDataReader.GetBoolean(BAJA);
                            if (!sqlDataReader.IsDBNull(COD_USUARIO))
                                obj.cod_usuario = sqlDataReader.GetInt32(COD_USUARIO);
                            if (!sqlDataReader.IsDBNull(EMAIL))
                                obj.EMAIL = sqlDataReader.GetString(EMAIL);
                            if (!sqlDataReader.IsDBNull(LEGAJO))
                                obj.LEGAJO = sqlDataReader.GetInt32(LEGAJO);
                            if (!sqlDataReader.IsDBNull(NOMBRE))
                                obj.nombre = sqlDataReader.GetString(NOMBRE);
                            if (!sqlDataReader.IsDBNull(NOMBRE_COMPLETO))
                                obj.nombre_completo = sqlDataReader.GetString(NOMBRE_COMPLETO);
                            if (!sqlDataReader.IsDBNull(PASSWD))
                                obj.PASSWD = sqlDataReader.GetString(PASSWD);
                            if (!sqlDataReader.IsDBNull(COD_OFICINA))
                                obj.cod_oficina = sqlDataReader.GetInt32(COD_OFICINA);

                        }

                    }
                }
                return obj;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autenticación!!!.");
            }

            finally
            {
                cn.Close();
                objMD5 = null;
            }
        }

        public bool ValidaPermiso(string User, string Proceso)
        {
            string strSQL = "";
            strSQL = "SELECT * FROM PROCESOS_V2 a, PROCESOS_x_USUARIO_V2 b, ";
            strSQL += "USUARIOS_V2 c WHERE ";
            strSQL += "c.nombre='" + User + "' AND ";
            strSQL += "c.cod_usuario=b.cod_usuario AND ";
            strSQL += "b.cod_proceso=a.cod_proceso AND ";
            strSQL += "a.proceso='" + Proceso + "'";



            SqlCommand cmd;
            SqlDataReader reader;
            SqlConnection cn = null;
            MD5Encryption objMD5 = new MD5Encryption();

            cn = DALBase.getConnection("SIIMVA");
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL.ToString();
            cmd.Connection.Open();

            try
            {
                //cn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    strSQL = "SELECT * FROM USUARIOS_V2 WHERE ";
                    strSQL += "administrador=1 AND ";
                    strSQL += "nombre='" + User + "'";
                    reader.Close();
                    cmd.CommandText = strSQL.ToString();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autorización de Permiso!!!.");
            }
            finally
            {
                cn.Close();
            }
        }


        public bool ValidaPermiso(string User, string Proceso, out int id_oficina)
        {
            string strSQL = "";
            strSQL = "SELECT * FROM PROCESOS_V2 a, PROCESOS_x_USUARIO_V2 b, ";
            strSQL += "USUARIOS_V2 c WHERE ";
            strSQL += "c.nombre='" + User + "' AND ";
            strSQL += "c.cod_usuario=b.cod_usuario AND ";
            strSQL += "b.cod_proceso=a.cod_proceso AND ";
            strSQL += "a.proceso='" + Proceso + "'";

            SqlCommand cmd;

            SqlDataReader reader;
            SqlConnection cn = null;
            MD5Encryption objMD5 = new MD5Encryption();

            cn = DALBase.getConnection("SIIMVA");
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL.ToString();
            cmd.Connection.Open();

            try
            {
                //cn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id_oficina = Convert.IsDBNull(reader["cod_oficina"]) ? 0 : Convert.ToInt16(reader["cod_oficina"]);
                    reader.Close();
                    return true;
                }
                else
                {
                    strSQL = "SELECT * FROM USUARIOS_V2 WHERE ";
                    strSQL += "administrador=1 AND ";
                    strSQL += "nombre='" + User + "'";
                    reader.Close();
                    cmd.CommandText = strSQL.ToString();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_oficina = Convert.IsDBNull(reader["cod_oficina"]) ? 0 : Convert.ToInt16(reader["cod_oficina"]);
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        id_oficina = 0;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autorización de Permiso!!!.");
            }
            finally { cn.Close(); }
        }



        public bool AutorizaOpcionesMenu(int id_opcion, string login)
        {
            bool autoriza = false;
            string strSQL = " ";
            strSQL += "SELECT  *    ";
            strSQL += "FROM SE_OPCIONES_X_USUARIO a ";
            strSQL += "join SE_USUARIO b on ";
            strSQL += "a.id_usuario=b.id_usuario ";
            strSQL += "WHERE b.login='" + login + "' ";
            strSQL += "AND a.id_opcion=" + id_opcion.ToString();

            SqlCommand cmd;
            SqlDataReader reader;
            SqlConnection cn = null;
            MD5Encryption objMD5 = new MD5Encryption();

            cn = DALBase.getConnection("SIIMVA");
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL.ToString();
            cmd.Connection.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                autoriza = true;
            }
            cn.Close();
            return autoriza;
        }
    }
}
