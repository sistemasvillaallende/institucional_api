using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IAccionesPrincipalesService
    {
        public List<AccionesPrincipales> read();
        public AccionesPrincipales getByPk(int id);
        public void update(AccionesPrincipales obj);

    }
}
