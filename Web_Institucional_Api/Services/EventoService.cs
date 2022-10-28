using Web_Institucional_Api.Entities;

namespace Web_Institucional_Api.Services
{
    public class EventoService : IEventoService
    {
        public void activaDesactiva(int id, bool activo)
        {
            try
            {
                Entities.Evento.activaDesactiva(id, activo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(int id)
        {
            try
            {
                Entities.Evento.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Evento getByPk(int id)
        {
            try
            {
                return Entities.Evento.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(Evento obj)
        {
            try
            {
                return Entities.Evento.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Evento> read(int idSeccion, int mes, int anio)
        {
            try
            {
                return Entities.Evento.read(idSeccion, mes, anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Evento> read(int idSeccion)
        {
            try
            {
                return Entities.Evento.read(idSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Evento obj)
        {
            try
            {
                Entities.Evento.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
