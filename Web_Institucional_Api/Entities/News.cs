using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class News : DALBase
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public DateTime fecha { get; set; }
        public string _fecha { get; set; }
        public string img { get; set; }
        public string cuerpo { get; set; }
        public bool activo { get; set; }
        public int seccion { get; set; }
        public bool pricipal { get; set; }
        public int orden { get; set; }
        public List<images_x_news> lstImages { get; set; }
        public List<files_x_news> lstFiles { get; set; }
        public News()
        {
            id = 0;
            titulo = string.Empty;
            fecha = DateTime.Now;
            img = string.Empty;
            cuerpo = string.Empty;
            activo = false;
            seccion = 0;
            pricipal = false;
            orden = 0;
            lstFiles = new List<files_x_news>();    
            lstImages = new List<images_x_news>();
        }

        private static List<News> mapeo(SqlDataReader dr)
        {
            List<News> lst = new List<News>();
            News obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new News();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.titulo = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.img = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.cuerpo = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.activo = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.seccion = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.pricipal = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.orden = dr.GetInt32(8); }

                    obj._fecha = obj.fecha.ToShortDateString();
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<News> mapeo2(SqlDataReader dr)
        {
            List<News> lst = new List<News>();
            News obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new News();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.titulo = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.img = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.cuerpo = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.activo = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.seccion = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.pricipal = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.orden = dr.GetInt32(8); }
                    obj._fecha = obj.fecha.ToShortDateString();
                    obj.lstImages = images_x_news.read(obj.id);
                    obj.lstFiles = files_x_news.read(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<News> read()
        {
            try
            {
                List<News> lst = new List<News>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM News ORDER BY orden";
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
        public static List<News> getBySeccion(int seccion)
        {
            try
            {
                List<News> lst = new List<News>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM News WHERE seccion=@seccion ORDER BY orden";
                    cmd.Parameters.AddWithValue("@seccion", seccion);
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
        public static List<News> readHome()
        {
            try
            {
                List<News> lst = new List<News>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM News WHERE pricipal=1 ORDER BY orden";
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
        public static News getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM News WHERE");
                sql.AppendLine("id = @id");
                News obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<News> lst = mapeo2(dr);
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

        public static int insert(News obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO News(");
                sql.AppendLine("titulo");
                sql.AppendLine(", fecha");
                sql.AppendLine(", img");
                sql.AppendLine(", cuerpo");
                sql.AppendLine(", activo");
                sql.AppendLine(", seccion");
                sql.AppendLine(", pricipal");
                sql.AppendLine(", orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@titulo");
                sql.AppendLine(", @fecha");
                sql.AppendLine(", @img");
                sql.AppendLine(", @cuerpo");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @pricipal");
                sql.AppendLine(", @orden");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@cuerpo", obj.cuerpo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@pricipal", obj.pricipal);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(News obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  News SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine(", fecha=@fecha");
                sql.AppendLine(", img=@img");
                sql.AppendLine(", cuerpo=@cuerpo");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", seccion=@seccion");
                sql.AppendLine(", pricipal=@pricipal");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@cuerpo", obj.cuerpo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@pricipal", obj.pricipal);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
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

        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  News ");
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

