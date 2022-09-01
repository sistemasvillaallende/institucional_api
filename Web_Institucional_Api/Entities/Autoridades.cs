using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Autoridades : DALBase
    {
        public int id { get; set; }
        public string nombre_completo { get; set; }
        public string cargo { get; set; }
        public string mail { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string linkedin { get; set; }
        public string img { get; set; }
        public Autoridades()
        {
            id = 0;
            nombre_completo = string.Empty;
            cargo = string.Empty;
            mail = string.Empty;
            facebook = string.Empty;
            twitter = string.Empty;
            instagram = string.Empty;
            linkedin = string.Empty;
            img = string.Empty;
        }

        private static List<Autoridades> mapeo(SqlDataReader dr)
        {
            List<Autoridades> lst = new List<Autoridades>();
            Autoridades obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Autoridades();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre_completo = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.cargo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.mail = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.facebook = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.twitter = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.instagram = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.linkedin = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.img = dr.GetString(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Autoridades> read()
        {
            try
            {
                List<Autoridades> lst = new List<Autoridades>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Autoridades";
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

        public static Autoridades getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Autoridades WHERE");
                sql.AppendLine("id = @id");
                Autoridades obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Autoridades> lst = mapeo(dr);
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

        public static int insert(Autoridades obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Autoridades(");
                sql.AppendLine("nombre_completo");
                sql.AppendLine(", cargo");
                sql.AppendLine(", mail");
                sql.AppendLine(", facebook");
                sql.AppendLine(", twitter");
                sql.AppendLine(", instagram");
                sql.AppendLine(", linkedin");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre_completo");
                sql.AppendLine(", @cargo");
                sql.AppendLine(", @mail");
                sql.AppendLine(", @facebook");
                sql.AppendLine(", @twitter");
                sql.AppendLine(", @instagram");
                sql.AppendLine(", @linkedin");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_completo", obj.nombre_completo);
                    cmd.Parameters.AddWithValue("@cargo", obj.cargo);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@facebook", obj.facebook);
                    cmd.Parameters.AddWithValue("@twitter", obj.twitter);
                    cmd.Parameters.AddWithValue("@instagram", obj.instagram);
                    cmd.Parameters.AddWithValue("@linkedin", obj.linkedin);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Autoridades obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Autoridades SET");
                sql.AppendLine("nombre_completo=@nombre_completo");
                sql.AppendLine(", cargo=@cargo");
                sql.AppendLine(", mail=@mail");
                sql.AppendLine(", facebook=@facebook");
                sql.AppendLine(", twitter=@twitter");
                sql.AppendLine(", instagram=@instagram");
                sql.AppendLine(", linkedin=@linkedin");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_completo", obj.nombre_completo);
                    cmd.Parameters.AddWithValue("@cargo", obj.cargo);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@facebook", obj.facebook);
                    cmd.Parameters.AddWithValue("@twitter", obj.twitter);
                    cmd.Parameters.AddWithValue("@instagram", obj.instagram);
                    cmd.Parameters.AddWithValue("@linkedin", obj.linkedin);
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
                sql.AppendLine("DELETE  Autoridades ");
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

