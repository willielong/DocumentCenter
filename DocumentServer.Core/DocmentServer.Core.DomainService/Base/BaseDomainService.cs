using DocmentServer.Core.Business.Base;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Base
{
    public class BaseDomainService : IBaseDomainService
    {
        IBaseBusiness business;
        public DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; }
        public BaseDomainService(IBaseBusiness _business)
        {
            business = _business;
        }
        /// <summary>
        /// 设置当前用户信息
        /// </summary>
        /// <param name="employee"></param>
        public void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee CurrentUser)
        {
            this.CurrentUser = CurrentUser;
            business.SettingCurrentEmp(CurrentUser);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public long Add<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return business.Add<T>(model: model, transaction: transaction);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return business.Update<T>(model: model, transaction: transaction);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return business.Delete<T>(model: model, transaction: transaction);
        }

        /// <summary>
        /// 按住键获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public T Get<T>(object id, IDbTransaction transaction = null) where T : class, new()
        {
            return business.Get<T>(id: id, transaction: transaction);
        }

        public List<T> All<T>(IDbTransaction transaction = null) where T : class, new()
        {
            return business.All<T>(transaction: transaction);
        }
    }
}
