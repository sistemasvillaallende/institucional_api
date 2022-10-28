using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using Newtonsoft.Json;
namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private ILoginServices _loginService;
        public LoginController(ILoginServices loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Validar(Entities.Login obj)
        {
            string respuesta = string.Empty;
            Entities.Login objValidado = null;
            int id_oficina = 0;

            objValidado = _loginService.ValidUser(obj.nombre, obj.PASSWD);

            if (objValidado != null)
            {
                if (!_loginService.ValidaPermiso(obj.nombre, "BACKEND_TRAMITES_ADM", out id_oficina))
                {
                    objValidado = null;
                }
            }
            else
            {
                respuesta = "No se puede iniciar la Sesión. <br/>Por favor verifique los datos ingresados.";
            }
            return Ok(objValidado);
        }
    }
}
