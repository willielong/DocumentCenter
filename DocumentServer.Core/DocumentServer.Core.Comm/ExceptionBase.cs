using System;

namespace DocumentServer.Core.Comm
{
    public static class ExceptionBase
    {
        /// <summary>
        /// 进行错误信息封装
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Exception ToErrMessage(this string message)
        {
            return new Exception(message);
        }
    }
}
