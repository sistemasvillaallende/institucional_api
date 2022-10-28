using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IEventoService
    {
        public List<Evento> read(int idSeccion, int mes, int anio);
        public List<Evento> read(int idSeccion);
        public Evento getByPk(int id);
        public int insert(Evento obj);
        public void activaDesactiva(int id, bool activo);
        public void update(Evento obj);
        public void delete(int id);
    }
}
