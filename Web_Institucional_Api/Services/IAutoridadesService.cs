using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IAutoridadesService
    {
        public List<Autoridades> read();
        public Autoridades getByPk(int id);
        public int insert(Autoridades obj);
        public void update(Autoridades obj);
        public void delete(int id);
    }
}
