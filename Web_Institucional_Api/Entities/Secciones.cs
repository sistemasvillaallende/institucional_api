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
        public  string _tipo { get; set; }
        public bool deleted { get; set; }
        public string background_color { get; set; }
        public List<contenido_seccion> lstContenido { get; set; }   
        public List<filtros_x_galeria> lstFiltros { get; set; }
        enum tipos_seccion
        {
            paneles_expansibles = 1,
            pestanias_horizontales = 2,
            pestanias_verticales = 3,
            galeria = 4,
            agenda = 5,
            noticias = 6,
            html = 7,
            cards = 8,
            carrusel = 9
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
            deleted = false;
            background_color = string.Empty;    
            lstContenido = new List<contenido_seccion>();
            lstFiltros = new List<filtros_x_galeria>();
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
                    if (!dr.IsDBNull(7)) { obj.deleted = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.background_color = dr.GetString(8); }
                    switch (obj.tipo)
                    {
                        case 1:
                            obj._tipo = "Paneles Expansibles";
                            break;
                        case 2:
                            obj._tipo = "Pestañas Horizontales";
                            break;
                        case 3:
                            obj._tipo = "Paneles Verticales";
                            break;
                        case 4:
                            obj._tipo = "Galeria de Imagenes";
                            break;
                        case 5:
                            obj._tipo = "Agenda de Eventos";
                            break;
                        case 6:
                            obj._tipo = "Noticias";
                            break;
                        case 7:
                            obj._tipo = "HTML Libre";
                            break;
                        case 8:
                            obj._tipo = "Tarjetas";
                            break;
                        case 9:
                            obj._tipo = "Carrusel";
                            break;
                        case 10:
                            obj._tipo = "Tarjetas Autoridades";
                            break;
                        case 11:
                            obj._tipo = "Linea de Tiempo";
                            break;
                        default:
                            break;
                    }
                    obj.lstContenido = contenido_seccion.read(obj.id);
                    filtros_x_galeria objFiltro = new filtros_x_galeria();
                    objFiltro.id = 0;
                    objFiltro.id_seccion = obj.id;
                    objFiltro.nombre_categoria = "TODAS";
                    obj.lstFiltros.Add(objFiltro);
                    obj.lstFiltros.AddRange(filtros_x_galeria.read(obj.id));
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Secciones> mapeoActivas(SqlDataReader dr)
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
                    if (!dr.IsDBNull(7)) { obj.deleted = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.background_color = dr.GetString(8); }
                    switch (obj.tipo)
                    {
                        case 1:
                            obj._tipo = "Paneles Expansibles";
                            break;
                        case 2:
                            obj._tipo = "Pestañas Horizontales";
                            break;
                        case 3:
                            obj._tipo = "Paneles Verticales";
                            break;
                        case 4:
                            obj._tipo = "Galeria de Imagenes";
                            break;
                        case 5:
                            obj._tipo = "Agenda de Eventos";
                            break;
                        case 6:
                            obj._tipo = "Noticias";
                            break;
                        case 7:
                            obj._tipo = "HTML Libre";
                            break;
                        case 8:
                            obj._tipo = "Tarjetas";
                            break;
                        case 9:
                            obj._tipo = "Carrusel";
                            break;
                        default:
                            break;
                    }
                    obj.lstContenido = contenido_seccion.readActivos(obj.id, true);
                    filtros_x_galeria objFiltro = new filtros_x_galeria();
                    objFiltro.id = 0;
                    objFiltro.id_seccion = obj.id;
                    objFiltro.nombre_categoria = "TODAS";
                    obj.lstFiltros.Add(objFiltro);
                    obj.lstFiltros.AddRange(filtros_x_galeria.read(obj.id));
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
                    cmd.CommandText = "SELECT *FROM Secciones WHERE id_page=@id_page AND deleted=0 ORDER BY orden";
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
        public static List<Secciones> readActivas(int idPagina)
        {
            try
            {
                List<Secciones> lst = new List<Secciones>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Secciones WHERE id_page=@id_page AND activo=@activo AND deleted=0 ORDER BY orden";
                    cmd.Parameters.AddWithValue("id_page", idPagina);
                    cmd.Parameters.AddWithValue("activo", idPagina);
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
        public static Secciones getByPk(int id)
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
        public static Secciones getByPkActivos(int id)
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
                    List<Secciones> lst = mapeoActivas(dr);
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
                sql.AppendLine(", activo");
                sql.AppendLine(", orden");
                sql.AppendLine(", tipo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_page");
                sql.AppendLine(", 1");
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

        public static int getMaxOrden(int idPage)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(orden),0) FROM Secciones");
                sql.AppendLine("WHERE id_page=@id_page AND deleted=0");

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_page", idPage);
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
                sql.AppendLine("UPDATE Secciones SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine(", subtitulo=@subtitulo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@subtitulo", obj.subtitulo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateOrden(int id, int idOrden)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Secciones SET");
                sql.AppendLine("orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@orden", idOrden);
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
                sql.AppendLine("UPDATE  Secciones SET");
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
        public static void setBackGroundColor(int id, string background_color)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Secciones SET");
                sql.AppendLine("background_color=@background_color");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@background_color", background_color);
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
                sql.AppendLine("UPDATE  Secciones SET deleted=1");
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
        public static void deleteGaleria(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE contenido_seccion");
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
        public static void deletePagina(int id_page)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Secciones ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_page=@id_page");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_page", id_page);
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

