using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mapledotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController, EnableCors("AllowOrigin")]
    public class DataController : ControllerBase
    {
        IWebHostEnvironment _env;
        public DataController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpGet("Services")]
        public string Get()
        {
            string json = _env.ContentRootPath + "\\services.json";
            return System.IO.File.ReadAllText(json);
        }
        [HttpGet("Providers")]
        public string Providers()
        {
            string json = _env.ContentRootPath + "\\Providers.json";
            return System.IO.File.ReadAllText(json);
        }
    }
}
