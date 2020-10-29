using DocumetCenter.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class TableOrgational
    {
        /// <summary>
        /// 组织ID
        /// </summary>
       public virtual int id { get; set; }
        /// <summary>
        /// 组织编码
        /// </summary>
        public virtual string orgcode { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public virtual int parentid { get; set; }
        /// <summary>
        /// 组织中文名
        /// </summary>
        public virtual string cnname { get; set; }
        /// <summary>
        /// 组织英文名
        /// </summary>
        public virtual string enname { get; set; }
        /// <summary>
        /// 组织领导
        /// </summary>
        public virtual string dic_head { get; set; }
        /// <summary>
        /// 组织分管领导
        /// </summary>
        public virtual string dic_c_head { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual double sequence { get; set; }

        /// <summary>
        /// 显示创建人
        /// </summary>
        public virtual string dic_creator { get; set; }
        /// <summary>
        /// 显示创建日期
        /// </summary>
        public virtual string dic_createdate { get; set; }
        /// <summary>
        /// 组织类型
        /// </summary>
        public virtual OrgationalType orgtype { get; set; }
        /// <summary>
        /// 组织类型
        /// </summary>
        public virtual string dic_orgtype { get; set; }
        public virtual int unitid { get; set; }
    }
}
