using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.FilesInfo;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 文件夹接口
    /// </summary>
    [Route("api/file")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FilesController : BaseController
    {
        private IBizFilesService service;
        public FilesController(IBizFilesService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 进行数据新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("add"), Authorize("CustomAuthorize")]
        public IActionResult Add([FromBody]Files model)
        {
            return ToResult(service.Add(model: model));
        }
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid">文件ID</param>
        /// <returns></returns>
        [HttpPost, Route("v{version:apiVersion}/track")]
        public string TrackFile([FromQuery]int fileid, [FromQuery] string token)
        {
            return service.TrackFile(fileid: fileid, token: token);
        }
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("config"), Authorize("CustomAuthorize")]
        public IActionResult Config([FromQuery]int editType, [FromQuery]int systemType, [FromQuery]int fileid)
        {
            return ToResult(service.Config(editType: editType, systemType: systemType, fileid: fileid));
        }
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list"), Authorize("CustomAuthorize")]
        public IActionResult List()
        {
            return ToResult(service.All());
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("delete/{id}"), Authorize("CustomAuthorize")]
        public IActionResult Delete(int id)
        {
            return ToResult(service.Delete(id));
        }
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet, Route("query/{id}"), Authorize("CustomAuthorize")]
        public IActionResult Query([FromRoute]int id)
        {
            return ToResult(service.Get(id: id));
        }
        /// <summary>
        /// 进行数据更改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("update"), Authorize("CustomAuthorize")]
        public IActionResult Update([FromBody]Files model)
        {
            return ToResult(service.Update(model: model));
        }
    }
}