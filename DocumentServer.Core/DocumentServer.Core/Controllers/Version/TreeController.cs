using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Tree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers.Version
{
    /// <summary>
    /// 树型结构
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/tree"), Route("api/v{version:apiVersion}/tree"), Authorize("CustomAuthorize")]
    [ApiController]
    public class TreeV2Controller :  Controllers.TreeController
    {
        private IBizTreeService service;
        public TreeV2Controller(IBizTreeService _service) :base(_service)
        {
            this.service = _service;
        }
        public override IActionResult TreesOrg1([FromQuery] int type, [FromQuery] int pid)
        {
            return base.TreesOrg1(type, pid);
        }
    }
}