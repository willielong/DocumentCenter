using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.FileVersion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/version"), Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FileVersionController : BaseController
    {
        private IBizFileVersionService service;
        public FileVersionController(IBizFileVersionService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 获取所有历史的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("hist")]
        public IActionResult refreshHistory([FromQuery]int fileid)
        {
            return ToResult(this.service.refreshHistory(fileid: fileid));
        }
        /// <summary>
        /// 获取所有历史的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("sethist")]
        public IActionResult setHistoryData([FromQuery]int fileid, [FromQuery] int version)
        {
            return ToResult(this.service.setHistoryData(fileid: fileid, version: version));
        }
    }
}