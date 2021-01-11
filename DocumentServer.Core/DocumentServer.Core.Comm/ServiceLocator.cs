/****************************************************************************
* 类名：ServiceLocator
* 描述：手动获取DI中注入的对象
* 创建人：Author
* 创建时间：2019.10.08 10:00
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述：
* **************************************************************************
*/

namespace DocumentServer.Core.Comm
{
    public static class ServiceLocator
    {
        /// <summary>
        /// 日志仓储
        /// </summary>
       // public static ILoggerRepository log4netRepository { get; set; }

        /// <summary>
        /// 客户端的IP地址
        /// </summary>
        public static string Ip { get; set; }

        /// <summary>
        /// 当前访问的用户
        /// </summary>
        public static string currentUser { get; set; }

        public static TokenHelper tokenHelper { get; set; }

        public static string log4netRepositoryName { get; set; } = "NETCoreRepository";
    }
}
