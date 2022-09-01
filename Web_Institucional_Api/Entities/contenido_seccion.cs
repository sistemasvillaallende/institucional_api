using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class contenido_seccion : DALBase
    {
        public int id { get; set; }
        public int id_seccion { get; set; }
        public string titulo_contenido { get; set; }
        public string contenido_contenido { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public string imagen { get; set; }
        public string filtro_imagen { get; set; }
        public string html { get; set; }

        public contenido_seccion()
        {
            id = 0;
            id_seccion = 0;
            titulo_contenido = string.Empty;
            contenido_contenido = string.Empty;
            orden = 0;
            activo = false;
            imagen = string.Empty;
            filtro_imagen = string.Empty;
            html = string.Empty;
        }

        private static List<contenido_seccion> mapeo(SqlDataReader dr)
        {
            List<contenido_seccion> lst = new List<contenido_seccion>();
            contenido_seccion obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new contenido_seccion();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_seccion = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.titulo_contenido = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.contenido_contenido = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.orden = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.activo = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.imagen = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.filtro_imagen = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.html = dr.GetString(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<contenido_seccion> read()
        {
            try
            {
                List<contenido_seccion> lst = new List<contenido_seccion>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM contenido_seccion";
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

        public static contenido_seccion getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM contenido_seccion WHERE");
                contenido_seccion obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<contenido_seccion> lst = mapeo(dr);
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

        public static int insert(contenido_seccion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO contenido_seccion(");
                sql.AppendLine("id");
                sql.AppendLine(", id_seccion");
                sql.AppendLine(", titulo_contenido");
                sql.AppendLine(", contenido_contenido");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                sql.AppendLine(", imagen");
                sql.AppendLine(", filtro_imagen");
                sql.AppendLine(", html");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @id_seccion");
                sql.AppendLine(", @titulo_contenido");
                sql.AppendLine(", @contenido_contenido");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @imagen");
                sql.AppendLine(", @filtro_imagen");
                sql.AppendLine(", @html");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@titulo_contenido", obj.titulo_contenido);
                    cmd.Parameters.AddWithValue("@contenido_contenido", obj.contenido_contenido);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@filtro_imagen", obj.filtro_imagen);
                    cmd.Parameters.AddWithValue("@html", obj.html);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(contenido_seccion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  contenido_seccion SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", id_seccion=@id_seccion");
                sql.AppendLine(", titulo_contenido=@titulo_contenido");
                sql.AppendLine(", contenido_contenido=@contenido_contenido");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", imagen=@imagen");
                sql.AppendLine(", filtro_imagen=@filtro_imagen");
                sql.AppendLine(", html=@html");
                sql.AppendLine("WHERE");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@titulo_contenido", obj.titulo_contenido);
                    cmd.Parameters.AddWithValue("@contenido_contenido", obj.contenido_contenido);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@filtro_imagen", obj.filtro_imagen);
                    cmd.Parameters.AddWithValue("@html", obj.html);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(contenido_seccion obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  contenido_seccion ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

