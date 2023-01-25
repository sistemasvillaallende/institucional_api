using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExportSitioController : ControllerBase
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        public ExportSitioController(IWebHostEnvironment HostEnvironment)
        {
            _HostEnvironment = HostEnvironment;

        }
        [HttpPost]
        public IActionResult Index()
        {
            List<int> paginas = new List<int>();
            paginas.Add(1);
            string fecha_nombre = string.Format("{0}{1}{2}{3}{4}{5}",
                DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second);
            
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string folder;
            string path = "";
            string destinationDir = "";
            for (int i = 0; i < paginas.Count; i++)
            {
                folder = string.Format("Pagina_{0}", i + 1);
                path = Path.Combine(contentRootPath, 
                    "wwwroot\\Assets\\Archivos_Pagina_Institucional\\");
                var dir = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dir.GetDirectories();

                destinationDir = Path.Combine(contentRootPath,
                    "wwwroot\\ExportSites\\img\\");

                if (System.IO.File.Exists(destinationDir + folder))
                    System.IO.File.Delete(destinationDir + folder);

                System.IO.Directory.CreateDirectory(destinationDir + folder);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

            }
            //string startPath = @".\start";
            //string zipPath = @".\result.zip";



            //ZipFile.CreateFromDirectory(startPath, zipPath);

            //string contentType = "application/octet-stream";
            //string extension = "zip";
            //string ruta = Path.Combine(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            //    "Sitio." + extension);
            //byte[] bites = System.IO.File.ReadAllBytes(ruta);//lectura en bytes
            ////si no se agrega este header la imagen solamente se muestra en la
            ////página y si se agrega entonces se descarga
            //Response.Headers.Add("Content-Disposition",
            //    $"attachment; filename=\"sitio.{extension}\"");
            //return File(bites, contentType);//resultado
            return Ok();
        }
    }
}
