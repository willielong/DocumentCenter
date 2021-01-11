using DocumetCenter.Core.Enum;

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
        public virtual double seq { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual int creator { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public virtual int modifier { get; set; }
        /// <summary>
        /// 单位负责人
        /// </summary>
        public virtual int head { get; set; }
        /// <summary>
        /// 包含组织/单位/个人的ID
        /// </summary>
        public virtual string c_head { get; set; }
    }
}
