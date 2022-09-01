using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Institucional_Api.Services;

namespace Web_Institucional_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutoridadesController : ControllerBase
    {
        private IAutoridadesService _autoridadesService;
        public AutoridadesController(IAutoridadesService autoridadesService)
        {
            _autoridadesService = autoridadesService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _autoridadesService.read();
            return Ok(lst);
        }
    }
}
