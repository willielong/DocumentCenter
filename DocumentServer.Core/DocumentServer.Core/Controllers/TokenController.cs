using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Login;
using DocumentServer.Core.Model.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/token")]
    [ApiVersion("1")]
    [ApiController]
    public class TokenController : BaseController
    {
        private IBizLoginService service;
        public TokenController(IBizLoginService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult GenerateToken()
        {
            return new JsonResult(new DocumentServer.Core.Comm.TokenBusiness().GenerateToken("Willie li", "P@$$w34e", "").Result);
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            return ToResult(service.LogIn(User:model));
        }
    }
}