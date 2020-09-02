using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("AccoutInfo")]
    public class AccoutInfo : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string password { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
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
