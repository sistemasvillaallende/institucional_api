using System.Data.SqlClient;

namespace Web_Institucional_Api.Entities
{
    public class DALBase
    {
        public static SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection("Data Source=srv-sql;Initial Catalog=PaginaInstitucional;User ID=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
