using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Company;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CompanyController : ControllerBase
    {
        private IBizCompanyService service;
        public CompanyController(IBizCompanyService service)
        {
            this.service = service;
        }
        [HttpPost,Route("add")]
        public IActionResult Add(UnitInfo model)
        {
            return new JsonResult(this.service.Add(model: model));
        }
    }
}