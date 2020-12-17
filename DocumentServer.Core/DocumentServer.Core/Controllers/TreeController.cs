using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Tree;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/tree"), Authorize("CustomAuthorize")] 
    public class TreeController : BaseController
    {
        private IBizTreeService service;
        public TreeController(IBizTreeService _service)
        {
            this.service = _service;
        }
        /// <summary>
        /// 获取树形结构接口
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="pid">上级ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Trees([FromQuery]int type, [FromQuery]int pid)
        {
            return ToResult(service.Trees(type: type, pid: pid));
        }
        /// <summary>
        ///获取树形结构--组织结构
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="pid">上级ID</param>
        /// <returns></returns>
        [HttpGet,Route("org")]
        public virtual IActionResult TreesOrg([FromQuery]int type, [FromQuery]int pid)
        {
            return ToResult(service.TreesOrg(type: type, pid: pid));
        }
        /// <summary>
        ///获取树形结构--组织结构
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="pid">上级ID</param>
        /// <returns></returns>
        [HttpGet, Route("org1")]
        public virtual IActionResult TreesOrg1([FromQuery]int type, [FromQuery]int pid)
        {
            throw new NullReferenceException();
        }
    }
}