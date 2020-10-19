using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Folder;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 文件夹接口
    /// </summary>
    [Route("api/folder"), Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1")]
    public class FolderController : BaseController
    {
        private IBizFolderService service;
        public FolderController(IBizFolderService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 进行数据新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]FileFloder model)
        {
            return ToResult(service.Add(model: model));
        }
        /// <summary>
        /// 进行数据更改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]FileFloder model)
        {
            return ToResult(service.Update(model: model));
        }
        /// <summary>
        /// 进行数据删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("delete/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            return ToResult(service.Delete(id: id));
        }
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet, Route("query/{id}")]
        public IActionResult Query([FromRoute]int id)
        {
            return ToResult(service.Get(id: id));
        }
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        [HttpGet, Route("querys/{id}")]
        public IActionResult QueryList([FromRoute]int id)
        {
            return ToResult(service.List(id: id));
        }
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public IActionResult QueryCode()
        {
            return ToResult(service.All());
        }
        /// <summary>
        /// 按组织类型和ID或文件
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="type">组织类型</param>
        /// <returns></returns>
        [HttpGet, Route("orgfolder")]
        public IActionResult OrgFolder([FromQuery]int orgid, [FromQuery] int type)
        {
            return ToResult(service.GetFoldersByOrgId(orgId: orgid, type: type));
        }
        /// <summary>
        /// 按组织类型和ID或文件
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="type">组织类型</param>
        /// <returns></returns>
        [HttpGet, Route("floders")]
        public IActionResult GetFolders([FromQuery]int orgid, [FromQuery] int type,int pid)
        {
            return ToResult(service.GetFolders(orgId: orgid, type: type,pid:pid));
        }
    }
}