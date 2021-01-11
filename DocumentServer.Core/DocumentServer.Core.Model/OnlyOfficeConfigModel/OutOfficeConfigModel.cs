using DocumetCenter.Core.Enum;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class OutOfficeConfigModel
    {
        /// <summary>
        /// 钥匙
        /// </summary>
        public string key { get; set; }
        public TrackerStatus status { get; set; }
        /// <summary>
        /// 版本信息压缩包
        /// </summary>
        public string changesurl { get; set; }

        /// <summary>
        /// 版本信息
        /// </summary>
        public ChangesModel history { get; set; }

        public string changeshistory { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string url { get; set; }
    }
}
