using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("FileFloder")]
    public class FileFloder : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public virtual int parentId { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public virtual string cnname { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public virtual string enname { get; set; }
        /// <summary>
        /// 全路径
        /// </summary>
        public virtual string path { get; set; }
        /// <summary>
        /// 所属类型--组织/单位/个人
        /// </summary>
        public virtual int flodertype { get; set; }
        /// <summary>
        /// 启用？
        /// </summary>
        public virtual bool enable { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }
        /// <summary>
        /// 包含组织/单位/个人的ID
        /// </summary>
        public virtual int orgid { get; set; }
    }
}
