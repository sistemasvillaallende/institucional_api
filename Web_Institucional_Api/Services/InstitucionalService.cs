using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class InstitucionalService : IInstitucionalService
    {
        public void delete(int id)
        {
            try
            {
                Institucional.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Institucional getByPk(int id)
        {
            try
            {
                return Institucional.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Institucional obj)
        {
            try
            {
                return Institucional.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Institucional> read()
        {
            try
            {
                return Institucional.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Institucional obj)
        {
            try
            {
                Institucional.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setLogo(Institucional obj)
        {
            try
            {
                Institucional.setLogo(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
