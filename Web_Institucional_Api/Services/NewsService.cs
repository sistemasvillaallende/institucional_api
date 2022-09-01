using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class NewsService : INewsService
    {
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

        public int insert(News obj)
        {
            try
            {
                return Entities.News.insert(obj);
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
    }
}
