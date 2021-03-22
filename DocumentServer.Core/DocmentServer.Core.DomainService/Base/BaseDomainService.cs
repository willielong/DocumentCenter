
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Infrastrure;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Base
{
    public class BaseDomainService : IBaseDomainService
    {
        /// <summary>
        /// 数据业务访问层调用
        /// </summary>
        public IBaseBusiness baseBusiness { get; set; }
        /// <summary>
        /// 当前会话的信息中的当前用户
        /// </summary>
        internal DocumentServer.Core.Model.DbModel.Employee CurrentUser { get => baseBusiness.CurrentUser; }

        public BaseDomainService()
        {
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
            return baseBusiness.Add<T>(model: model, transaction: transaction);
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
            return baseBusiness.Update<T>(model: model, transaction: transaction);
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
            return baseBusiness.Delete<T>(model: model, transaction: transaction);
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
            return baseBusiness.Get<T>(id: id, transaction: transaction);
        }

        public List<T> All<T>(IDbTransaction transaction = null) where T : class, new()
        {
            return baseBusiness.All<T>(transaction: transaction);
        }
    }
}
