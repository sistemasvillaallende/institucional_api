using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoticiaPrincipalController : Controller
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private INoticiaPrincipalService _noticiaPrincipalService;
        public NoticiaPrincipalController(INoticiaPrincipalService noticiaPrincipalService, IWebHostEnvironment hostEnvironment)
        {
            _noticiaPrincipalService = noticiaPrincipalService;
            _HostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult getByPk()
        {
            var lst =
                _noticiaPrincipalService.getByPk(1);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.NoticiaPrincipal obj)
        {
            _noticiaPrincipalService.update(obj);
            var lst =
                _noticiaPrincipalService.getByPk(1);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult setImg()
        {
            try
            {
                var file = Request.Form.Files[0];
                string ext = String.Empty;

                var nombre = String.Empty;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
    DateTime.Now.Year, DateTime.Now.Month,
    DateTime.Now.Day, DateTime.Now.Hour,
    DateTime.Now.Minute, DateTime.Now.Second);
                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));

                    nombre = string.Format("Noticia_Principal_Pagina_{0}_{1}_{2}", 0, fecha_nombre, ext);
                    folder = string.Format("Pagina_{0}", 0);
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

                    Entities.NoticiaPrincipal.setImagen(1, nombre);

                }
                var lst =
                    _noticiaPrincipalService.getByPk(1);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
