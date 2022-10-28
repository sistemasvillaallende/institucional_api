using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IInstitucionalService
    {
        public List<Institucional> read();
        public Institucional getByPk(int id);
        public int insert(Institucional obj);
        public void update(Institucional obj);
        public void setLogo(Institucional obj);
        public void delete(int id);
    }
}
