using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class archivos_x_contenido : DALBase
    {
        public int id { get; set; }
        public string nombre_archivo { get; set; }
        public string link_archivo { get; set; }
        public int id_contenido { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public int id_news { get; set; }    
        public archivos_x_contenido()
        {
            id = 0;
            nombre_archivo = string.Empty;
            link_archivo = string.Empty;
            id_contenido = 0;
            orden = 0;
            activo = true;
            id_news = 0;    
        }

        private static List<archivos_x_contenido> mapeo(SqlDataReader dr)
        {
            List<archivos_x_contenido> lst = new List<archivos_x_contenido>();
            archivos_x_contenido obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new archivos_x_contenido();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre_archivo = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.link_archivo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.id_contenido = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.orden = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.activo = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.id_news = dr.GetInt32(6); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<archivos_x_contenido> read(int id_contenido)
        {
            try
            {
                List<archivos_x_contenido> lst = new List<archivos_x_contenido>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM archivos_x_contenido WHERE id_contenido=@id_contenido ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_contenido", id_contenido);
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
        public static List<archivos_x_contenido> readNews(int id_news)
        {
            try
            {
                List<archivos_x_contenido> lst = new List<archivos_x_contenido>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM archivos_x_contenido WHERE id_news=@id_news ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_news", id_news);
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
        public static List<archivos_x_contenido> readActivos(int id_contenido)
        {
            try
            {
                List<archivos_x_contenido> lst = new List<archivos_x_contenido>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM archivos_x_contenido WHERE id_contenido=@id_contenido AND activo=1 ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_contenido", id_contenido);
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
        public static List<archivos_x_contenido> readActivosNews(int id_news)
        {
            try
            {
                List<archivos_x_contenido> lst = new List<archivos_x_contenido>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM archivos_x_contenido WHERE id_news=@id_news AND activo=1 ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_news", id_news);
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
        public static archivos_x_contenido getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM archivos_x_contenido WHERE");
                sql.AppendLine("id = @id");
                archivos_x_contenido obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<archivos_x_contenido> lst = mapeo(dr);
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

        public static int insert(archivos_x_contenido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO archivos_x_contenido(");
                sql.AppendLine("nombre_archivo");
                sql.AppendLine(", link_archivo");
                sql.AppendLine(", id_contenido");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                sql.AppendLine(", id_news");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre_archivo");
                sql.AppendLine(", @link_archivo");
                sql.AppendLine(", @id_contenido");
                sql.AppendLine(", @orden");
                sql.AppendLine(", 1");
                sql.AppendLine(", @id_news");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_archivo", obj.nombre_archivo);
                    cmd.Parameters.AddWithValue("@link_archivo", obj.link_archivo);
                    cmd.Parameters.AddWithValue("@id_contenido", obj.id_contenido);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@id_news", obj.id_news);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(archivos_x_contenido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  archivos_x_contenido SET");
                sql.AppendLine("nombre_archivo=@nombre_archivo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_archivo", obj.nombre_archivo);
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
        public static void activaDesactiva(int id, bool activo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  archivos_x_contenido SET");
                sql.AppendLine("activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@activo", activo);
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
        public static void setOrden(int id, int orden)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  archivos_x_contenido SET");
                sql.AppendLine("orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@orden", orden);
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
        public static int getMaxOrden(int id_contenido)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(orden),0) FROM archivos_x_contenido");
                sql.AppendLine("WHERE id_contenido=@id_contenido");

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_contenido", id_contenido);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getMaxOrdenNews(int id_news)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(orden),0) FROM archivos_x_contenido");
                sql.AppendLine("WHERE id_news=@id_news");

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_news", id_news);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
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
                sql.AppendLine("DELETE  archivos_x_contenido ");
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

