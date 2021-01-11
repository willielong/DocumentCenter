using DocumentServer.Core.Comm;

namespace DocmentServer.Core.BizService.Employee
{
    public interface IBizEmployeeService
    {
        /// <summary>
        /// 添加人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage Add(DocumentServer.Core.Model.DbModel.Employee model);
        /// <summary>
        /// 修改人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage Update(DocumentServer.Core.Model.DbModel.Employee model);

        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        IResponseMessage GetListByCode(string code);
        /// <summary>
        /// 获取所有人员基本信息数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 根据部门ID获取人员信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        IResponseMessage TablePersonal(int pid);
    }
}
