using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class Evento : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string callToAction { get; set; }
        public string imagen { get; set; }
        public DateTime fecha_desde { get; set; }
        public DateTime fecha_hasta { get; set; }
        public string hora_desde { get; set; }
        public TimeSpan hora_hasta { get; set; }
        public string lugar { get; set; }
        public string direccion { get; set; }
        public string mapa { get; set; }
        public decimal precio { get; set; }
        public string mas_informacion { get; set; }
        public int id_seccion { get; set; }
        public bool activo { get; set; }
        public int id_page { get; set; }
        public string _fecha { get; set; }
        public string mes { get; set; } 
        public int anio { get; set; }
        public int dia { get; set; }
        public Evento()
        {
            id = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            callToAction = string.Empty;
            imagen = string.Empty;
            fecha_desde = DateTime.Now;
            fecha_hasta = DateTime.Now;
            hora_desde = string.Empty;
            hora_hasta = new TimeSpan();
            lugar = string.Empty;
            direccion = string.Empty;
            mapa = string.Empty;
            precio = 0;
            mas_informacion = string.Empty;
            id_seccion = 0;
            activo = true;
            id_page = 0;
            _fecha = string.Empty;
        }

        private static List<Evento> mapeo(SqlDataReader dr)
        {
            List<Evento> lst = new List<Evento>();
            Evento obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Evento();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.descripcion = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.callToAction = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.imagen = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.fecha_desde = dr.GetDateTime(5); }
                    if (!dr.IsDBNull(6)) { obj.fecha_hasta = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.hora_desde = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.hora_hasta = dr.GetTimeSpan(8); }
                    if (!dr.IsDBNull(9)) { obj.lugar = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.direccion = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.mapa = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.precio = dr.GetDecimal(12); }
                    if (!dr.IsDBNull(13)) { obj.mas_informacion = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.id_seccion = dr.GetInt32(14); }
                    if (!dr.IsDBNull(15)) { obj.activo = dr.GetBoolean(15); }
                    if (!dr.IsDBNull(16)) { obj.id_page = dr.GetInt32(16); }
                    obj._fecha = obj.fecha_desde.ToShortDateString();
                    obj.dia = obj.fecha_desde.Day;
                    switch (obj.fecha_desde.Month)
                    {
                        case 1:
                            obj.mes = "ENERO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 2:
                            obj.mes = "FEBRERO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 3:
                            obj.mes = "MARZO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 4:
                            obj.mes = "ABRIL";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 5:
                            obj.mes = "MAYO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 6:
                            obj.mes = "JUNIO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 7:
                            obj.mes = "JULIO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 8:
                            obj.mes = "AGOSTO";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 9:
                            obj.mes = "SEPTIEMBRE";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 10:
                            obj.mes = "OCTUBRE";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 11:
                            obj.mes = "NOVIEMBRE";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        case 12:
                            obj.mes = "DICIEMBRE";
                            obj.anio = obj.fecha_desde.Year;
                            break;
                        default:
                            break;
                    }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Evento> read(int idSeccion, int mes, int anio)
        {
            try
            {
                List<Evento> lst = new List<Evento>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.id_page FROM Evento A
                                        INNER JOIN Secciones B ON A.id_seccion=B.id
                                        WHERE A.id_seccion=@id_seccion 
                                        AND MONTH(A.fecha_desde) = @mes 
                                        AND YEAR(A.fecha_desde) = @anio 
                                        AND A.activo=1
                                        ORDER BY fecha_desde DESC";
                    cmd.Parameters.AddWithValue("@id_seccion", idSeccion);
                    cmd.Parameters.AddWithValue("@mes", mes);
                    cmd.Parameters.AddWithValue("@anio", anio);
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
        public static List<Evento> read(int idSeccion)
        {
            try
            {
                List<Evento> lst = new List<Evento>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.id_page FROM Evento A
                                        INNER JOIN Secciones B ON A.id_seccion=B.id
                                        WHERE id_seccion=@id_seccion
                                        ORDER BY fecha_desde DESC";
                    cmd.Parameters.AddWithValue("@id_seccion", idSeccion);
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
        public static Evento getByPk(int id)
        {
            try
            {
                Evento obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmd.CommandText = @"SELECT A.*, B.id_page FROM Evento A
                                                          INNER JOIN Secciones B ON A.id_seccion=B.id
                                                          WHERE A.id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Evento> lst = mapeo(dr);
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

        public static int insert(Evento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Evento(");
                sql.AppendLine("nombre");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", callToAction");
                sql.AppendLine(", imagen");
                sql.AppendLine(", fecha_desde");
                sql.AppendLine(", hora_desde");
                sql.AppendLine(", lugar");
                sql.AppendLine(", direccion");
                sql.AppendLine(", mapa");
                sql.AppendLine(", precio");
                sql.AppendLine(", id_seccion");
                sql.AppendLine(", mas_informacion");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", 'Mas Información...'");
                sql.AppendLine(", @imagen");
                sql.AppendLine(", @fecha_desde");
                sql.AppendLine(", @hora_desde");
                sql.AppendLine(", @lugar");
                sql.AppendLine(", @direccion");
                sql.AppendLine(", @mapa");
                sql.AppendLine(", @precio");
                sql.AppendLine(", @id_seccion");
                sql.AppendLine(", @mas_informacion");
                sql.AppendLine(", 0");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("@fecha_desde", obj.fecha_desde);
                    cmd.Parameters.AddWithValue("@hora_desde", obj.hora_desde);
                    cmd.Parameters.AddWithValue("@lugar", obj.lugar);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@mapa", obj.mapa);
                    cmd.Parameters.AddWithValue("@precio", obj.precio);
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@mas_informacion", obj.mas_informacion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
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
                sql.AppendLine("UPDATE  Evento SET");
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
        public static void setImagen(int id, string imagen)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Evento SET");
                sql.AppendLine("imagen=@imagen");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@imagen", imagen);
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
        public static void update(Evento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Evento SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine(", fecha_desde=@fecha_desde");
                sql.AppendLine(", hora_desde=@hora_desde");
                sql.AppendLine(", lugar=@lugar");
                sql.AppendLine(", direccion=@direccion");
                sql.AppendLine(", mapa=@mapa");
                sql.AppendLine(", precio=@precio");
                sql.AppendLine(", mas_informacion=@mas_informacion");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@fecha_desde", obj.fecha_desde);
                    cmd.Parameters.AddWithValue("@mas_informacion", obj.mas_informacion);
                    cmd.Parameters.AddWithValue("@hora_desde", obj.hora_desde);
                    cmd.Parameters.AddWithValue("@lugar", obj.lugar);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("@mapa", obj.mapa);
                    cmd.Parameters.AddWithValue("@precio", obj.precio);
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
                sql.AppendLine("DELETE  Evento ");
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

