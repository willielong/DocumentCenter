using DocumentServer.Core.Model.Oupt;
/*
 *描述：进行下载的BIZServices
 *添加日期：2020.10.27 13:50:00 * 
 */
namespace DocmentServer.Core.BizService.FilesInfo
{
    public interface IDownloadBizservice
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileid">文件ID</param>
        /// <returns></returns>
        DownloadModel DownloadFile(int fileid);
    }
}
