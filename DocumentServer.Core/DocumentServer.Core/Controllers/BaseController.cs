using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using zipkin4net.Transport.Http;

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
            using (HttpClient client = new HttpClient(new TracingHandler("demo1")))
            {
                return new JsonResult(data);
            }
        }
    }
}