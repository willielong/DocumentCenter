/*
 * 目的：对接口请求后响应体进行标准的application/json格式封装
 * 创建人：Author
 * 创建时间：2019.10.08 10:00
 * 更新时间：
 * 更新内容：
 * 修改人：
 * 返回结果;DTO_ResponeMessage对象
 * 修改后的结果： 
 */

using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public class DTO_ResponseMessage : IResponseMessage
    {
        /// <summary>
        /// 返回HTTP请求响应码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 返回请求是否成功-true/false
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回响应后的错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回请求成功后的响应内容
        /// </summary>
        public object Body { get; set; }
    }
    public static class DtoTransfer_ResponseMessage
    {
        public static IResponseMessage ToResponse(this object obj, string msg = "")
        {
            bool status = false;
            string message = msg;
            object data = null;

            //if (obj is SqlException)
            //{
            //    SqlException ex = obj as SqlException;
            //    return new DTO_ResponseMessage()
            //    {
            //        Code = "db" + ex.Number,
            //        status = status,
            //        message = ex.Message,
            //        data = data
            //    };
            //}
            //else if (obj is BusinessException)
            //{
            //    var exp = (BusinessException)obj;

            //    return new DTO_ResponseMessage()
            //    {
            //        Code = exp.Code,
            //        message = exp.Message,
            //        status = status,
            //        data = data
            //    };
            //}
            if (obj is Exception)
            {
                var exs = ((Exception)obj).Message.Split('|');
                if (exs.Length > 1)
                {
                    if (exs[0] == "401")//获取session失败
                    {
                        data = exs[2];
                    }
                    return new DTO_ResponseMessage()
                    {
                        Code = exs[0],
                        Status = status,
                        Message = exs[1],
                        Body = data
                    };
                }
                else
                {
                    return new DTO_ResponseMessage()
                    {
                        Status = status,
                        Message = exs[0],
                        Body = data
                    };
                }
            }
            else if (obj != null)
            {
                if (Boolean.TryParse(obj.ToString(), out status))
                {
                    data = status;
                    status = true;
                }
                else if (obj is KeyValuePair<string, string>)
                {
                    data = JsonSerializer.SerializeToString(obj);
                    status = true;
                }
                else if (obj.GetType().IsValueType || obj.GetType() == typeof(String))// Dictionary<string, string>
                {
                    data = obj;
                    status = true;
                }
                else if (obj.GetType().IsClass)
                {
                    //Type type = obj.GetType();
                    //if (!type.Name.StartsWith("Dto_") &&
                    //    !type.Name.StartsWith("List") &&
                    //    !type.Name.StartsWith("Dictionary") &&
                    //    !type.Name.StartsWith("ExpandoObject"))
                    //{
                    //    throw new Exception("类名<DtoTransfer_ResponseMessage>: 映射类型错误!");
                    //}

                    data = JsonSerializer.SerializeToString(obj);
                    status = true;
                }
                else
                {
                    throw new Exception("类名<DtoTransfer_ResponseMessage>: 返回数据类型错误!");
                }
                return new DTO_ResponseMessage()
                {
                    Code = "200",
                    Status = status,
                    Message = message,
                    Body = data
                };
            }
            else
            {
                var exs = msg.Split('|');
                if (exs.Length > 1)
                {
                    return new DTO_ResponseMessage()
                    {
                        Code = exs[0],
                        Status = status,
                        Message = exs[1],
                        Body = data
                    };
                }
                else
                {
                    status = true;//空对象
                    return new DTO_ResponseMessage()
                    {
                        Status = status,
                        Message = msg,
                        Body = data
                    };
                }
            }
        }
    }
}
