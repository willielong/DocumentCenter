using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.FilesInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/download"), Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController
    {
        IDownloadBizservice bizservice;
        public DownloadController(IDownloadBizservice _bizservice)
        {
            bizservice = _bizservice;
        }
        /// <summary>
        /// 进行文件下载
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get([FromBody]Model.DbModel.Files files)
        {
            var model = bizservice.DownloadFile(fileid: files.autoid);
            return File(model.Buff, model.ContentType, model.fileName); ;
        }
    }
}