using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class images_x_news : DALBase
    {
        public int id { get; set; }
        public int idNews { get; set; }
        public string img { get; set; }
        public int categoria { get; set; }
        public string nombre { get; set; }

        public images_x_news()
        {
            id = 0;
            idNews = 0;
            img = string.Empty;
            categoria = 0;
            nombre = string.Empty;
        }

        private static List<images_x_news> mapeo(SqlDataReader dr)
        {
            List<images_x_news> lst = new List<images_x_news>();
            images_x_news obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new images_x_news();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.idNews = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.img = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.categoria = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<images_x_news> read(int idNews)
        {
            try
            {
                List<images_x_news> lst = new List<images_x_news>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM images_x_news WHERE idNews=@idNews";
                    cmd.Parameters.AddWithValue("@idNews", idNews);
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

        public static images_x_news getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM images_x_news WHERE");
                sql.AppendLine("id = @id");
                images_x_news obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<images_x_news> lst = mapeo(dr);
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

        public static int insert(images_x_news obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO images_x_news(");
                sql.AppendLine("idNews");
                sql.AppendLine(", img");
                sql.AppendLine(", categoria");
                sql.AppendLine(", nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@idNews");
                sql.AppendLine(", @img");
                sql.AppendLine(", @categoria");
                sql.AppendLine(", @nombre");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@idNews", obj.idNews);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@categoria", obj.categoria);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(images_x_news obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  images_x_news SET");
                sql.AppendLine(", img=@img");
                sql.AppendLine(", categoria=@categoria");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@categoria", obj.categoria);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
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
                sql.AppendLine("DELETE  images_x_news ");
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
        public static void deleteAll(int idNews)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE images_x_news ");
                sql.AppendLine("WHERE");
                sql.AppendLine("idNews=@idNews");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@idNews", idNews);
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

