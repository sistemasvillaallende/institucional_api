using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface IPaginasService
    {
        public List<Paginas> read();
        public Paginas getByPk(int id);
        public int insert(Paginas obj);
        public void update(Paginas obj);
        public void delete(int id);

        public int insert(string nombre);
        public void updateDatosGenerales(Paginas obj);
        public void updateNombreImagen(Paginas obj);
        public void updateContenidoPrincipal(Paginas obj);
        public void updateActivaContenidoPrincipal(int id, bool activa);
        public void updateActivaContenidoPrincipalBanner(int id, bool activa); 
        public List<ListaSecciones> lstSecciones(int idPagina);
    }
}
