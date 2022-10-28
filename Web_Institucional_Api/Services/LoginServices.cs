namespace Web_Institucional_Api.Services
{
    public class LoginServices:ILoginServices
    {

        Entities.Login objSeguridad = null;

        //bool? estaAutenticado = false;
        public string nombre { get; set; }
        public int id_oficina { get; set; }

        public LoginServices()
        {
            nombre = "";
            id_oficina = 0;
            objSeguridad = new Entities.Login();
        }



        public Entities.Login ValidUser(string user, string password)
        {
            return objSeguridad.ValidUser(user, password, nombre);
        }

        public bool ValidaPermiso(string user, string Proceso, out int id_oficina)
        {
            return objSeguridad.ValidaPermiso(user, Proceso, out id_oficina);
        }

        public bool ValidaPermiso(string user, string Proceso)
        {
            return objSeguridad.ValidaPermiso(user, Proceso);
        }

    }
}
