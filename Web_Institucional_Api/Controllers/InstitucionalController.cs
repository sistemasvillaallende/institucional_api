using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstitucionalController : Controller
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private IInstitucionalService _institucionalService;
        public InstitucionalController(IInstitucionalService institucionalService, IWebHostEnvironment HostEnvironment)
        {
            _institucionalService = institucionalService;
            _HostEnvironment = HostEnvironment;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _institucionalService.getByPk(1);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult Update(Entities.Institucional obj)
        {
            _institucionalService.update(obj);

            var lst =
                _institucionalService.getByPk(obj.id);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var file = HttpContext.Request.Form.Files[0];
                string ext = String.Empty;

                var nombre = String.Empty;

                var folder = String.Empty;

                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));
                    nombre = string.Format("Logo{0}", ext);
                    string webRootPath = _HostEnvironment.WebRootPath;
                    string contentRootPath = _HostEnvironment.ContentRootPath;

                    string path = "";
                    path = Path.Combine(contentRootPath, "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }


                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(path, nombre);//pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    Entities.Institucional obj = new Entities.Institucional();
                    obj.id = 1;
                    obj.logo = nombre;
                    _institucionalService.setLogo(obj);

                }
                var lst =
                    _institucionalService.getByPk(1);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
