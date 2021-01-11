using System.IO;
using System.Xml.Serialization;

namespace DocumentServer.Core.Comm
{
    [XmlRoot("ONLYOFFICECONFIG")]
    public class OnlyOfficeConfig
    {
        [XmlElement("VERSION")]
        /// <summary>
        /// 版本
        /// </summary>
        public string version { get; set; }
        [XmlElement("ENABLED")]
        /// <summary>
        /// 启用
        /// </summary>
        public bool enabled { get; set; }
        /// <summary>
        /// 预览时启用
        /// </summary>
        [XmlElement("PRESERVELOGINURL")]
        public bool preserveLoginUrl { get; set; }
        /// <summary>
        /// 请求时验证
        /// </summary>
        [XmlElement("CLIENTVALIDATIONENABLED")]
        public bool clientValidationEnabled { get; set; }
        /// <summary>
        /// 启用脚本
        /// </summary>
        [XmlElement("UNOBTRUSIVEJAVASCRIPTENABLED")]
        public bool unobtrusiveJavaScriptEnabled { get; set; }

        /// <summary>
        /// 最大文件大小
        /// </summary>
        [XmlElement("SIZEMAX")]
        public int sizeMax { get; set; }
        /// <summary>
        /// 预览时扩展名
        /// </summary>
        [XmlElement("VIEWED")]
        public string viewed { get; set; }
        /// <summary>
        /// 编辑时扩展名
        /// </summary>
        [XmlElement("EDITED")]
        public string edited { get; set; }
        /// <summary>
        /// 转换时扩展名
        /// </summary>
        [XmlElement("CONVERT")]
        public string convert { get; set;}
        /// <summary>
        /// 过期时间
        /// </summary>
        [XmlElement("TIMEOUT")]
        public int timeout { get; set;}

        [XmlElement("SECRET")]
        public string secret { get; set; }

        /// <summary>
        /// 转换地址
        /// </summary>
        [XmlElement("CONVERTERURL")]
        public string converterUrl { get; set;}
        /// <summary>
        /// js地址
        /// </summary>
        [XmlElement("APIURL")]
        public string apiUrl { get; set; }
        /// <summary>
        /// 嵌入地址
        /// </summary>
        [XmlElement("PRELOADERURL")]
        public string preloaderUrl { get; set; }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static OnlyOfficeConfig GetOnlyOfficeConfig()
        {
            OnlyOfficeConfig config = new OnlyOfficeConfig();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "OnlyOffice.xml");
            config = con.ReadConfFile<OnlyOfficeConfig>(path, false);
            return config;
        }
    }
}
