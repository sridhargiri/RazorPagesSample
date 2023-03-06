using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W1.Controllers
{
    [Route("api/v{version}/[controller]")] //https://localhost:44377/api/v3/employeev
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1", Deprecated = true)]
    [ApiVersion("2.0")]
    public class EmployeeV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller");
        }
    }
}
