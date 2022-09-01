using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Carrusel : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public string resenia { get; set; }
        public string titulo { get; set; }
        public string bajada { get; set; }
        public string callToAction { get; set; }
        public string callToActionTipo { get; set; }
        public string callToActionLink { get; set; }
        public bool activo { get; set; }
        public string imgDerecha { get; set; }

        public Carrusel()
        {
            id = 0;
            nombre = string.Empty;
            img = string.Empty;
            resenia = string.Empty;
            titulo = string.Empty;
            bajada = string.Empty;
            callToAction = string.Empty;
            callToActionTipo = string.Empty;
            callToActionLink = string.Empty;
            activo = false;
            imgDerecha = string.Empty;
        }

        private static List<Carrusel> mapeo(SqlDataReader dr)
        {
            List<Carrusel> lst = new List<Carrusel>();
            Carrusel obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Carrusel();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.img = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.resenia = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.titulo = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.bajada = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.callToAction = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.callToActionTipo = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.callToActionLink = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.activo = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.imgDerecha = dr.GetString(10); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Carrusel> read()
        {
            try
            {
                List<Carrusel> lst = new List<Carrusel>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Carrusel";
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
        public static List<Carrusel> readActivos()
        {
            try
            {
                List<Carrusel> lst = new List<Carrusel>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Carrusel WHERE activo = 1";
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
        public static Carrusel getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Carrusel WHERE");
                sql.AppendLine("id = @id");
                Carrusel obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Carrusel> lst = mapeo(dr);
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
        public static int insert(Carrusel obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Carrusel(");
                sql.AppendLine("nombre");
                sql.AppendLine(", img");
                sql.AppendLine(", resenia");
                sql.AppendLine(", titulo");
                sql.AppendLine(", bajada");
                sql.AppendLine(", callToAction");
                sql.AppendLine(", callToActionTipo");
                sql.AppendLine(", callToActionLink");
                sql.AppendLine(", activo");
                sql.AppendLine(", imgDerecha");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @img");
                sql.AppendLine(", @resenia");
                sql.AppendLine(", @titulo");
                sql.AppendLine(", @bajada");
                sql.AppendLine(", @callToAction");
                sql.AppendLine(", @callToActionTipo");
                sql.AppendLine(", @callToActionLink");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @imgDerecha");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@bajada", obj.bajada);
                    cmd.Parameters.AddWithValue("@callToAction", obj.callToAction);
                    cmd.Parameters.AddWithValue("@callToActionTipo", obj.callToActionTipo);
                    cmd.Parameters.AddWithValue("@callToActionLink", obj.callToActionLink);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@imgDerecha", obj.imgDerecha);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(Carrusel obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Carrusel SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", img=@img");
                sql.AppendLine(", resenia=@resenia");
                sql.AppendLine(", titulo=@titulo");
                sql.AppendLine(", bajada=@bajada");
                sql.AppendLine(", callToAction=@callToAction");
                sql.AppendLine(", callToActionTipo=@callToActionTipo");
                sql.AppendLine(", callToActionLink=@callToActionLink");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", imgDerecha=@imgDerecha");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@img", obj.img);
                    cmd.Parameters.AddWithValue("@resenia", obj.resenia);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@bajada", obj.bajada);
                    cmd.Parameters.AddWithValue("@callToAction", obj.callToAction);
                    cmd.Parameters.AddWithValue("@callToActionTipo", obj.callToActionTipo);
                    cmd.Parameters.AddWithValue("@callToActionLink", obj.callToActionLink);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@imgDerecha", obj.imgDerecha);
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
        public static void activaDesactiva(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Carrusel SET");
                sql.AppendLine("activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@activo", activa);
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
                sql.AppendLine("DELETE  Carrusel ");
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

