using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NewsController : ControllerBase
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private INewsService _newsService;
        public NewsController(INewsService newsService, IWebHostEnvironment HostEnvironment)
        {
            _newsService = newsService;
            _HostEnvironment = HostEnvironment;

        }
        [HttpPost]
        public IActionResult insertUpdate(Entities.News obj)
        {
            if (obj.id == 0)
            {
                _newsService.insert(obj);
            }
            else
            {
                _newsService.update(obj);
            }
            var lst =
                _newsService.getByPk(obj.seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult activaDesactiva(Entities.News obj)
        {
            _newsService.activaDesactiva(obj);
            var lst =
                _newsService.getBySeccion(obj.seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult delete(Entities.News obj)
        {
            _newsService.delete(obj.id);
            var lst =
                _newsService.getBySeccion(obj.seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
    DateTime.Now.Year, DateTime.Now.Month,
    DateTime.Now.Day, DateTime.Now.Hour,
    DateTime.Now.Minute, DateTime.Now.Second);
                var file = Request.Form.Files[0];
                string ext = String.Empty;

                var nombre = String.Empty;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                int id = int.Parse(Request.Form["id"]);
                string titulo = Request.Form["titulo"];
                string fecha = Request.Form["fecha"];
                string img = Request.Form["img"];
                string cuerpo = Request.Form["cuerpo"];
                int idSeccion = int.Parse(Request.Form["seccion"]);
                Entities.Secciones objSeccion = null;
                bool pricipal = false;
                int idPagina = 0;
                if (idSeccion != 0)
                {
                    objSeccion = Entities.Secciones.getByPk(idSeccion);
                    idPagina = objSeccion.id_page;
                }
                else
                {
                    idPagina = 0;
                    pricipal = true;
                }
                Entities.News obj = new Entities.News();
                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));

                    if (id == 0)
                    {
                        obj.titulo = titulo;
                        obj.pricipal = pricipal;
                        obj.activo = true;
                        obj.fecha = Convert.ToDateTime(fecha);
                        obj.seccion = idSeccion;
                        obj.cuerpo = cuerpo;
                        obj.id = _newsService.insert(obj);
                    }
                    else
                    {
                        obj = Entities.News.getByPk(id);
                        obj.fecha = Convert.ToDateTime(fecha);
                        obj.cuerpo = cuerpo;
                        obj.titulo = titulo;
                    }
                    nombre = string.Format("Noticia_{0}_Pagina_{1}_Seccion_{2}_{3}{4}",
                        obj.id, idPagina, idSeccion, fecha_nombre, ext);
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

                    obj.img = nombre;
                    Entities.News.update(obj);

                }
                var lst =
                    _newsService.getBySeccion(idSeccion);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
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
        [HttpPost]
        public IActionResult reordenarContenido(List<Entities.News> obj)
        {
            _newsService.updateOrden(obj);
            return Ok();
        }
        [HttpPost]
        public IActionResult reordenarGaleria(List<Entities.images_x_news> obj)
        {
            _newsService.updateOrdenImages(obj);
            return Ok();
        }
        [HttpPost]
        public IActionResult deleteGaleria(int[] lst)
        {
            if (lst.Count() == 0)
                return Ok(lst);
            Entities.images_x_news obj = Entities.images_x_news.getByPk(lst[0]);
            Entities.News objNews = Entities.News.getByPk(obj.idNews);
            foreach (var item in lst)
            {
                obj = Entities.images_x_news.getByPk(item);
                var nombre = obj.img;
                //var folderName = Path.Combine("Resources");
                var folder = String.Empty;
                folder = string.Format("Pagina_{0}", objNews.id_page);
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
               _newsService.deleteImagenGaleria(item);
            }




            return Ok();
        }
        [HttpPost]
        public IActionResult UploadGaleria()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;

                int i = 0;
                int id_news = int.Parse(Request.Form["id_news"]);
                Entities.News objNews = _newsService.getByPk(id_news);
                i = _newsService.getMaxOrdenGaleria(objNews.id) + 1;
                string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
    DateTime.Now.Year, DateTime.Now.Month,
    DateTime.Now.Day, DateTime.Now.Hour,
    DateTime.Now.Minute, DateTime.Now.Second);
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
                        nombre = string.Format("ImagenGaleria_{0}_Noticia_{1}_{2}{3}", i, objNews.id,
                            fecha_nombre, ext);
                        folder = string.Format("Pagina_{0}", objNews.id_page);
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

                        Entities.images_x_news objImagenes = new Entities.images_x_news();
                        objImagenes.idNews = objNews.id;
                        objImagenes.img = nombre;
                        objImagenes.orden = i;
                        objImagenes.categoria = objNews.id_page;
                        _newsService.insertImagenGaleria(objImagenes);
                        i++;
                    }

                }

                var lst =
                    _newsService.readImages(objNews.id);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
