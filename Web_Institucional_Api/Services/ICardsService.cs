using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface ICardsService
    {
        public List<Cards> read(int id_seccion);
        public List<Cards> readActivos(int id_seccion);
        public Cards getByPk(int id);
        public int getMaxOrden(int id_page);
        public int insert(Cards obj);
        public void update(Cards obj);
        public void activaDesactiva(int id, bool activo);
        public void setImagen(int id, string imagen);
        public void setOrden(List<Entities.Cards> obj);
        public void delete(int id);
    }
}
