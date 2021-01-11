using DocmentServer.Core.BizService.Personal;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Route("api/account"), Authorize("CustomAuthorize")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {
        private IBizAccountService service;
        public AccountController(IBizAccountService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 进行数据新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]AccoutInfo model)
        {
            return ToResult(service.Add(model: model));
        }
        /// <summary>
        /// 进行数据更改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]AccoutInfo model)
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
        /// 获取账号信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账号实体</param>
        /// <returns></returns>
        [HttpGet, Route("querys/{id}")]
        public IActionResult QueryList([FromRoute]int id)
        {
            return ToResult(service.List(id: id));
        }
        /// <summary>
        /// 获取账号信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账号实体</param>
        /// <returns></returns>
        [HttpGet, Route("getlist/{code}")]
        public IActionResult QueryCode([FromRoute]string code)
        {
            return ToResult(service.GetListByCode(code: code));
        }
        /// <summary>
        /// 获取账号信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账号实体</param>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public IActionResult QueryCode()
        {
            return ToResult(service.All());
        }
        /// <summary>
        /// 获取账号信息--根据EmpId
        /// </summary>
        /// <param name="empid">员工基本信息ID</param>
        /// <returns></returns>
        [HttpGet, Route("emp/{empid:int}")]
        public IActionResult QueryByEmpId(int empid)
        {
            return ToResult(service.QueryByEmpId(empid:empid));
        }
    }
}