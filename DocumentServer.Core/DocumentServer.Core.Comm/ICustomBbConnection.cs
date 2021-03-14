using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public interface ICustomDbConnection
    {
        IDbConnection dbConnection { get; set; }
    }
}
