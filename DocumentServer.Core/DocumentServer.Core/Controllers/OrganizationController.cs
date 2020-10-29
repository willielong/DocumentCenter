using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocmentServer.Core.BizService.Organization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 组织相关接口
    /// </summary>
    [Route("api/organization"), Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1")]
    public class OrganizationController : BaseController
    {
        private IBizOrganizationService service;
        public OrganizationController(IBizOrganizationService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 进行数据新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]DocumentServer.Core.Model.DbModel.Organization model)
        {
            return ToResult(service.Add(model: model));
        }
        /// <summary>
        /// 进行数据更改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]DocumentServer.Core.Model.DbModel.Organization model)
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
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        [HttpGet, Route("querys/{id}")]
        public IActionResult QueryList([FromRoute]int id)
        {
            return ToResult(service.List(id: id));
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        [HttpGet, Route("getlist/{code}")]
        public IActionResult QueryCode([FromRoute]string code)
        {
            return ToResult(service.GetListByCode(code: code));
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public IActionResult QueryCode()
        {
            return ToResult(service.All());
        }

        /// <summary>
        /// 获取子级的组织
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet, Route("tables")]
        public IActionResult GetTableOrganization(int pid)
        {
            return ToResult(service.GetTableOrganization(pid: pid));
        }
    }
}