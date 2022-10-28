using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class CarruselService:ICarruselService
    {
        public List<Carrusel> read(int id_page)
        {
            try
            {
                return Carrusel.read(id_page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Carrusel> readActivos(int id_page)
        {
            try
            {
                return Carrusel.readActivos(id_page);
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
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                int orden = Carrusel.getMaxOrden(obj.id_page);
                obj.orden = orden + 1;
                id = Carrusel.insert(obj);
                scope.Complete();
            }
            return id;
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

        public void setOrden(List<Entities.Carrusel> obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Entities.Carrusel.setOrden(obj[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setImgFondo(int id, string img)
        {
            try
            {
                Carrusel.setImgFondo(id, img);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setImgDerecha(int id, string img)
        {
            try
            {
                Carrusel.setImgDerecha(id, img);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
