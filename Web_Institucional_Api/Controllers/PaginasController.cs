using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaginasController : Controller
    {
        private IPaginasService _paginasService;
        private readonly IWebHostEnvironment _HostEnvironment;
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
        public IActionResult getLstSecciones(int idPage)
        {
            var lst =
                _paginasService.lstSecciones(idPage);

            return Ok(lst.ToArray());
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
        public IActionResult updateActivaContenidoPrincipal(Entities.Paginas obj)
        {
            _paginasService.updateActivaContenidoPrincipal(obj.id , obj.seccion_pricipal);
            var objr = _paginasService.getByPk(obj.id);
            return Ok(objr);
        }
        [HttpPost]
        public IActionResult updateActivaContenidoPrincipalBanner(Entities.Paginas obj)
        {
            _paginasService.updateActivaContenidoPrincipalBanner(obj.id, obj.seccion_principal_banner);
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
                string fecha = string.Empty;
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
                    Entities.Carrusel.read(id_page);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var tipo = Request.Form["tipo"];
                var file = Request.Form.Files[0];

                string ext = String.Empty;
                int idPagina = int.Parse(Request.Form["idPagina"]);
                var nombre = String.Empty;
                var folder = String.Empty;
                string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
                    DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day, DateTime.Now.Hour,
                    DateTime.Now.Minute, DateTime.Now.Second);
                int id = 0;
                int id_page = 0;
                string fecha = string.Empty;
                switch (tipo)
                {
                    case "PAGINA":
                        if (file.Length > 0)
                        {
                            ext = Path.GetExtension(file.FileName.Trim('"'));
                            nombre = string.Format("Banner_Pagina_{0}_{1}{2}", idPagina, fecha_nombre, ext);
                            folder = string.Format("Pagina_{0}", idPagina);
                            string webRootPath = _HostEnvironment.WebRootPath;
                            string contentRootPath = _HostEnvironment.ContentRootPath;

                            string path = "";
                            path = Path.Combine(contentRootPath, "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                            if (!System.IO.Directory.Exists(path + folder))
                            {
                                System.IO.Directory.CreateDirectory(path + folder);
                            }
                            var fullPath = Path.Combine(path + folder, nombre);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                        Entities.Paginas objPagina = Entities.Paginas.getByPk(idPagina);
                        objPagina.imagen = nombre;
                        _paginasService.updateNombreImagen(objPagina);

                        return Ok(objPagina);
                    case "CARRUSEL":
                        id = int.Parse(Request.Form["id"]);
                        id_page = idPagina;

                        if (file.Length > 0)
                        {
                            ext = Path.GetExtension(file.FileName.Trim('"'));

                            nombre = string.Format("Carrusel_{0}_Pagina_{1}_{2}{3}", id, id_page, fecha_nombre, ext);
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
                            Entities.Carrusel.read(id_page);
                        return Ok(lst);                  
                    default:
                        break;
                }

                return Ok();    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
