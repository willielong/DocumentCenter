using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("Files")]
    public class Files : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public virtual int folderid { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public virtual string cnname { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public virtual string enname { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public virtual string ext { get; set; }
        /// <summary>
        /// 所属类型--组织/单位/个人
        /// </summary>
        public virtual int filetype { get; set; }
        /// <summary>
        /// 文件网络地址
        /// </summary>
        public virtual string fileuri { get; set; }
        /// <summary>
        /// 文件物理路径
        /// </summary>
        public virtual string filepath { get; set; }
        /// <summary>
        /// 文件全路径
        /// </summary>
        public virtual string path { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string folderpath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual double size { get; set; }
        /// <summary>
        /// 当前文件版本
        /// </summary>
        public virtual int currentVersion { get; set; }
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
