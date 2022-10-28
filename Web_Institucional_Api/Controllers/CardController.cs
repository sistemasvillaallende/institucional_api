using Microsoft.AspNetCore.Mvc;
using Web_Institucional_Api.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CardController : Controller
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private ICardsService _cardService;
        public CardController(ICardsService cardService, IWebHostEnvironment hostEnvironment)
        {
            _cardService = cardService;
            _HostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult read(int id_seccion)
        {
            var lst =
                _cardService.read(id_seccion);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult readActivas(int id_seccion)
        {
            var lst =
                _cardService.readActivos(id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.Cards obj)
        {
            _cardService.insert(obj);
            var lst =
                _cardService.read(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.Cards obj)
        {
            _cardService.update(obj);
            var lst =
                _cardService.read(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];

                string ext = String.Empty;
                int idSeccion = int.Parse(Request.Form["idSeccion"]);
                int idCard = int.Parse(Request.Form["idCard"]);
                int idPagina = int.Parse(Request.Form["idPagina"]);
                var nombre = String.Empty;
                var folder = String.Empty;
                string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
                    DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day, DateTime.Now.Hour,
                    DateTime.Now.Minute, DateTime.Now.Second);

                string fecha = string.Empty;

                if (file.Length > 0)
                {
                    ext = Path.GetExtension(file.FileName.Trim('"'));
                    nombre = string.Format("Card_{0}_Seccion_{1}_Pagina_{2}{3}{4}", 
                        idCard, idSeccion, idPagina, fecha_nombre, ext);
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
                _cardService.setImagen(idCard, nombre);

                var lst =
                    _cardService.read(idSeccion);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult updateActiva(Entities.Cards obj)
        {
            _cardService.activaDesactiva(obj.id, obj.activo);
            var lst =
                _cardService.read(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult delete(Entities.Cards obj)
        {
            _cardService.delete(obj.id);
            var lst =
                _cardService.read(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateOrden(List<Entities.Cards> lstO)
        {
            _cardService.setOrden(lstO);
            var lst =
                _cardService.read(lstO[0].id_seccion);
            return Ok(lst);
        }
    }
}
