using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class AccionesPrincipales : DALBase
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public string icono { get; set; }
        public string callToAction { get; set; }
        public string callToActionLink { get; set; }
        public string callToActionTarget { get; set; }
        public int id_sitio { get; set; }
        public AccionesPrincipales()
        {
            id = 0;
            titulo = string.Empty;
            subtitulo = string.Empty;
            icono = string.Empty;
            callToAction = string.Empty;
            callToActionLink = string.Empty;
            callToActionTarget = string.Empty;
            id_sitio = 0;
        }

        private static List<AccionesPrincipales> mapeo(SqlDataReader dr)
        {
            List<AccionesPrincipales> lst = new List<AccionesPrincipales>();
            AccionesPrincipales obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new AccionesPrincipales();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.titulo = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.subtitulo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.icono = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.callToAction = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.callToActionLink = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.callToActionTarget = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.id_sitio = dr.GetInt32(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<AccionesPrincipales> read()
        {
            try
            {
                List<AccionesPrincipales> lst = new List<AccionesPrincipales>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AccionesPrincipales";
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
        public static List<AccionesPrincipales> read(int idSitio)
        {
            try
            {
                List<AccionesPrincipales> lst = new List<AccionesPrincipales>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AccionesPrincipales WHERE id_sitio=@id_sitio";
                    cmd.Parameters.AddWithValue("@id_sitio", idSitio);
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
        public static AccionesPrincipales getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM AccionesPrincipales WHERE");
                sql.AppendLine("id = @id");
                AccionesPrincipales obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<AccionesPrincipales> lst = mapeo(dr);
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

        public static int insert(AccionesPrincipales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO AccionesPrincipales(");
                sql.AppendLine("titulo");
                sql.AppendLine(", subtitulo");
                sql.AppendLine(", icono");
                sql.AppendLine(", callToAction");
                sql.AppendLine(", callToActionLink");
                sql.AppendLine(", callToActionTarget");
                sql.AppendLine(", id_sitio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@titulo");
                sql.AppendLine(", @subtitulo");
                sql.AppendLine(", @icono");
                sql.AppendLine(", @callToAction");
                sql.AppendLine(", @callToActionLink");
                sql.AppendLine(", @callToActionTarget");
                sql.AppendLine(", @id_sitio");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@subtitulo", obj.subtitulo);
                    cmd.Parameters.AddWithValue("@icono", obj.icono);
                    cmd.Parameters.AddWithValue("@callToAction", obj.callToAction);
                    cmd.Parameters.AddWithValue("@callToActionLink", obj.callToActionLink);
                    cmd.Parameters.AddWithValue("@callToActionTarget", obj.callToActionTarget);
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

        public static void update(AccionesPrincipales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  AccionesPrincipales SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine(", subtitulo=@subtitulo");
                sql.AppendLine(", icono=@icono");
                sql.AppendLine(", callToAction=@callToAction");
                sql.AppendLine(", callToActionLink=@callToActionLink");
                sql.AppendLine(", callToActionTarget=@callToActionTarget");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@subtitulo", obj.subtitulo);
                    cmd.Parameters.AddWithValue("@icono", obj.icono);
                    cmd.Parameters.AddWithValue("@callToAction", obj.callToAction);
                    cmd.Parameters.AddWithValue("@callToActionLink", obj.callToActionLink);
                    cmd.Parameters.AddWithValue("@callToActionTarget", obj.callToActionTarget);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(AccionesPrincipales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  AccionesPrincipales ");
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

