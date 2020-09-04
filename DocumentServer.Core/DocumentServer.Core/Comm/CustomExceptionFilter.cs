using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Core.Comm
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            DTO_ResponseMessage msg = new DTO_ResponseMessage { Status = false, Code = 200, Body = null };

            msg.Message = "服务器异常!";
            if (context.Exception is DbException)
            {
                msg.Code = 1001;
                msg.Message = "数据库异常";
            }
            //if (context.Exception is SqlException)
            //{
            //    msg.Code = "1002";
            //    msg.Message = "数据库异常";
            //}
            else if (context.Exception is ArgumentException)
            {
                msg.Code = 5001;
                msg.Message = "参数异常";
            }
            else if (context.Exception is NullReferenceException)
            {
                msg.Code = 5002;
                msg.Message = "空指针异常";
            }
            else
            {
                msg.Code = 500;
                msg.Message = context.Exception.Message;
            }
            JsonResult result = new JsonResult(msg.Message)
            {
                StatusCode =msg.Code,
            };
            context.Result = result;
            base.OnException(context);
        }
    }
}
