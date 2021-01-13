using DocumentServer.Core.Model.DbModel;

namespace DocumentServer.Core.Model.Oupt
{
    public class EmployeeOutput : Employee
    {
        /// <summary>
        /// 创建人显示名
        /// </summary>
        public string dic_creator { get; set; }

        /// <summary>
        /// 修改人显示名
        /// </summary>
        public string dic_modifier { get; set; }
        /// <summary>
        /// 创建日期-显示
        /// </summary>
        public string dic_creatdate { get; set; }
        /// <summary>
        /// 修改日期-显示
        /// </summary>
        public string dic_modifdate { get; set; }
    }
}
