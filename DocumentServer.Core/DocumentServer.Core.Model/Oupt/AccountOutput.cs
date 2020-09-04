using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class AccountOutput : DbModel.AccoutInfo
    {
        /// <summary>
        /// 创建人显示名
        /// </summary>
        public string dic_creator { get; set; }

        /// <summary>
        /// 修改人显示名
        /// </summary>
        public string dic_modifier { get; set; }
    }
}
