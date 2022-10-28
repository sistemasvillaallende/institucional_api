using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IRedesSocialesService
    {
        public List<Redes_sociales> read();
        public Redes_sociales getByPk(int id);
        public int insert(Redes_sociales obj);
        public void update(Redes_sociales obj);
    }
}
