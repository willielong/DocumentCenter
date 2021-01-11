/****************************************************************************
* 类名：DBHelper
* 描述：保存数据连接到配置文件
* 创建人：2019.10.08 10:00
* 创建时间：2018.05.04 
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述：添加反射及读写分离的数据库操作
* **************************************************************************
*/


using System.IO;
using System.Xml.Serialization;

namespace DocumentServer.Core.Comm
{
    [XmlRoot("DBHELPER")]
    public class DBHelper
    {
        /// <summary>
        /// 数据库写入配置-MSSQL
        /// </summary>
        [XmlElement("MS_WRITE_CONNECTION")]
        public string ms_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-MSSQL
        /// </summary>
        [XmlElement("MS_READ_CONNECTION")]
        public string ms_read_connection { get; set; }

        /// <summary>
        /// 数据库写入配置-MYSQL
        /// </summary>
        [XmlElement("MY_WRITE_CONNECTION")]
        public string my_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-MYSQL
        /// </summary>
        [XmlElement("MY_READ_CONNECTION")]
        public string my_read_connection { get; set; }

        /// <summary>
        /// 数据库写入配置-Oracle
        /// </summary>
        [XmlElement("OC_WRITE_CONNECTION")]
        public string oc_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-Oracle
        /// </summary>
        [XmlElement("OC_READ_CONNECTION")]
        public string oc_read_connection { get; set; }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static DBHelper GetDbBaseConnection()
        {
            DBHelper dbConnection = new DBHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "DBHelper.xml");
            dbConnection = con.ReadConfFile<DBHelper>(path, false);
            return dbConnection;
        }
    }
}
