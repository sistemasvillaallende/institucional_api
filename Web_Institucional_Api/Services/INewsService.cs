using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface INewsService
    {
        public List<News> read();
        public List<News> getBySeccion(int seccion);
        public List<News> readHome();
        public News getByPk(int id);
        public int insert(News obj);
        public void update(News obj);
        public void delete(int id);
        public List<images_x_news> readImages(int idNews);
        public List<files_x_news> readFiles(int idNews);
    }
}
