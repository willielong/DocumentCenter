﻿using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.BizService.Personal
{
    public interface IBizAccountService
    {
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Add(AccoutInfo model);
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Update(AccoutInfo model);

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage GetListByCode(string code);
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 获取账号信息--根据EmpId
        /// </summary>
        /// </summary>
        /// <param name="empid">员工基本信息ID</param>
        /// <returns></returns>
        IResponseMessage QueryByEmpId(int empid);
    }
}
