using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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