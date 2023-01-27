using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Menu : DALBase
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int tipo { get; set; }
        public string _target { get; set; }
        public string url { get; set; }
        public int id_padre { get; set; }
        public int id_sitio { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public string destino { get; set; }
        public int id_page { get; set; }
        public List<Menu> lstHijos { get; set; }
        public Menu()
        {
            id = 0;
            texto = string.Empty;
            tipo = 0;
            _target = string.Empty;
            url = string.Empty;
            id_padre = 0;
            id_sitio = 0;   
            orden = 0;  
            activo = true; 
            destino = string.Empty;
            id_page = 0;
            lstHijos = new List<Menu>();
        }

        private static List<Menu> mapeo(SqlDataReader dr)
        {
            List<Menu> lst = new List<Menu>();
            Menu obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Menu();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.texto = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.tipo = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj._target = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.url = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.id_padre = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.id_sitio = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.orden = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.activo = dr.GetBoolean(8); }
                    if (!dr.IsDBNull(9)) { obj.destino = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.id_page = dr.GetInt32(10); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Menu> mapeo2(SqlDataReader dr)
        {
            List<Menu> lst = new List<Menu>();
            Menu obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Menu();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.texto = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.tipo = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj._target = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.url = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.id_padre = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.id_sitio = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.orden = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.activo = dr.GetBoolean(8); }
                    if (!dr.IsDBNull(9)) { obj.destino = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.id_page = dr.GetInt32(10); }
                    obj.lstHijos = readActivos(obj.id, obj.id_sitio);
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Menu> read(int idPadre, int idSitio)
        {
            try
            {
                List<Menu> lst = new List<Menu>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Menu WHERE id_padre=@id_padre AND id_sitio=@id_sitio ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_sitio", idSitio);
                    cmd.Parameters.AddWithValue("@id_padre", idPadre);
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
        public static List<Menu> readActivos(int idPadre, int idSitio)
        {
            try
            {
                List<Menu> lst = new List<Menu>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Menu WHERE activo=1 AND id_padre=@id_padre AND id_sitio=@id_sitio ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_sitio", idSitio);
                    cmd.Parameters.AddWithValue("@id_padre", idPadre);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getMaxOrden(int idPadre)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(orden),0) FROM Menu WHERE id_padre=@id_padre");

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_padre", idPadre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Menu getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Menu WHERE");
                sql.AppendLine("id = @id");
                Menu obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Menu> lst = mapeo(dr);
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

        public static int insert(Menu obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Menu(");
                sql.AppendLine("texto");
                sql.AppendLine(", tipo");
                sql.AppendLine(", _target");
                sql.AppendLine(", url");
                sql.AppendLine(", id_padre");
                sql.AppendLine(", activo");
                sql.AppendLine(", orden");
                sql.AppendLine(", destino");
                sql.AppendLine(", id_page");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@texto");
                sql.AppendLine(", @tipo");
                sql.AppendLine(", @_target");
                sql.AppendLine(", @url");
                sql.AppendLine(", @id_padre");
                sql.AppendLine(", 1");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @destino");
                sql.AppendLine(", @id_page");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Parameters.AddWithValue("@_target", obj._target);
                    cmd.Parameters.AddWithValue("@url", obj.url);
                    cmd.Parameters.AddWithValue("@id_padre", obj.id_padre);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@destino", obj.destino);
                    cmd.Parameters.AddWithValue("@id_page", obj.id_page);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Menu obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Menu SET");
                sql.AppendLine("texto=@texto");
                sql.AppendLine(", tipo=@tipo");
                sql.AppendLine(", _target=@_target");
                sql.AppendLine(", url=@url");
                sql.AppendLine(", destino=@destino");
                sql.AppendLine(", id_page=@id_page");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Parameters.AddWithValue("@_target", obj._target);
                    cmd.Parameters.AddWithValue("@url", obj.url);
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@destino", obj.destino);
                    cmd.Parameters.AddWithValue("@id_page", obj.id_page);
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
                sql.AppendLine("UPDATE  Menu SET");
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
        public static void updateOrden(int id, int orden)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Menu SET");
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
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Menu ");
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

