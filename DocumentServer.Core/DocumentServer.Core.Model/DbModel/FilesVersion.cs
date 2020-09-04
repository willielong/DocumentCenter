using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("FilesVersion")]
    public class FilesVersion : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 文件Key
        /// </summary>
        public virtual string filekey { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public virtual int version { get; set; }
        /// <summary>
        /// 服务版本
        /// </summary>
        public virtual string serverVersion { get; set; }
        /// <summary>
        /// 变更集json
        /// </summary>
        public virtual string changes { get; set; }
        /// <summary>
        /// 当前版本地址
        /// </summary>
        public virtual string prevuri { get; set; }
        /// <summary>
        /// 便跟集地址
        /// </summary>
        public virtual string changesUrl { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        public virtual int fileid { get; set; }
    }
}
