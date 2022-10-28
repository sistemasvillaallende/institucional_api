namespace Web_Institucional_Api.Services
{
    public interface ILoginServices
    {
        public Entities.Login ValidUser(string user, string password);
        public bool ValidaPermiso(string user, string Proceso, out int id_oficina);
        public bool ValidaPermiso(string user, string Proceso);
    }
}
