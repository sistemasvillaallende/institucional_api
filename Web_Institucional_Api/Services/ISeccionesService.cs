using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public interface ISeccionesService
    {
        public List<Secciones> read(int idPagina);
        public Secciones getByPk(int id);
        public Secciones getByPkActivos(int id);
        public int insert(Secciones obj);
        public int getMaxOrden(int idPage);
        public void update(Secciones obj);
        public void delete(int id);
        public void deletePagina(int id_page);
        public void reordenar(Entities.Paginas obj);
        public void activaDesactiva(int id, bool activo);
        public void setBackGroundColor(int id, string background_color);
        #region contenido_seccion
        public List<contenido_seccion> readContenido(int id_seccion);
        public List<contenido_seccion> readContenidoActivos(int id_seccion, bool activo);
        public contenido_seccion getContenidoByPk(int id);
        public int insertContenido(contenido_seccion obj);
        public void updateContenido(contenido_seccion obj);
        public void activaDesactivaContenido(int id, bool activo);
        public void setOrdenContenido(Entities.Secciones obj);
        public void deleteContenido(int id);
        public void deleteSeccion(int id_seccion);
        public int getMaxOrdenContenido(int idSeccion);
        public int insertContenidoGaleria(contenido_seccion obj);
        public void deleteGaleria(int id);
        #endregion

        #region galeria

        #endregion
    }
}
