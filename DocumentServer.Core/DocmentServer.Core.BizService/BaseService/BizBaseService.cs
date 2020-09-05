using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentServer.Core.Comm;
using Microsoft.Extensions.DependencyInjection;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.Extensions.Configuration;

namespace DocmentServer.Core.BizService.BaseService
{
    public class BizBaseService
    {
        public HttpContext context;
        public DocumentServer.Core.Model.DbModel.Employee CurrentUser;
      
        public BizBaseService(IHttpContextAccessor httpContext)
        {
            context = httpContext.HttpContext;
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
