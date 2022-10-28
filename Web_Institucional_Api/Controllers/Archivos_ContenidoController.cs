using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Institucional_Api.Services;
namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Archivos_ContenidoController : Controller
    {
        private IArchivosContenidoService _archivosContenidoService;
        private readonly IWebHostEnvironment _HostEnvironment;

        [Obsolete]
        public Archivos_ContenidoController(IArchivosContenidoService archivosContenidoService,
            IWebHostEnvironment HostEnvironment)
        {
            _archivosContenidoService = archivosContenidoService;
            _HostEnvironment = HostEnvironment;
        }
        [HttpGet]
        public IActionResult read(int id_contenido)
        {
            var lst =
                _archivosContenidoService.read(id_contenido);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readNews(int id_news)
        {
            var lst =
                _archivosContenidoService.readNews(id_news);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivos(int id_contenido)
        {
            var lst =
                _archivosContenidoService.readActivos(id_contenido);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivosNews(int id_news)
        {
            var lst =
                _archivosContenidoService.readActivosNews(id_news);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult reordenarContenido(List<Entities.archivos_x_contenido> lst)
        {
            _archivosContenidoService.setOrden(lst);
            return Ok();
        }
        [HttpPost]
        public IActionResult activaDesactivaContenido(Entities.archivos_x_contenido obj)
        {
            _archivosContenidoService.activaDesactiva(obj.id, obj.activo);

            if (obj.id_contenido != 0)
            {
                var lst =
                    _archivosContenidoService.read(obj.id_contenido);
                return Ok(lst);
            }
            else
            {
                var lst =
                 _archivosContenidoService.readNews(obj.id_news);
                return Ok(lst);
            }
        }
        [HttpPost]
        public IActionResult deleteArchivos(int[] lst)
        {
            if (lst.Count() == 0)
                return Ok(lst);
            Entities.archivos_x_contenido obj = Entities.archivos_x_contenido.getByPk(lst[0]);
            Entities.contenido_seccion objContenido = Entities.contenido_seccion.getByPk(obj.id_contenido);
            Entities.Secciones objSeccion = Entities.Secciones.getByPk(objContenido.id_seccion);
            foreach (var item in lst)
            {
                obj = Entities.archivos_x_contenido.getByPk(item);
                var nombre = obj.link_archivo;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                folder = string.Format("Pagina_{0}", objSeccion.id_page);
                string webRootPath = _HostEnvironment.WebRootPath;
                string contentRootPath = _HostEnvironment.ContentRootPath;

                string path = "";
                path = Path.Combine(contentRootPath, "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                var fullPath = Path.Combine(path + folder, nombre);

                if (System.IO.File.Exists(fullPath))
                {
                    try
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The deletion failed: {0}", e.Message);
                    }
                }
                _archivosContenidoService.delete(item);
            }




            return Ok();
        }
        [HttpPost]
        public IActionResult update(Entities.archivos_x_contenido obj)
        {
            _archivosContenidoService.update(obj);
            var lst =
                _archivosContenidoService.read(obj.id_contenido);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;

                int i = 0;
                int id_contenido = int.Parse(Request.Form["id_contenido"]);
                string nombre_archivo = Request.Form["nombre_archivo"];
                Entities.contenido_seccion objContenido = Entities.contenido_seccion.getByPk(id_contenido);
                int id_seccion = objContenido.id_seccion;
                Entities.Secciones objSeccion = Entities.Secciones.getByPk(objContenido.id_seccion);
                int id_pagina = objSeccion.id_page;
                i = _archivosContenidoService.getMaxOrden(id_contenido) + 1;
                foreach (var item in files)
                {
                    var file = item;
                    string ext = String.Empty;

                    var nombre = String.Empty;
                    //var folderName = Path.Combine("Resources");
                    var folder = String.Empty;
                    //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {

                        ext = Path.GetExtension(file.FileName.Trim('"'));
                        nombre = string.Format("Archivo_{0}_Seccion_{1}_contenido_{2}{3}",
                            i, id_seccion, id_contenido, ext);
                        folder = string.Format("Pagina_{0}", id_pagina);
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

                        Entities.archivos_x_contenido objArchivoContenido = new Entities.archivos_x_contenido();
                        objArchivoContenido.link_archivo = nombre;
                        objArchivoContenido.nombre_archivo = nombre_archivo;
                        objArchivoContenido.orden = i;
                        objArchivoContenido.activo = true;
                        objArchivoContenido.id_contenido = id_contenido;
                        _archivosContenidoService.insert(objArchivoContenido);
                        i++;
                    }

                }
                var lst =
                    _archivosContenidoService.read(id_contenido);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult UploadFileNews()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;

                int i = 0;
                int id_news = int.Parse(Request.Form["id_news"]);
                string nombre_archivo = Request.Form["nombre_archivo"];
                Entities.News objNews = Entities.News.getByPk(id_news);
                int id_pagina = objNews.id_page;
                i = _archivosContenidoService.getMaxOrdenNews(id_news) + 1;
                foreach (var item in files)
                {
                    var file = item;
                    string ext = String.Empty;

                    var nombre = String.Empty;
                    //var folderName = Path.Combine("Resources");
                    var folder = String.Empty;
                    //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {

                        ext = Path.GetExtension(file.FileName.Trim('"'));
                        nombre = string.Format("Archivo_{0}_News_{1}{2}",
                            i, id_news, ext);
                        folder = string.Format("Pagina_{0}", id_pagina);
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

                        Entities.archivos_x_contenido objArchivoContenido = new Entities.archivos_x_contenido();
                        objArchivoContenido.link_archivo = nombre;
                        objArchivoContenido.nombre_archivo = nombre_archivo;
                        objArchivoContenido.orden = i;
                        objArchivoContenido.activo = true;
                        objArchivoContenido.id_news = id_news;
                        _archivosContenidoService.insert(objArchivoContenido);
                        i++;
                    }

                }
                var lst =
                    _archivosContenidoService.readNews(id_news);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
