using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarruselController : ControllerBase
    {
        private ICarruselService _carruselService;
        public CarruselController(ICarruselService carruselService)
        {
            _carruselService = carruselService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _carruselService.read();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivas()
        {
            var lst =
                _carruselService.readActivos();
            return Ok(lst);
        }
        //[HttpPost]
        //public IActionResult insert(Entities.Carrusel obj)
        //{
        //    _carruselService.insert(obj);
        //    var lst =
        //        _carruselService.read();
        //    return Ok(lst);
        //}
        //[HttpPost]
        //public IActionResult update(Entities.Carrusel obj)
        //{
        //    _carruselService.update(obj);
        //    var lst =
        //        _carruselService.read();
        //    return Ok(lst);
        //}
        //[HttpPost]
        //public IActionResult updateActiva(Entities.Carrusel obj)
        //{
        //    _carruselService.activaDesactiva(obj.id, obj.activo);
        //    var lst =
        //        _carruselService.read();
        //    return Ok(lst);
        //}
        //[HttpPost]
        //public IActionResult delete(Entities.Carrusel obj)
        //{
        //    _carruselService.activaDesactiva(obj.id, obj.activo);
        //    var lst =
        //        _carruselService.read();
        //    return Ok(lst);
        //}
    }
}
