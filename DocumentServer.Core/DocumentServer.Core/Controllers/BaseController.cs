using Microsoft.AspNetCore.Mvc;

namespace DocumentServer.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        /// <summary>
        /// 返回数据结构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult ToResult(object data)
        {
            return new JsonResult(data);
        }
    }
}