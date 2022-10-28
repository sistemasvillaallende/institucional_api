using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IMenuService
    {
        public List<Menu> read(int idPadre);
        public List<Menu> readActivos(int idPadre);
        public int getMaxOrden(int idPadre);
        public Menu getByPk(int id);
        public int insert(Menu obj);
        public void update(Menu obj);
        public void delete(int id);
        public void activaDesactiva(int id, bool activo);
        public void updateOrden(List<Entities.Menu> obj);
    }
}
