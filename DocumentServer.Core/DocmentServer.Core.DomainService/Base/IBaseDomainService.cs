using System;
using System.Collections.Generic;
using System.Text;

namespace DocmentServer.Core.DomainService.Base
{
    public interface IBaseDomainService
    {
        DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; }
        /// <summary>
        /// 设置当前账号
        /// </summary>
        /// <param name="employee"></param>
        void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee employee);
    }
}
