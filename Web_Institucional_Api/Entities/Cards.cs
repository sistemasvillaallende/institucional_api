using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Cards : DALBase
    {
        public int id { get; set; }
        public string imagen { get; set; }
        public string titulo { get; set; }
        public string bajada { get; set; }
        public string callToActionTexto { get; set; }
        public string callToActionlink { get; set; }
        public string callToActionTarget { get; set; }
        public bool activo { get; set; }
        public int orden { get; set; }
        public int id_seccion { get; set; }
        public int id_page { get; set; }
        public string callToActionTipo { get; set; }
        public int id_page_destino { get; set; }
        public Cards()
        {
            id = 0;
            imagen = string.Empty;
            titulo = string.Empty;
            bajada = string.Empty;
            callToActionTexto = string.Empty;
            callToActionlink = string.Empty;
            callToActionTarget = string.Empty;
            activo = false;
            orden = 0;
            id_seccion = 0;
            id_page = 0;
            callToActionTipo = string.Empty;
            id_page_destino = 0;
        }

        private static List<Cards> mapeo(SqlDataReader dr)
        {
            List<Cards> lst = new List<Cards>();
            Cards obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Cards();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.imagen = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.titulo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.bajada = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.callToActionTexto = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.callToActionlink = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.callToActionTarget = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.activo = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.orden = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.id_seccion = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.callToActionTipo = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.id_page_destino = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.id_page = dr.GetInt32(12); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Cards> read(int id_seccion)
        {
            try
            {
                List<Cards> lst = new List<Cards>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.id_page
                                        FROM Cards A
                                        INNER JOIN Secciones B ON A.id_seccion=B.id
                                        WHERE id_seccion=@id_seccion ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_seccion", id_seccion);
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
        public static List<Cards> readActivos(int id_seccion)
        {
            try
            {
                List<Cards> lst = new List<Cards>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.id_page
                                        FROM Cards A
                                        INNER JOIN Secciones B ON A.id_seccion=B.id
                                        WHERE id_seccion=@id_seccion AND A.activo=1 
                                        ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_seccion", id_seccion);
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
        public static Cards getByPk(int id)
        {
            try
            {
                Cards obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.id_page
                                        FROM Cards A
                                        INNER JOIN Secciones B ON A.id_seccion=B.id
                                        WHERE id=@id
                                        ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Cards> lst = mapeo(dr);
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
        public static int getMaxOrden(int id_seccion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(orden),0) FROM Cards");
                sql.AppendLine("WHERE id_seccion=@id_seccion");

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_seccion", id_seccion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(Cards obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cards(");
                sql.AppendLine("imagen");
                sql.AppendLine(", titulo");
                sql.AppendLine(", bajada");
                sql.AppendLine(", callToActionTexto");
                sql.AppendLine(", CallToActionlink");
                sql.AppendLine(", CallToActionTarget");
                sql.AppendLine(", callToActionTipo");
                sql.AppendLine(", activo");
                sql.AppendLine(", orden");
                sql.AppendLine(", id_seccion");
                sql.AppendLine(", id_page_destino");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@imagen");
                sql.AppendLine(", @titulo");
                sql.AppendLine(", @bajada");
                sql.AppendLine(", @callToActionTexto");
                sql.AppendLine(", @CallToActionlink");
                sql.AppendLine(", @CallToActionTarget");
                sql.AppendLine(", @callToActionTipo");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @id_seccion");
                sql.AppendLine(", @id_page_destino");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@bajada", obj.bajada);
                    cmd.Parameters.AddWithValue("@callToActionTexto", obj.callToActionTexto);
                    cmd.Parameters.AddWithValue("@CallToActionlink", obj.callToActionlink);
                    cmd.Parameters.AddWithValue("@CallToActionTarget", obj.callToActionTarget);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@id_page_destino", obj.id_page_destino);
                    cmd.Parameters.AddWithValue("@callToActionTipo", obj.callToActionTipo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Cards obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cards SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine(", bajada=@bajada");
                sql.AppendLine(", callToActionTexto=@callToActionTexto");
                sql.AppendLine(", CallToActionlink=@CallToActionlink");
                sql.AppendLine(", CallToActionTarget=@CallToActionTarget");
                sql.AppendLine(", callToActionTipo=@callToActionTipo");
                sql.AppendLine(", id_page_destino=@id_page_destino");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@bajada", obj.bajada);
                    cmd.Parameters.AddWithValue("@callToActionTexto", obj.callToActionTexto);
                    cmd.Parameters.AddWithValue("@CallToActionlink", obj.callToActionlink);
                    cmd.Parameters.AddWithValue("@CallToActionTarget", obj.callToActionTarget);
                    cmd.Parameters.AddWithValue("@id_page_destino", obj.id_page_destino);
                    cmd.Parameters.AddWithValue("@callToActionTipo", obj.callToActionTipo);
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
                sql.AppendLine("UPDATE  Cards SET");
                sql.AppendLine("activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setImagen(int id, string imagen)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cards SET");
                sql.AppendLine("imagen=@imagen");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@imagen", imagen);
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
                sql.AppendLine("UPDATE Cards SET");
                sql.AppendLine("orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@orden", orden);
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
                sql.AppendLine("DELETE  Cards ");
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

