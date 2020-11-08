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
    [ApiVersion("1.0")]
    [Route("api/tree"), Route("api/v{version:apiVersion}/tree"), Authorize("CustomAuthorize")]
    [ApiController]
    public class TreeV1Controller : Controllers.TreeController
    {
        private IBizTreeService service;
        public TreeV1Controller(IBizTreeService _service) : base(_service)
        {
            this.service = _service;
        }
        /// <summary>
        /// 获取树形结构接口
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="pid">上级ID</param>
        /// <returns></returns>
        public override IActionResult Trees([FromQuery] int type, [FromQuery] int pid)
        {
            return base.Trees(type, pid);
        }
        /// <summary>
        ///获取树形结构--组织结构
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="pid">上级ID</param>
        /// <returns></returns>
        public override IActionResult TreesOrg([FromQuery] int type, [FromQuery] int pid)
        {
            return base.TreesOrg(type, pid);
        }
    }
}