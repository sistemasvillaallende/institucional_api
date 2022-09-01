using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NewsController : ControllerBase
    {

        private INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _newsService.read();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readHome()
        {
            var lst =
                _newsService.readHome();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getBySeccion(int seccion)
        {
            var lst =
                _newsService.getBySeccion(seccion);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getByPk(int pk)
        {
            var lst =
                _newsService.getByPk(pk);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getImages(int idNews)
        {
            var lst =
                _newsService.readImages(idNews);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getFiles(int idNews)
        {
            var lst =
                _newsService.readFiles(idNews);
            return Ok(lst);
        }
    }
}
