using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class TreeTableModel
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        public virtual int id { get; set; }

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
        /// 文件类型
        /// </summary>
        public virtual int  filetype { get; set; }
        /// <summary>
        /// 显示文件的类型
        /// </summary>
        public virtual string dic_filetype { get; set; }
        /// <summary>
        /// 所属类型--组织/单位/个人
        /// </summary>
        public virtual int  orgtype { get; set; }
        public virtual string dic_orgtype { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual string size { get; set; }
        /// <summary>
        /// 当前文件版本
        /// </summary>
        public virtual string currentVersion { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }

        public virtual string path { get; set; }
        public virtual int orgid { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string fileurl { get; set; }
    }
}
