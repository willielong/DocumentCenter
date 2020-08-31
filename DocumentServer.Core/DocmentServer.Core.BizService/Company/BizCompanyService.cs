using DocmentServer.Core.DomainService.Company;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Company
{
    public class BizCompanyService : IBizCompanyService
    {
        private ICompanyDomainService service;
        private IDbConnection dbConnection;

        public BizCompanyService(ICompanyDomainService service, IDbConnection dbConnection)
        {
            this.service = service;
            this.dbConnection = dbConnection;
        }
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public long Add(UnitInfo model)
        {
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            long id = service.Add(model: model, transaction: transaction);
            transaction.Commit();
            return id;
        }
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Update(UnitInfo model)
        {
            return service.Update(model: model);
        }

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Delete(object id)
        {
            return service.Delete(id: id);
        }

        /// <summary>
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public UnitInfo Get(object id)
        {
            return service.Get(id: id);
        }
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> List(object id)
        {
            return service.List(id: id);
        }
        /// <summary>
        /// 获取单位信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> GetListByCode(string code)
        {
            return service.GetListByCode(code: code);
        }
    }
}
