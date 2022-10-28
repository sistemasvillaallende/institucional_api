using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class NoticiaPrincipalService : INoticiaPrincipalService
    {
        public void delete(int id)
        {
            try
            {
                Entities.NoticiaPrincipal.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NoticiaPrincipal getByPk(int id)
        {
            try
            {
                return Entities.NoticiaPrincipal.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(NoticiaPrincipal obj)
        {
            try
            {
                return Entities.NoticiaPrincipal.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoticiaPrincipal> read()
        {
            try
            {
                return Entities.NoticiaPrincipal.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(NoticiaPrincipal obj)
        {
            try
            {
                Entities.NoticiaPrincipal.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
