using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Institucional_Api.Entities
{
    public class filtros_x_galeria : DALBase
    {
        public int id { get; set; }
        public int id_seccion { get; set; }
        public string nombre_categoria { get; set; }

        public filtros_x_galeria()
        {
            id = 0;
            id_seccion = 0;
            nombre_categoria = string.Empty;
        }

        private static List<filtros_x_galeria> mapeo(SqlDataReader dr)
        {
            List<filtros_x_galeria> lst = new List<filtros_x_galeria>();
            filtros_x_galeria obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new filtros_x_galeria();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_seccion = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.nombre_categoria = dr.GetString(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<filtros_x_galeria> read(int idSeccion)
        {
            try
            {
                List<filtros_x_galeria> lst = new List<filtros_x_galeria>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM filtros_x_galeria WHERE id_seccion=@id_seccion";
                    cmd.Parameters.AddWithValue("id_seccion", idSeccion);
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

        public static filtros_x_galeria getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM filtros_x_galeria WHERE");
                sql.AppendLine("id = @id");
                filtros_x_galeria obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<filtros_x_galeria> lst = mapeo(dr);
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

        public static int insert(filtros_x_galeria obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO filtros_x_galeria(");
                sql.AppendLine("id_seccion");
                sql.AppendLine(", nombre_categoria");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_seccion");
                sql.AppendLine(", @nombre_categoria");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@nombre_categoria", obj.nombre_categoria);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(filtros_x_galeria obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  filtros_x_galeria SET");
                sql.AppendLine("id_seccion=@id_seccion");
                sql.AppendLine(", nombre_categoria=@nombre_categoria");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_seccion", obj.id_seccion);
                    cmd.Parameters.AddWithValue("@nombre_categoria", obj.nombre_categoria);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(filtros_x_galeria obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  filtros_x_galeria ");
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

