using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class PaginasService : IPaginasService
    {
        public void delete(int id)
        {
            try
            {
                Entities.Paginas.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Paginas getByPk(int id)
        {
            try
            {
                return Entities.Paginas.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Paginas obj)
        {
            try
            {
                return Entities.Paginas.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(string nombre)
        {
            try
            {
                return Entities.Paginas.insert(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Paginas> read()
        {
            try
            {
                return Entities.Paginas.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Paginas obj)
        {
            try
            {
                Entities.Paginas.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateContenidoPrincipal(Paginas obj)
        {
            try
            {
                Entities.Paginas.updateContenidoPrincipal(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateDatosGenerales(Paginas obj)
        {
            try
            {
                Entities.Paginas.updateDatosGenerales(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateNombreImagen(Paginas obj)
        {
            try
            {
                Entities.Paginas.updateNombreImagen(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
