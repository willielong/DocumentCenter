using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.BizService.Folder
{
    public interface IBizFolderService
    {
        /// <summary>
        /// 添加文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage Add(FileFloder model);
        /// <summary>
        /// 修改文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage Update(FileFloder model);

        /// <summary>
        /// 删除文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取所有文件夹数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();

        /// <summary>
        /// 获取文件夹信息--多个-- 按组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        IResponseMessage GetFoldersByOrgId(int orgId, int type);
        /// <summary>
        /// 获取文件列表-按组织-按上级Id
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="type"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        IResponseMessage GetFolders(int orgId, int type, int pid);
    }
}
