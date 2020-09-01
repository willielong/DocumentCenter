using Microsoft.AspNetCore.Mvc;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public static class JsonEvent
    {

        public static object ToJson(this object obj)
        {
            var str = "";
            var responseMsg = new HttpResponseMessage();

            if (obj is string || obj is char)
            {
                str = obj.ToString();
            }
            else
            {
                str = JsonSerializer.SerializeToString(obj);

                //if (((Dto_ResponseMessage)obj).status)
                //    responseMsg.StatusCode = HttpStatusCode.OK;
                //else
                //    responseMsg.StatusCode = HttpStatusCode.InternalServerError;
            }

            responseMsg.Content = new StringContent(str, Encoding.GetEncoding("utf-8"), "text/html");

            return responseMsg;
        }

        public static object ToImage(this object obj, string contentType = "")
        {
            var type = contentType == "" ? "PNG" : contentType;
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK);

            if (obj != null)
            {
                if (obj is byte[])
                {
                    responseMsg.Content = new ByteArrayContent((byte[])obj);
                    responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                }
            }

            return responseMsg;
        }

        /// <summary>
        /// 将字符串转换成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string Json)
        {
            return JsonSerializer.DeserializeFromString<T>(Json);
        }
        /// <summary>
        /// 将实体类转换成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static string ToJsonString(this object Json)
        {
            return JsonSerializer.SerializeToString(Json);
        }

        public static JsonResult ToJsonResult(this object data)
        {
            return new JsonResult(data);
        }
        /// <summary>
        /// 将token中的数据转化成数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="User"></param>
        /// <returns></returns>
            public static T ToUser<T>(this ClaimsPrincipal User) where T : class
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userString = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            return userString.ToEntity<T>();
        }
    }
}
