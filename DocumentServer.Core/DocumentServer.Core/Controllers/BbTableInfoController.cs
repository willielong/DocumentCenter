using DocmentServer.Core.BizService.BbTableInfo;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 表结构相关接口
    /// </summary>
    [Route("api/tables"), Authorize("CustomAuthorize"), ApiController, ApiVersion("2.0")]
    public class BbTableInfoController : BaseController
    {
        private IBizBbTableInfoService service;
        public BbTableInfoController(IBizBbTableInfoService _service)
        {
            this.service = _service;
        }
        /// <summary>
        /// 进行数据新增
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]Bb_TableInfo model)
        {
            return ToResult(service.Add(model: model));
        }
        /// <summary>
        /// 进行数据更改
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]Bb_TableInfo model)
        {
            return ToResult(service.Update(model: model));
        }
        /// <summary>
        /// 进行数据删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpDelete, Route("delete/{id}")]
        public IActionResult LogicDelete([FromRoute]int id)
        {
            return ToResult(service.LogicDelete(autoid: id));
        }
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet, Route("query/{id}")]
        public IActionResult Query([FromRoute]int id)
        {
            return ToResult(service.Get(id: id));
        }
        /// <summary>
        /// 获取数据表信息--多个
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public IActionResult QueryCode()
        {
            return ToResult(service.All());
        }
        /// <summary>
        /// 启用禁用
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="enable">启用禁用</param>
        /// <returns></returns>
        [HttpDelete, Route("enable")]
        public IActionResult QueryCode([FromQuery]int id, [FromQuery] bool enable)
        {
            return ToResult(service.OperationEnable(id, enable));
        }
    }
}