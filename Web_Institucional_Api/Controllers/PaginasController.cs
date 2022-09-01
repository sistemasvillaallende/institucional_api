using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaginasController : Controller
    {
        private IPaginasService _paginasService;
        private readonly IWebHostEnvironment _HostEnvironment;

        [Obsolete]
        public PaginasController(IPaginasService paginasService, IWebHostEnvironment HostEnvironment)
        {
            _paginasService = paginasService;
            _HostEnvironment = HostEnvironment;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _paginasService.read();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getByPk(int pk)
        {
            var lst =
                _paginasService.getByPk(pk);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.Paginas obj)
        {
            int id = _paginasService.insert(obj.nombre);
            return Ok(id);
        }
        [HttpPost]
        public IActionResult updateNombre(Entities.Paginas obj)
        {
            _paginasService.updateNombreImagen(obj);
            var objr = _paginasService.getByPk(obj.id);
            return Ok(objr);
        }
        [HttpPost]
        public IActionResult updateContenidoPrincipal(Entities.Paginas obj)
        {
            _paginasService.updateContenidoPrincipal(obj);
            var objr = _paginasService.getByPk(obj.id);
            return Ok(objr);
        }
        [HttpPost]
        public IActionResult updateDatosGenerales(Entities.Paginas obj)
        {
            _paginasService.updateDatosGenerales(obj);
            var objr = _paginasService.getByPk(obj.id);
            return Ok(objr);
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string ext = String.Empty;
                int idPagina = int.Parse(Request.Form["idPagina"]);
                var nombre = String.Empty;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));
                    idPagina = int.Parse(Request.Form["idPagina"]);
                    nombre = string.Format("Banner_Pagina_{0}{1}", idPagina, ext);
                    folder = string.Format("Pagina_{0}", idPagina);
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




                }
                Entities.Paginas objPagina = Entities.Paginas.getByPk(idPagina);
                objPagina.imagen = nombre;
                _paginasService.updateNombreImagen(objPagina);


                return Ok(objPagina);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
