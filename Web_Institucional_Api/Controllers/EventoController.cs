using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventoController : Controller
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private IEventoService _eventoService;
        public EventoController(IEventoService eventoService, IWebHostEnvironment hostEnvironment)
        {
            _eventoService = eventoService;
            _HostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult read(int idSeccion)
        {
            var lst =
                _eventoService.read(idSeccion);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getByPk(int id)
        {
            var obj =
                _eventoService.getByPk(id);
            return Ok(obj);
        }
        [HttpGet]
        public IActionResult readFront(int idSeccion, int mes, int anio)
        {
            var lst =
                _eventoService.read(idSeccion, mes, anio);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult setImg()
        {
            try
            {
                var file = Request.Form.Files[0];
                string ext = String.Empty;

                var folder = String.Empty;

                int id = int.Parse(Request.Form["id"]);
                /*string nombre = Request.Form["nombre"];
                DateTime fecha_desde = DateTime.Parse(Request.Form["fecha_desde"]);
                string descripcion = Request.Form["descripcion"];
                TimeSpan hora_desde = TimeSpan.Parse(Request.Form["hora_desde"]);
                string lugar = Request.Form["lugar"];
                string mapa = Request.Form["mapa"];
                decimal precio = decimal.Parse(Request.Form["precio"]);
                string mas_informacion = Request.Form["mas_informacion"];*/
                int id_seccion = int.Parse(Request.Form["id_seccion"]);

                Entities.Secciones objSeccion = Entities.Secciones.getByPk(id_seccion);
                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));

                    string nombre_imagen = string.Format("Carrusel_{0}_Pagina_{1}{2}", id, objSeccion.id_page, ext);
                    folder = string.Format("Pagina_{0}", objSeccion.id_page);
                    string webRootPath = _HostEnvironment.WebRootPath;
                    string contentRootPath = _HostEnvironment.ContentRootPath;

                    string path = "";
                    path = Path.Combine(contentRootPath, "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                    if (!System.IO.Directory.Exists(path + folder))
                    {
                        System.IO.Directory.CreateDirectory(path + folder);
                    }


                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(path + folder, nombre_imagen);//pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    Entities.Evento.setImagen(id, nombre_imagen);
                }
                var lst =
                    _eventoService.read(objSeccion.id_page);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult updateActiva(Entities.Evento obj)
        {
            _eventoService.activaDesactiva(obj.id, obj.activo);
            var lst =
                _eventoService.read(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.Evento obj)
        {
            _eventoService.update(obj);

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult insert(Entities.Evento obj)
        {
            int id = _eventoService.insert(obj);
            obj.id = id;    

            return Ok(obj);
        }
    }
}
