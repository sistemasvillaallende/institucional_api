using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class NoticiaPrincipal : DALBase
    {
        public int id { get; set; }
        public string encabezado { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public int id_pagina { get; set; }
        public string img { get; set; }
        public NoticiaPrincipal()
        {
            id = 0;
            encabezado = string.Empty;
            titulo = string.Empty;
            contenido = string.Empty;
            id_pagina = 0;
            img = string.Empty;
        }

        private static List<NoticiaPrincipal> mapeo(SqlDataReader dr)
        {
            List<NoticiaPrincipal> lst = new List<NoticiaPrincipal>();
            NoticiaPrincipal obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new NoticiaPrincipal();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.encabezado = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.titulo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.contenido = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.id_pagina = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.img = dr.GetString(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<NoticiaPrincipal> read()
        {
            try
            {
                List<NoticiaPrincipal> lst = new List<NoticiaPrincipal>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM NoticiaPrincipal";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static NoticiaPrincipal getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM NoticiaPrincipal WHERE");
                sql.AppendLine("id = @id");
                NoticiaPrincipal obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<NoticiaPrincipal> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(NoticiaPrincipal obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO NoticiaPrincipal(");
                sql.AppendLine("encabezado");
                sql.AppendLine(", titulo");
                sql.AppendLine(", contenido");
                sql.AppendLine(", id_pagina");
                sql.AppendLine(", img");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@encabezado");
                sql.AppendLine(", @titulo");
                sql.AppendLine(", @contenido");
                sql.AppendLine(", @id_pagina");
                sql.AppendLine(", @img");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@encabezado", obj.encabezado);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@contenido", obj.contenido);
                    cmd.Parameters.AddWithValue("@id_pagina", obj.id_pagina);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(NoticiaPrincipal obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  NoticiaPrincipal SET");
                sql.AppendLine("encabezado=@encabezado");
                sql.AppendLine(", titulo=@titulo");
                sql.AppendLine(", contenido=@contenido");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@encabezado", obj.encabezado);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@contenido", obj.contenido);
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setImagen(int id, string img)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  NoticiaPrincipal SET");
                sql.AppendLine("img=@img");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@img", img);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  NoticiaPrincipal ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

