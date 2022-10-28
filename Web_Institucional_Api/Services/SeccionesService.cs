using System.Transactions;
using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class SeccionesService : ISeccionesService
    {
        public void delete(int id)
        {
            try
            {
                Secciones.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteGaleria(int id)
        {
            try
            {
                Secciones.deleteGaleria(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deletePagina(int id_page)
        {
            try
            {
                Secciones.deletePagina(id_page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Secciones getByPk(int id)
        {
            try
            {
                return Secciones.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Secciones getByPkActivos(int id)
        {
            try
            {
                return Secciones.getByPkActivos(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int getMaxOrden(int idPage)
        {
            try
            {
                return Secciones.getMaxOrden(idPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Secciones obj)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                int orden = getMaxOrden(obj.id_page);
                obj.orden = orden + 1;
                id = Secciones.insert(obj);
                scope.Complete();
            }
            return id;
        }
        public List<Secciones> read(int idPagina)
        {
            try
            {
                return Secciones.read(idPagina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Secciones obj)
        {
            try
            {
                Secciones.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void reordenar(Entities.Paginas obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.lstSecciones.Count; i++)
                    {
                        Entities.Secciones.updateOrden(obj.lstSecciones[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void activaDesactiva(int id, bool activo)
        {
            try
            {
                Secciones.activaDesactiva(id, activo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region contenido_seccion


        public List<contenido_seccion> readContenido(int id_seccion)
        {
            try
            {
                return contenido_seccion.read(id_seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<contenido_seccion> readContenidoActivos(int id_seccion, bool activo)
        {
            try
            {
                return contenido_seccion.readActivos(id_seccion, activo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public contenido_seccion getContenidoByPk(int id)
        {
            try
            {
                return contenido_seccion.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int getMaxOrdenContenido(int idSeccion)
        {
            return contenido_seccion.getMaxOrden(idSeccion);
        }
        public int insertContenido(contenido_seccion obj)
        {
            try
            {
                int id = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    int orden = getMaxOrdenContenido(obj.id);
                    obj.orden = orden + 1;
                    id = contenido_seccion.insert(obj);
                    scope.Complete();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insertContenidoGaleria(contenido_seccion obj)
        {
            try
            {
                return contenido_seccion.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateContenido(contenido_seccion obj)
        {
            try
            {
                contenido_seccion.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void activaDesactivaContenido(int id, bool activo)
        {
            try
            {
                contenido_seccion.activaDesactiva(id, activo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setOrdenContenido(Entities.Secciones obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.lstContenido.Count; i++)
                    {
                        Entities.contenido_seccion.setOrden(obj.lstContenido[i].id, i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteContenido(int id)
        {
            try
            {
                contenido_seccion.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteSeccion(int id_seccion)
        {
            try
            {
                contenido_seccion.deleteSeccion(id_seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setBackGroundColor(int id, string background_color)
        {
            try
            {
                Secciones.setBackGroundColor(id, background_color);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
