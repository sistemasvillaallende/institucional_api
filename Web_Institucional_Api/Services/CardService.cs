using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class CardService : ICardsService
    {
        public void activaDesactiva(int id, bool activo)
        {
            try
            {
                Entities.Cards.activaDesactiva(id, activo);
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
                Entities.Cards.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cards getByPk(int id)
        {
            try
            {
                return Entities.Cards.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getMaxOrden(int id_page)
        {
            try
            {
                return Entities.Cards.getMaxOrden(id_page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Cards obj)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                int orden = Cards.getMaxOrden(obj.id_seccion);
                obj.orden = orden + 1;
                id = Cards.insert(obj);
                scope.Complete();
            }
            return id;
        }

        public List<Cards> read(int id_seccion)
        {
            try
            {
                return Entities.Cards.read(id_seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cards> readActivos(int id_seccion)
        {
            try
            {
                return Entities.Cards.readActivos(id_seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setImagen(int id, string imagen)
        {
            try
            {
                Entities.Cards.setImagen(id, imagen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setOrden(List<Entities.Cards> obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Entities.Cards.setOrden(obj[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Cards obj)
        {
            try
            {
                Entities.Cards.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
