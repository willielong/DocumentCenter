namespace DocumentServer.Core.Model.Oupt
{
    public class TableEmployee
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public virtual int empid { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public virtual string cnname { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public virtual string enname { get; set; }
        /// <summary>
        /// 员工编码
        /// </summary>
        public virtual string empcode { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public virtual string phone { get; set; }
        /// <summary>
        /// 启用？
        /// </summary>
        public virtual bool enable { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public virtual int orgid { get; set; }
        /// <summary>
        /// 显示创建人
        /// </summary>
        public virtual string dic_creator { get; set; }
        /// <summary>
        /// 显示创建日期
        /// </summary>
        public virtual string dic_createdate { get; set; }

        public string dic_OrgName { get; set; }
    }
}
