using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RedesSocialesController : Controller
    {
        private IRedesSocialesService _redesSocialesService;
        public RedesSocialesController(IRedesSocialesService redesSocialesService)
        {
            _redesSocialesService = redesSocialesService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _redesSocialesService.getByPk(1);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult Update(Entities.Redes_sociales obj)
        {
            _redesSocialesService.update(obj);

            var lst =
                _redesSocialesService.getByPk(obj.id);
            return Ok(lst);
        }
    }
}
