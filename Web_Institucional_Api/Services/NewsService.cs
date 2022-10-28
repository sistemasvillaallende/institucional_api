using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class NewsService : INewsService
    {
        public void activaDesactiva(Entities.News obj)
        {
            try
            {
                Entities.News.activaDesactiva(obj.id, obj.activo);
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
                Entities.News.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteImagenGaleria(int id)
        {
            try
            {
                Entities.images_x_news.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public News getByPk(int id)
        {
            try
            {
                return Entities.News.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> getBySeccion(int seccion)
        {
            try
            {
                return Entities.News.getBySeccion(seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> getBySeccionActivas(int seccion)
        {
            try
            {
                return Entities.News.getBySeccionActivas(seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getMaxOrdenGaleria(int idNews)
        {
            try
            {
                return Entities.images_x_news.getMaxOrden(idNews);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(News obj)
        {
            try
            {
                int id = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    int orden = Entities.News.getMaxOrden(obj.seccion);
                    obj.orden = orden + 1;
                    id = News.insert(obj);
                    scope.Complete();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertImagenGaleria(images_x_news obj)
        {
            try
            {
                int id = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    int orden = Entities.images_x_news.getMaxOrden(obj.idNews);
                    obj.orden = orden + 1;
                    id = images_x_news.insert(obj);
                    scope.Complete();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> read()
        {
            try
            {
                return Entities.News.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<files_x_news> readFiles(int idNews)
        {
            try
            {
                return Entities.files_x_news.read(idNews);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> readHome()
        {
            try
            {
                return Entities.News.readHome();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<News> readHomeActivas()
        {
            try
            {
                return Entities.News.readHomeActivas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<images_x_news> readImages(int idNews)
        {
            try
            {
                return Entities.images_x_news.read(idNews);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(News obj)
        {
            try
            {
                Entities.News.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateOrden(List<Entities.News> obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Entities.News.updateOrden(obj[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateOrdenImages(List<images_x_news> obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Entities.images_x_news.setOrden(obj[i].id, i + 1);
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
