using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Institucional : DALBase
    {
        public int id { get; set; }
        public string nombre_sitio { get; set; }
        public string direccion { get; set; }
        public string codigo_postal { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string logo { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public Institucional()
        {
            id = 0;
            nombre_sitio = string.Empty;
            direccion = string.Empty;
            codigo_postal = string.Empty;
            ciudad = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            telefono = string.Empty;
            mail = string.Empty;
            logo = string.Empty;
            facebook = string.Empty;
            instagram = string.Empty;
            twitter = string.Empty;
            youtube = string.Empty;
        }

        private static List<Institucional> mapeo(SqlDataReader dr)
        {
            List<Institucional> lst = new List<Institucional>();
            Institucional obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Institucional();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre_sitio = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.direccion = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.codigo_postal = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.ciudad = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.provincia = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.pais = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.telefono = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.mail = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.logo = dr.GetString(9); }

                    if (!dr.IsDBNull(10)) { obj.facebook = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.instagram = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.twitter = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.youtube = dr.GetString(13); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Institucional> read()
        {
            try
            {
                List<Institucional> lst = new List<Institucional>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Institucional";
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

        public static Institucional getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Institucional WHERE");
                sql.AppendLine("id = @id");
                Institucional obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Institucional> lst = mapeo(dr);
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

        public static int insert(Institucional obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Institucional(");
                sql.AppendLine("nombre_sitio");
                sql.AppendLine(", direccion");
                sql.AppendLine(", codigo_postal");
                sql.AppendLine(", ciudad");
                sql.AppendLine(", provincia");
                sql.AppendLine(", pais");
                sql.AppendLine(", telefono");
                sql.AppendLine(", mail");
                sql.AppendLine(", logo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre_sitio");
                sql.AppendLine(", @direccion");
                sql.AppendLine(", @codigo_postal");
                sql.AppendLine(", @ciudad");
                sql.AppendLine(", @provincia");
                sql.AppendLine(", @pais");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @mail");
                sql.AppendLine(", @logo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_sitio", obj.nombre_sitio);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@codigo_postal", obj.codigo_postal);
                    cmd.Parameters.AddWithValue("@ciudad", obj.ciudad);
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@pais", obj.pais);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@logo", obj.logo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setLogo(Institucional obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Institucional SET");
                sql.AppendLine("logo=@logo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.nombre_sitio);
                    cmd.Parameters.AddWithValue("@logo", obj.logo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(Institucional obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Institucional SET");
                sql.AppendLine("nombre_sitio=@nombre_sitio");
                sql.AppendLine(", direccion=@direccion");
                sql.AppendLine(", codigo_postal=@codigo_postal");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", mail=@mail");
                sql.AppendLine(", facebook=@facebook");
                sql.AppendLine(", instagram=@instagram");
                sql.AppendLine(", twitter=@twitter");
                sql.AppendLine(", youtube=@youtube");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_sitio", obj.nombre_sitio);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@codigo_postal", obj.codigo_postal);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@facebook", obj.facebook);
                    cmd.Parameters.AddWithValue("@instagram", obj.instagram);
                    cmd.Parameters.AddWithValue("@twitter", obj.twitter);
                    cmd.Parameters.AddWithValue("@youtube", obj.youtube);
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
                sql.AppendLine("DELETE  Institucional ");
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

