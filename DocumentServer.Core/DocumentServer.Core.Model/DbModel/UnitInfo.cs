using Dapper.Contrib.Extensions;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("UnitInfo")]
    public class UnitInfo : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int unitid { get; set; }
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
        /// 单位编码
        /// </summary>
        public virtual string unitcode { get; set; }
        /// <summary>
        /// 单位负责人
        /// </summary>
        public virtual int head { get; set; }
        /// <summary>
        /// 包含组织/单位/个人的ID
        /// </summary>
        public virtual string c_head { get; set; }
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
