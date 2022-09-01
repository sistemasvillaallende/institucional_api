using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Secciones : DALBase
    {
        public int id { get; set; }
        public int id_page { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public bool activo { get; set; }
        public int orden { get; set; }
        public int tipo { get; set; }

        enum tipo_seccion
        {
            
        }
        public Secciones()
        {
            id = 0;
            id_page = 0;
            titulo = string.Empty;
            subtitulo = string.Empty;
            activo = false;
            orden = 0;
            tipo = 0;
        }

        private static List<Secciones> mapeo(SqlDataReader dr)
        {
            List<Secciones> lst = new List<Secciones>();
            Secciones obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Secciones();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_page = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.titulo = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.subtitulo = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.activo = dr.GetBoolean(4); }
                    if (!dr.IsDBNull(5)) { obj.orden = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.tipo = dr.GetInt32(6); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Secciones> read(int idPagina)
        {
            try
            {
                List<Secciones> lst = new List<Secciones>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Secciones WHERE id_page=@id_page";
                    cmd.Parameters.AddWithValue("id_page", idPagina);   
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

        public static Secciones getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Secciones WHERE");
                sql.AppendLine("id = @id");
                Secciones obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Secciones> lst = mapeo(dr);
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

        public static int insert(Secciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Secciones(");
                sql.AppendLine("id_page");
                sql.AppendLine(", titulo");
                sql.AppendLine(", subtitulo");
                sql.AppendLine(", activo");
                sql.AppendLine(", orden");
                sql.AppendLine(", tipo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_page");
                sql.AppendLine(", @titulo");
                sql.AppendLine(", @subtitulo");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @tipo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_page", obj.id_page);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@subtitulo", obj.subtitulo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Secciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Secciones SET");
                sql.AppendLine("id_page=@id_page");
                sql.AppendLine(", titulo=@titulo");
                sql.AppendLine(", subtitulo=@subtitulo");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", tipo=@tipo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_page", obj.id_page);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@subtitulo", obj.subtitulo);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Secciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Secciones ");
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

