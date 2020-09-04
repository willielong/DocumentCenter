using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentServer.Core.Comm;
using Microsoft.Extensions.DependencyInjection;

namespace DocmentServer.Core.BizService.BaseService
{
    public class BizBaseService
    {
        public DocumentServer.Core.Model.DbModel.Employee CurrentUser;
        public BizBaseService(IHttpContextAccessor httpContext)
        {
            GetEmployee(httpContext: httpContext);
        }
        /// <summary>
        /// 根据token获取员工基本信息
        /// </summary>
        /// <param name="httpContext"></param>
        public void GetEmployee(IHttpContextAccessor httpContext)
        {
            CurrentUser = httpContext.HttpContext.User.ToUser<DocumentServer.Core.Model.DbModel.Employee>();
        }
    }
}
