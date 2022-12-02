using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Paginas : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public string nombre_secretario { get; set; }
        public string foto_secretario { get; set; }
        public string direccion { get; set; }
        public string maps { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string interno { get; set; }
        public string contenido_principal { get; set; }
        public List<Secciones> lstSecciones { get; set; }
        public string horario_atension { get; set; }
        public bool deleted { get; set; }
        public bool seccion_pricipal { get; set; }
        public int id_sitio { get; set; }
        public bool seccion_principal_banner { get; set; }

        public Paginas()
        {
            id = 0;
            nombre = string.Empty;
            imagen = string.Empty;
            nombre_secretario = string.Empty;
            foto_secretario = string.Empty;
            direccion = string.Empty;
            maps = string.Empty;
            mail = string.Empty;
            telefono = string.Empty;
            interno = string.Empty;
            contenido_principal = string.Empty;
            lstSecciones = new List<Secciones>();
            horario_atension = string.Empty; 
            deleted = false;
            seccion_pricipal = true;
            id_sitio = 0;
            seccion_principal_banner = false;   
        }

        private static List<Paginas> mapeo(SqlDataReader dr)
        {
            List<Paginas> lst = new List<Paginas>();
            Paginas obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Paginas();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.imagen = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.nombre_secretario = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.foto_secretario = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.direccion = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.maps = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.mail = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.telefono = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.interno = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.contenido_principal = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.horario_atension = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.deleted = dr.GetBoolean(12); }
                    if (!dr.IsDBNull(13)) { obj.id_sitio = dr.GetInt32(13); }
                    if (!dr.IsDBNull(14)) { obj.seccion_pricipal = dr.GetBoolean(14); }
                    if (!dr.IsDBNull(15)) { obj.seccion_principal_banner = dr.GetBoolean(15); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Paginas> read()
        {
            try
            {
                List<Paginas> lst = new List<Paginas>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Paginas WHERE deleted=0";
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
        public static List<ListaSecciones> GetlstSecciones(int idPage)
        {
            try
            {
                ListaSecciones obj = null;
                List<ListaSecciones> lst = new List<ListaSecciones>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT
                                        id,
	                                    CASE tipo
		                                    WHEN 1 THEN 'expansionpanel'
		                                    WHEN 2 THEN 'tabpanel'
		                                    WHEN 3 THEN 'tabpanelvertical'
		                                    WHEN 4 THEN 'geleria'
		                                    WHEN 5 THEN 'agenda'
		                                    WHEN 6 THEN 'news'
		                                    WHEN 7 THEN 'htmllibre'
		                                    WHEN 8 THEN 'cards'
                                            WHEN 9 THEN 'carrusel'
	                                    END, 
                                        background_color
                                    FROM Secciones
                                    WHERE id_page=@id_page AND activo=1 AND deleted=0 ORDER BY orden";
                    cmd.Parameters.AddWithValue("@id_page", idPage);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new ListaSecciones();
                            obj.id = dr.GetInt32(0);
                            obj.tipo = dr.GetString(1);
                            obj.background_color = dr.GetString(2); 
                            lst.Add(obj);
                        }
                    }                      
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Paginas getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Paginas WHERE");
                sql.AppendLine("id = @id");
                Paginas obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Paginas> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                    obj.lstSecciones = Secciones.read(obj.id);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(Paginas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Paginas(");
                sql.AppendLine("nombre");
                sql.AppendLine(", imagen");
                sql.AppendLine(", nombre_secretario");
                sql.AppendLine(", foto_secretario");
                sql.AppendLine(", direccion");
                sql.AppendLine(", maps");
                sql.AppendLine(", mail");
                sql.AppendLine(", telefono");
                sql.AppendLine(", interno");
                sql.AppendLine(", contenido_principal");
                sql.AppendLine(", seccion_pricipal");
                sql.AppendLine(", seccion_principal_banner");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @imagen");
                sql.AppendLine(", @nombre_secretario");
                sql.AppendLine(", @foto_secretario");
                sql.AppendLine(", @direccion");
                sql.AppendLine(", @maps");
                sql.AppendLine(", @mail");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @interno");
                sql.AppendLine(", @contenido_principal");
                sql.AppendLine(", 1");
                sql.AppendLine(", 1");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@nombre_secretario", obj.nombre_secretario);
                    cmd.Parameters.AddWithValue("@foto_secretario", obj.foto_secretario);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@maps", obj.maps);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@interno", obj.interno);
                    cmd.Parameters.AddWithValue("@contenido_principal", obj.contenido_principal);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Paginas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", imagen=@imagen");
                sql.AppendLine(", nombre_secretario=@nombre_secretario");
                sql.AppendLine(", foto_secretario=@foto_secretario");
                sql.AppendLine(", direccion=@direccion");
                sql.AppendLine(", maps=@maps");
                sql.AppendLine(", mail=@mail");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", interno=@interno");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@nombre_secretario", obj.nombre_secretario);
                    cmd.Parameters.AddWithValue("@foto_secretario", obj.foto_secretario);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@maps", obj.maps);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@interno", obj.interno);
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
        public static int insert(string nombre)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Paginas(");
                sql.AppendLine("nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateDatosGenerales(Paginas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("nombre_secretario=@nombre_secretario");
                sql.AppendLine(", foto_secretario=@foto_secretario");
                sql.AppendLine(", direccion=@direccion");
                sql.AppendLine(", maps=@maps");
                sql.AppendLine(", mail=@mail");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", interno=@interno");
                sql.AppendLine(", horario_atension=@horario_atension");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre_secretario", obj.nombre_secretario);
                    cmd.Parameters.AddWithValue("@foto_secretario", obj.foto_secretario);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@maps", obj.maps);
                    cmd.Parameters.AddWithValue("@mail", obj.mail);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@interno", obj.interno);
                    cmd.Parameters.AddWithValue("@horario_atension", obj.horario_atension);
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
        public static void updateNombreImagen(Paginas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", imagen=@imagen");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
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
   
        public static void updateContenidoPrincipal(Paginas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("contenido_principal=@contenido_principal");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@contenido_principal", obj.contenido_principal);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);                    
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
        public static void updateActivaContenidoPrincipal(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("seccion_pricipal=@seccion_pricipal");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@seccion_pricipal", activa);
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
        public static void updateActivaContenidoPrincipalBanner(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paginas SET");
                sql.AppendLine("seccion_principal_banner=@seccion_principal_banner");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@seccion_principal_banner", activa);
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
                sql.AppendLine("UPDATE Paginas SET deleted=1");
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

