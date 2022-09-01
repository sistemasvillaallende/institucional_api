using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class CarruselService:ICarruselService
    {
        public List<Carrusel> read()
        {
            try
            {
                return Carrusel.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Carrusel> readActivos()
        {
            try
            {
                return Carrusel.readActivos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Carrusel getByPk(int id)
        {
            try
            {
                return Carrusel.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Carrusel obj)
        {
            try
            {
                return Carrusel.insert(obj);    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Carrusel obj)
        {
            try
            {
                Carrusel.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void activaDesactiva(int id, bool activa)
        {
            try
            {
                Carrusel.activaDesactiva(id, activa);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id)
        {
            try
            {
                Carrusel.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
