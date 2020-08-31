using System;
using System.Collections.Generic;
using System.Text;
/* * 
 * *目的：不用每个类去写创建人和修改人 
 * */
namespace DocumentServer.Core.Model.DbModel
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual int creator { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public virtual int modifier { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime creatdate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public virtual DateTime modifdate { get; set; }
    }
}
