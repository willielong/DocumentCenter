using DocumentServer.Core.Comm;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Core.Filter
{
    public class CustomAuthorize : AuthorizationHandler<CustomAauthorizeRequirement>
    {

        /// <summary>
        /// 验证方案提供对象
        /// </summary>
        public IAuthenticationSchemeProvider Schemes { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public CustomAauthorizeRequirement customAauthorizeRequirement { get; set; }

        public CustomAuthorize(IAuthenticationSchemeProvider schemes, IHttpContextAccessor httpContextAccessor)
        {
            Schemes = schemes;
            HttpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAauthorizeRequirement requirement)
        {
            customAauthorizeRequirement = requirement;
            //判断请求是否拥有凭据，即有没有登录
            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await HttpContextAccessor.HttpContext.AuthenticateAsync(defaultAuthenticate.Name);
                if (result.Succeeded && result?.Principal != null)
                {
                    //ServiceLocator.currentUser = result.Principal.Identity.Name;
                    //httpContext.User = result.Principal;                                      
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }

            }
        }
    }

    public class CustomAauthorizeRequirement : IAuthorizationRequirement
    {
        public CustomAauthorizeRequirement(string _ClaimType, SigningCredentials signingCredentials)
        {
            ClaimType = _ClaimType;
            Issuer = ServiceLocator.tokenHelper.Issuer;
            Audience = ServiceLocator.tokenHelper.Audience;
            Expiration = TimeSpan.FromMinutes(double.Parse(ServiceLocator.tokenHelper.Expiration));
            SigningCredentials = signingCredentials;
        }
        /// <summary>
        /// 认证授权类型
        /// </summary>
        public string ClaimType { internal get; set; }
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 订阅人
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5000);
        /// <summary>
        /// 签名验证
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}
