using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface INoticiaPrincipalService
    {
        public List<NoticiaPrincipal> read();
        public NoticiaPrincipal getByPk(int id);
        public int insert(NoticiaPrincipal obj);
        public void update(NoticiaPrincipal obj);
        public  void delete(int id);
    }
}
