using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface ICarruselService
    {
        public List<Carrusel> read();
        public List<Carrusel> readActivos();
        public Carrusel getByPk(int id);
        public int insert(Carrusel obj);
        public void update(Carrusel obj);
        public void activaDesactiva(int id, bool activa);
        public void delete(int id);
    }
}
