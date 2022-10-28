using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarruselController : ControllerBase
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private ICarruselService _carruselService;
        public CarruselController(ICarruselService carruselService, IWebHostEnvironment hostEnvironment)
        {
            _carruselService = carruselService;
            _HostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult read(int id_page)
        {
            var lst =
                _carruselService.read(id_page);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivas(int id_page)
        {
            var lst =
                _carruselService.readActivos(id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.Carrusel obj)
        {
            _carruselService.insert(obj);
            var lst =
                _carruselService.read(obj.id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.Carrusel obj)
        {
            _carruselService.update(obj);
            var lst =
                _carruselService.read(obj.id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult setImgDerecha(Entities.Carrusel obj)
        {
            _carruselService.setImgDerecha(obj.id, obj.imgDerecha);
            var lst =
                _carruselService.read(obj.id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult setImgFondo()
        {
            try
            {
                var file = Request.Form.Files[0];
                string ext = String.Empty;

                var nombre = String.Empty;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                int id = int.Parse(Request.Form["id"]);
                int id_page = int.Parse(Request.Form["id_page"]);
               
                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));

                    nombre = string.Format("Carrusel_{0}_Pagina_{1}{2}", id, id_page, ext);
                    folder = string.Format("Pagina_{0}", id_page);
                    string webRootPath = _HostEnvironment.WebRootPath;
                    string contentRootPath = _HostEnvironment.ContentRootPath;

                    string path = "";
                    path = Path.Combine(contentRootPath, "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                    if (!System.IO.Directory.Exists(path + folder))
                    {
                        System.IO.Directory.CreateDirectory(path + folder);
                    }


                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(path + folder, nombre);//pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    Entities.Carrusel.setImgFondo(id, nombre);

                }
                var lst =
                    _carruselService.read(id_page);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult updateActiva(Entities.Carrusel obj)
        {
            _carruselService.activaDesactiva(obj.id, obj.activo);
            var lst =
                _carruselService.read(obj.id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult delete(Entities.Carrusel obj)
        {
            _carruselService.delete(obj.id);
            var lst =
                _carruselService.read(obj.id_page);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateOrden(List<Entities.Carrusel> lstO)
        {
            _carruselService.setOrden(lstO);
            var lst =
                _carruselService.read(lstO[0].id_page);
            return Ok(lst);
        }
    }
}
