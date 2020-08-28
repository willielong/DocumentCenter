
/*
 * 目的：返回请求结果
 * 创建人：Author
 * 创建时间：2019.10.08 10:00
 * 修改人;
 * 修改目的：
 * 修改时间
 * 修改结果：
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public interface IResponseMessage
    {
        bool Status { get; set; }
        string Code { get; set; }
        string Message { get; set; }
        object Body { get; set; }
    }

}
