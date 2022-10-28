using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IArchivosContenidoService
    {
        public List<archivos_x_contenido> read(int id_contenido);
        public List<archivos_x_contenido> readActivos(int id_contenido);
        public archivos_x_contenido getByPk(int id);
        public int insert(archivos_x_contenido obj);
        public void update(archivos_x_contenido obj);
        public void activaDesactiva(int id, bool activo);
        public void setOrden(List<archivos_x_contenido> lst);
        public int getMaxOrden(int id_contenido);
        public void delete(int id);

        public int getMaxOrdenNews(int id_news);
        public List<archivos_x_contenido> readActivosNews(int id_news);
        public List<archivos_x_contenido> readNews(int id_news);
    }
}
