using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Redes_sociales : DALBase
    {
        public int id { get; set; }
        public string icono { get; set; }
        public string nombre { get; set; }
        public string link { get; set; }
        public int id_sitio { get; set; }

        public Redes_sociales()
        {
            id = 0;
            icono = string.Empty;
            nombre = string.Empty;
            link = string.Empty;
            id_sitio = 0;
        }

        private static List<Redes_sociales> mapeo(SqlDataReader dr)
        {
            List<Redes_sociales> lst = new List<Redes_sociales>();
            Redes_sociales obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Redes_sociales();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.icono = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.nombre = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.link = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.id_sitio = dr.GetInt32(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Redes_sociales> read()
        {
            try
            {
                List<Redes_sociales> lst = new List<Redes_sociales>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Redes_sociales";
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

        public static Redes_sociales getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Redes_sociales WHERE");
                sql.AppendLine("id = @id");
                Redes_sociales obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Redes_sociales> lst = mapeo(dr);
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

        public static int insert(Redes_sociales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Redes_sociales(");
                sql.AppendLine("id");
                sql.AppendLine(", icono");
                sql.AppendLine(", nombre");
                sql.AppendLine(", link");
                sql.AppendLine(", id_sitio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @icono");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @link");
                sql.AppendLine(", @id_sitio");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@icono", obj.icono);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@link", obj.link);
                    cmd.Parameters.AddWithValue("@id_sitio", obj.id_sitio);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Redes_sociales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Redes_sociales SET");
                sql.AppendLine(", link=@link");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@link", obj.link);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Redes_sociales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Redes_sociales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

    }
}

