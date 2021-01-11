using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.BizService.FilesInfo
{
    public interface IBizFilesService
    { /// <summary>
      /// 添加文件信息
      /// </summary>
      /// </summary>
      /// <param name="model">文件版本信息实体</param>
      /// <returns></returns>
        IResponseMessage Add(Files model);
        /// <summary>
        /// 修改文件信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Update(Files model);

        /// <summary>
        /// 删除文件信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取文件信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取所有文件版本信息数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        string TrackFile(int fileid, string token);

        IResponseMessage Config(int editType, int systemType, int fileid);
    }
}
