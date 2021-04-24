using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : BaseController
    {
        [HttpGet, Route("get")]
        public IActionResult Get() => Ok("ok");
    }
}