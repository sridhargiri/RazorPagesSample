using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mapledotnet.ContractModel;
using mapledotnet.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mapledotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController, EnableCors("AllowOrigin")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService env)
        {
            _contractService = env;
        }
        [HttpPost("Create")]
        public void Create([FromBody] Contracts contract)
        {
            _contractService.AddContract(contract);
        }
    }
}
