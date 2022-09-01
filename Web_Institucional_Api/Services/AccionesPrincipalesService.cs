using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class AccionesPrincipalesService : IAccionesPrincipalesService
    {
        public AccionesPrincipales getByPk(int id)
        {
            try
            {
                return Entities.AccionesPrincipales.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccionesPrincipales> read()
        {
            try
            {
                return Entities.AccionesPrincipales.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(AccionesPrincipales obj)
        {
            try
            {
                Entities.AccionesPrincipales.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
