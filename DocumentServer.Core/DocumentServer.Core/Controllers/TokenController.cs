using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public IActionResult GenerateToken()
        {
            return new JsonResult(new DocumentServer.Core.Comm.TokenBusiness().GenerateToken(HttpContext, "Willie li", "P@$$w34e", "").Result);
        }
    }
}