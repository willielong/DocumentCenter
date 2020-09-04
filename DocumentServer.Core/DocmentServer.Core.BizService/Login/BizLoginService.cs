using System;
using System.Collections.Generic;
using System.Text;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Personal;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.Input;
using System.Linq;

namespace DocmentServer.Core.BizService.Login
{
    public class BizLoginService : IBizLoginService
    {
        IAccountDomainService accountDomainService;
        IEmployeeDomainService employeeDomainService;
        public BizLoginService(IAccountDomainService accountDomainService, IEmployeeDomainService employeeDomainService)
        {
            this.accountDomainService = accountDomainService;
            this.employeeDomainService = employeeDomainService;
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public IResponseMessage LogIn(LoginModel User)
        {
            if (null == User)
            {
                return "请输入登录信息".ToResponse();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(User.account) || User.account == "string")
                {
                    return "用户名不能为空!".ToResponse();
                }
                else if (string.IsNullOrWhiteSpace(User.password) || User.password == "string")
                {
                    return "密码不能为空!".ToResponse();
                }
                else
                {
                    DocumentServer.Core.Model.DbModel.AccoutInfo accout = this.accountDomainService.GetListByCode(code: User.account).SingleOrDefault();
                    if (accout == null)
                        return "当前用户名不存在!请联系管理员！".ToResponse();
                    else
                    {
                        if (accout.password == User.password)
                        {
                            var emp = this.employeeDomainService.Get<DocumentServer.Core.Model.DbModel.Employee>(id: accout.empid);
                            var token = new TokenBusiness().GenerateToken(accout.account, accout.name, emp.ToJsonString()).Result;
                            if (null != token)
                            {
                                return token.ToResponse();
                            }
                            else
                            {
                                return "未生成登录令牌!".ToResponse();
                            }
                        }
                        else
                        {
                            return "当前用户密码不正确!请重新输入！".ToResponse();
                        }
                    }
                }
            }
        }
    }
}
