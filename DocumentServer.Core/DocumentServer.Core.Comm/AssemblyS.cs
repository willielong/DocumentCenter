
/****************************************************************************
* 类名：Assemblys
* 描述：将程序集添加到ICO中
* 创建人：Author
* 创建时间：2019.10.08 10:00
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述：添加反射及读写分离的数据库操作
* **************************************************************************
*/


using System.Collections.Generic;
using System.Xml.Serialization;

namespace DocumentServer.Core.Comm
{
    [XmlRoot("ASSEMBLYS")]
    public class Assemblys
    {
        public Assemblys() {
            childs = new List<string>();
        }
        /// public string root { get; set; }
        
        [XmlElement("CHILDS")]
        public List<string> childs { get; set; }
    }

    public class Assemblysinge
    {
        public string classLay { get; set; }
    }
}
