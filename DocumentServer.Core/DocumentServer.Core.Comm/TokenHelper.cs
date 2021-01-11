/****************************************************************************
* 类名：TokenHelper
* 描述：jwt token 处理类
* 创建人：Author
* 创建时间：2019.10.08 10:00
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述：
* **************************************************************************
*/


using System.Xml.Serialization;

namespace DocumentServer.Core.Comm
{
    [XmlRoot("TOKENHELPER")]
    public class TokenHelper
    {
        /// <summary>
        /// 私钥
        /// </summary>
        [XmlElement("TOKENSECRE_KEY")]
        public string TokenSecreKey { get; set; }

        /// <summary>
        /// 发行人
        /// </summary>
        [XmlElement("ISSUER")]
        public string Issuer { get; set; }

        /// <summary>
        /// 订阅者
        /// </summary>
        [XmlElement("AUDIENCE")]
        public string Audience { get; set; }


        /// <summary>
        /// 过期时间
        /// </summary>
        [XmlElement("EXPIRATION")]
        public string Expiration { get; set; }

        [XmlElement("AUTHENTICATE_SCHEME")]
        public string AuthenticateScheme { get; set; }

    }
}
