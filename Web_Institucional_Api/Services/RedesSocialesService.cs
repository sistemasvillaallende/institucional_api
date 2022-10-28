using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class RedesSocialesService : IRedesSocialesService
    {
        public Redes_sociales getByPk(int id)
        {
            try
            {
                return Entities.Redes_sociales.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Redes_sociales obj)
        {
            try
            {
                return Entities.Redes_sociales.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<Redes_sociales> read()
        {
            try
            {
                return Entities.Redes_sociales.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        public void update(Redes_sociales obj)
        {
            try
            {
                Entities.Redes_sociales.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
