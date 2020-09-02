using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Input
{
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }
}
