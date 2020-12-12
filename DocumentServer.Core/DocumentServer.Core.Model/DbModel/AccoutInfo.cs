using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Dapper.Contrib.Extensions.Table("AccoutInfo")]
    public class AccoutInfo : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Dapper.Contrib.Extensions.Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号"), Required(ErrorMessage = "{0}不能为空!"),StringLength(20,ErrorMessage ="{0}不超过20个字符")]
        [RegularExpression(@"^[a-zA-Z0-9_]{4,16}$", ErrorMessage = "只能包含字符、数字和下划线")]
        public virtual string account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string password { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [Display(Name = "显示名称"), Required(ErrorMessage = "{0}不能为空!"), StringLength(20, ErrorMessage = "{0}不超过20个字符")]
        [RegularExpression(@"^[a-zA-Z0-9_]{4,16}$", ErrorMessage = "只能包含字符、数字和下划线")]
        public virtual string name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string email { get; set; }
        /// <summary>
        /// 启用？
        /// </summary>
        public virtual bool enable { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }

        /// <summary>
        /// 员工基本信息ID
        /// </summary>
        public virtual int empid { get; set; } 
    }
}
