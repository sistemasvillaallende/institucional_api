using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeccionController : Controller
    {
        private ISeccionesService _seccionesService;
        private readonly IWebHostEnvironment _HostEnvironment;

        [Obsolete]
        public SeccionController(ISeccionesService seccionesService, IWebHostEnvironment HostEnvironment)
        {
            _seccionesService = seccionesService;
            _HostEnvironment = HostEnvironment;
        }
        [HttpGet]
        public IActionResult getByPk(int pk)
        {
            var lst =
                _seccionesService.getByPk(pk);
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult getByPkActivos(int pk)
        {
            var lst =
                _seccionesService.getByPkActivos(pk);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.Secciones obj)
        {
            int id = _seccionesService.insert(obj);
            return Ok(id);
        }
        [HttpPost]
        public IActionResult deleteGaleria(int[] lst)
        {
            if (lst.Count() == 0)
                return Ok(lst);
            Entities.contenido_seccion obj = Entities.contenido_seccion.getByPk(lst[0]);
            Entities.Secciones objSeccion = Entities.Secciones.getByPk(obj.id_seccion);
            foreach (var item in lst)
            {
                obj = Entities.contenido_seccion.getByPk(item);
                var nombre = obj.imagen;
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
                _seccionesService.deleteGaleria(item);
            }




            return Ok();
        }
        [HttpPost]
        public IActionResult update(Entities.Secciones obj)
        {
            _seccionesService.update(obj);
            var lst =
                _seccionesService.getByPk(obj.id);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult reordenar(Entities.Paginas obj)
        {
            _seccionesService.reordenar(obj);
            return Ok();
        }
        [HttpPost]
        public IActionResult delete(Entities.Secciones obj)
        {
            _seccionesService.delete(obj.id);
            return Ok();
        }
        [HttpPost]
        public IActionResult activaDesactiva(Entities.Secciones obj)
        {
            _seccionesService.activaDesactiva(obj.id, obj.activo);
            return Ok();
        }



        [HttpPost]
        public IActionResult insertContenido(Entities.contenido_seccion obj)
        {
            int id = _seccionesService.insertContenido(obj);
            var lst =
                _seccionesService.getByPk(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateContenido(Entities.contenido_seccion obj)
        {
            _seccionesService.updateContenido(obj);
            var lst =
                _seccionesService.getByPk(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult deleteContenido(Entities.contenido_seccion obj)
        {
            _seccionesService.deleteContenido(obj.id);
            var lst =
                _seccionesService.getByPk(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult reordenarContenido(Entities.Secciones obj)
        {
            _seccionesService.setOrdenContenido(obj);
            return Ok();
        }
        [HttpPost]
        public IActionResult activaDesactivaContenido(Entities.contenido_seccion obj)
        {
            _seccionesService.activaDesactivaContenido(obj.id, obj.activo);
            var lst =
                _seccionesService.getByPk(obj.id_seccion);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult setBackGroundColor(Entities.Secciones obj)
        {
            _seccionesService.setBackGroundColor(obj.id, obj.background_color);
            
            return Ok();
        }
        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;

                int i = 0;
                int id_seccion = int.Parse(Request.Form["id_seccion"]);
                int id_pagina = int.Parse(Request.Form["id_pagina"]);
                i = _seccionesService.getMaxOrdenContenido(id_seccion) + 1;
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
                        nombre = string.Format("Imagen_{0}_Seccion_{1}{2}", i, id_seccion, ext);
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

                        Entities.contenido_seccion objContenido = new Entities.contenido_seccion();
                        objContenido.id_seccion = id_seccion;
                        objContenido.imagen = nombre;
                        objContenido.orden = i;
                        _seccionesService.insertContenidoGaleria(objContenido);
                        i++;
                    }

                }

                return Ok(_seccionesService.read(id_pagina));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
