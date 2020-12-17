using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("Bb_TableInfo")]
    public class Bb_TableInfo : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public virtual string cnname { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public virtual string enname { get; set; }


        /// <summary>
        /// 删除？
        /// </summary>
        public virtual bool isdel { get; set; }

        /// <summary>
        /// 是否是系统表
        /// </summary>
        public virtual bool issystem { get; set; }

        /// <summary>
        /// 表编码
        /// </summary>
        public virtual string tablecode { get; set; }

        /// <summary>
        /// 启用？
        /// </summary>
        public virtual bool enable { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }
    }
}
