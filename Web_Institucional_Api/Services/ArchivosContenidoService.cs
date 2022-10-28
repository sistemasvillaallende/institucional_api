using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class ArchivosContenidoService : IArchivosContenidoService
    {
        public void activaDesactiva(int id, bool activo)
        {
            try
            {
                Entities.archivos_x_contenido.activaDesactiva(id, activo);
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
                Entities.archivos_x_contenido.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public archivos_x_contenido getByPk(int id)
        {
            try
            {
                return Entities.archivos_x_contenido.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getMaxOrden(int id_contenido)
        {
            try
            {
                return Entities.archivos_x_contenido.getMaxOrden(id_contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getMaxOrdenNews(int id_news)
        {
            try
            {
                return Entities.archivos_x_contenido.getMaxOrdenNews(id_news);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(archivos_x_contenido obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int orden = 0;
                    if (obj.id_contenido != 00)
                        orden = getMaxOrden(obj.id_contenido);
                    else
                        orden = getMaxOrdenNews(obj.id_news);
                    obj.orden = orden + 1;
                    int id = Entities.archivos_x_contenido.insert(obj);                     
                    scope.Complete();
                    return id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<archivos_x_contenido> read(int id_contenido)
        {
            try
            {
                return Entities.archivos_x_contenido.read(id_contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<archivos_x_contenido> readActivos(int id_contenido)
        {
            try
            {
                return Entities.archivos_x_contenido.readActivos(id_contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<archivos_x_contenido> readActivosNews(int id_news)
        {
            try
            {
                return Entities.archivos_x_contenido.readActivosNews(id_news);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<archivos_x_contenido> readNews(int id_news)
        {
            try
            {
                return Entities.archivos_x_contenido.readNews(id_news);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setOrden(List<archivos_x_contenido> lst)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        Entities.contenido_seccion.setOrden(lst[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(archivos_x_contenido obj)
        {
            try
            {
                Entities.archivos_x_contenido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
