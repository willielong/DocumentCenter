using DocumentServer.Core.Comm;

namespace DocmentServer.Core.BizService.Tree
{
    public interface IBizTreeService
    {
        /// <summary>
        /// 获取树形结构
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IResponseMessage Trees(int type,int pid);
        /// <summary>
        /// 获取树形结构--组织结构
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IResponseMessage TreesOrg(int type, int pid);
    }
}
