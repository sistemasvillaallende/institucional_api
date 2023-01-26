using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;
using System.Text;

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
                path = Path.Combine(path, folder);
                var dir = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dir.GetDirectories();

                destinationDir = Path.Combine(contentRootPath,
                    "wwwroot\\ExportSites\\img\\");
                destinationDir = Path.Combine(destinationDir, folder);

                if (System.IO.Directory.Exists(destinationDir))
                    System.IO.Directory.Delete(destinationDir, true);

                System.IO.Directory.CreateDirectory(destinationDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath,true);
                }
                // Create the file, or overwrite if the file exists.
                destinationDir = Path.Combine(contentRootPath,
                    "wwwroot\\ExportSites\\");
                destinationDir = Path.Combine(destinationDir,
                    "index.html");
                using (FileStream fs = System.IO.File.Create(destinationDir))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(
                        Entities.Principal.crearPagina(1));
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
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
