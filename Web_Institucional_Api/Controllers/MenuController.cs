using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MenuController : Controller
    {
        private IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet]
        public IActionResult read(int idPadre, int idSitio)
        {
            var lst =
                _menuService.read(idPadre, idSitio);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivos(int idPadre, int idSitio)
        {
            var lst =
                _menuService.readActivos(idPadre, idSitio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.Menu obj)
        {
            int id = _menuService.insert(obj);
            var lst =
                _menuService.read(obj.id_padre, obj.id_sitio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult activaDesactiva(Entities.Menu obj)
        {
            _menuService.activaDesactiva(obj.id, obj.activo);
            var lst =
                _menuService.read(obj.id_padre, obj.id_sitio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateOrden(List<Entities.Menu> lstM)
        {
            _menuService.updateOrden(lstM);
            var lst =
                _menuService.read(lstM[0].id_padre, lstM[0].id_sitio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.Menu obj)
        {
            _menuService.update(obj);
            var lst =
                _menuService.read(obj.id_padre, obj.id_sitio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult delete(Entities.Menu obj)
        {
            _menuService.delete(obj.id);
            var lst =
                _menuService.read(obj.id_padre, obj.id_sitio);
            return Ok(lst);
        }
    }
}
