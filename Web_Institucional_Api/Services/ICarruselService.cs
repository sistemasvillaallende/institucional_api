using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface ICarruselService
    {
        public List<Carrusel> read(int id_page);
        public List<Carrusel> readActivos(int id_page);
        public Carrusel getByPk(int id);
        public int insert(Carrusel obj);
        public void update(Carrusel obj);
        public void activaDesactiva(int id, bool activa);
        public void delete(int id);
        public void setOrden(List<Entities.Carrusel> obj);
        public void setImgFondo(int id, string img);
        public void setImgDerecha(int id, string img);
    }
}
