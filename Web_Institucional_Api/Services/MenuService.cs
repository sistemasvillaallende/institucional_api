using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class MenuService : IMenuService
    {
        public void activaDesactiva(int id, bool activo)
        {
            try
            {
                Entities.Menu.activaDesactiva(id, activo);
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
                Entities.Menu.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu getByPk(int id)
        {
            try
            {
                return Entities.Menu.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getMaxOrden(int idPadre)
        {
            try
            {
                return Entities.Menu.getMaxOrden(idPadre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Menu obj)
        {
            try
            {
                int id = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    if (obj.tipo == 1)
                        obj.destino = string.Empty;
                    int orden = getMaxOrden(obj.id_padre);
                    obj.orden = orden + 1;
                    id = Menu.insert(obj);
                    scope.Complete();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> read(int idPadre, int idSitio)
        {
            try
            {
                return Entities.Menu.read(idPadre, idSitio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> readActivos(int idPadre, int idSitio)
        {
            try
            {
                return Entities.Menu.readActivos(idPadre, idSitio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Menu obj)
        {
            try
            {
                Entities.Menu.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateOrden(List<Entities.Menu> obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Entities.Menu.updateOrden(obj[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
