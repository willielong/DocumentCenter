using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public class CustomDbConnection : ICustomDbConnection
    {
        public CustomDbConnection(IHttpContextAccessor httpContext)
        {
            if (dbConnection == null)
                dbConnection = new MySqlConnection("Database=DocumentServerDb;Data Source=127.0.0.1;User Id=root;Password=123456Aa;CharSet=utf8;port=3306");
        }
        public IDbConnection dbConnection { get; set; }
    }
}
