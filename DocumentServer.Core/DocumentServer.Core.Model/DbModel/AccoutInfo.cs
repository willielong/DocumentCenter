using DocumentServer.Core.Model.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "账号"), Required(ErrorMessage = "{0}不能为空!"),StringLength(10,ErrorMessage ="{0}不超过10个字符"), RegularExpression(@"^([a-zA-Z0-9]){1,20}$", ErrorMessage = "请输入英文字符、数字组成的{0}")]
 
        public virtual string account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码"), Required(ErrorMessage = "{0}不能为空!"), StringLength(8, ErrorMessage = "{0}不超过8个字符"), RegularExpression(@"^([a-zA-Z0-9@#$&]){1,20}$", ErrorMessage = "密码的安全性不够，请输入英文字符、数字、特殊字符组成的{0}")]
        public virtual string password { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [Display(Name = "显示名称"), Required(ErrorMessage = "{0}不能为空!"), StringLength(20, ErrorMessage = "{0}不超过20个字符")] 
        public virtual string name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Display(Name = "电话"), PhoneValidation(ErrorMessage = "电话格式不正确!")]
        public virtual string phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱"), Email(ErrorMessage = "{0}格式不正确!")]
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
