using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.Input;

namespace DocmentServer.Core.BizService.Login
{
    public interface IBizLoginService
    {
        /// <summary>
        /// 进行登录
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        IResponseMessage LogIn(LoginModel User);
    }
}
