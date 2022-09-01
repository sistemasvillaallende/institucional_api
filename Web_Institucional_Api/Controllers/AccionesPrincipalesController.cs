using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccionesPrincipalesController : ControllerBase
    {
        private IAccionesPrincipalesService _accionesPrincipalesService;
        public AccionesPrincipalesController(IAccionesPrincipalesService accionesPrincipalesService)
        {
            _accionesPrincipalesService = accionesPrincipalesService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _accionesPrincipalesService.read();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getByPk(int pk)
        {
            var lst =
                _accionesPrincipalesService.getByPk(pk);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.AccionesPrincipales obj)
        {
            _accionesPrincipalesService.update(obj);
            var lst =
                _accionesPrincipalesService.read();
            return Ok(lst);
        }
    }
}
