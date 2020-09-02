using System;
using System.Collections.Generic;
using System.Text;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.DomainService.Base
{
    public class BaseDomainService: IBaseDomainService
    {
        IBaseBusiness business;
        public BaseDomainService(IBaseBusiness _business)
        {
            business = _business;
        }

        public DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; } = new DocumentServer.Core.Model.DbModel.Employee();
        /// <summary>
        /// 设置当前用户信息
        /// </summary>
        /// <param name="employee"></param>
        public void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee CurrentUser)
        {
            business.SettingCurrentEmp(CurrentUser);
        }
    }
}
