using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class AutoridadesServece : IAutoridadesService
    {
        public void delete(int id)
        {
            try
            {
                Autoridades.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Autoridades getByPk(int id)
        {
            try
            {
                return Autoridades.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Autoridades obj)
        {
            try
            {
                return Autoridades.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Autoridades> read()
        {
            try
            {
                return Autoridades.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Autoridades obj)
        {
            try
            {
                Autoridades.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
