using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    /// <summary>
    /// 配置文件实体
    /// </summary>
    public class OfficeConfig
    {
        /// <summary>
        /// 加载类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 文档类型
        /// </summary>
        public string documentType { get; set; }

        /// <summary>
        /// 文档配置类
        /// </summary>
        public DocumentConfig document { get; set; }

        /// <summary>
        /// 编辑文档的配置
        /// </summary>
        public EditorConfig editorConfig { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public string height { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public string width { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }
    }
    /// <summary>
    /// 文档配置类型
    /// </summary>
    public class DocumentConfig
    {
        /// <summary>
        /// 文件标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string fileType { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 作者信息
        /// </summary>
        public Author info { get; set; }
        /// <summary>
        /// 操作信息
        /// </summary>
        public PermissionsInfo permissions { get; set; }
    }

    public class Author
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string created { get; set; }
    }

    /// <summary>
    /// 操作信息
    /// </summary>
    public class PermissionsInfo
    {
        /// <summary>
        /// 是否可填写意见
        /// </summary>
        public bool comment { get; set; }
        /// <summary>
        /// 是否可下载
        /// </summary>
        public bool download { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool edit { get; set; }

        /// <summary>
        /// 文件来自表单
        /// </summary>
        public bool fillForms { get; set; }
        /// <summary>
        /// 编辑是否可以筛选
        /// </summary>
        public bool modifyFilter { get; set; }

        /// <summary>
        /// 修改内容的控件
        /// </summary>
        public bool modifyContentControl { get; set; }
        /// <summary>
        /// 是否进行预览
        /// </summary>
        public bool review { get; set; }
        /// <summary>
        /// 是否可以查看历史
        /// </summary>
        public bool changeHistory { get; set; }
    }

    /// <summary>
    /// 编辑文档的配置
    /// </summary>
    public class EditorConfig
    {
        /// <summary>
        /// 模型类型
        /// </summary>
        public string mode { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string lang { get; set; }
        /// <summary>
        /// 进行保存时的回传数据保存接口
        /// </summary>
        public string callbackUrl { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public User user { get; set; }

        /// <summary>
        /// 菜单栏
        /// </summary>
        public Embedded embedded { get; set; }

        /// <summary>
        /// 自定义配置类
        /// </summary>
        public CustomizationInfo customization { get; set; }
        /// <summary>
        /// 自定义logo
        /// </summary>
        public LogoInfo logo { get; set; }
    }
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
    }

    /// <summary>
    /// 菜单栏
    /// </summary>
    public class Embedded
    {
        /// <summary>
        /// 保存的URL
        /// </summary>
        public string saveUrl { get; set; }
        /// <summary>
        /// 仅预览页面
        /// </summary>
        public string embedUrl { get; set; }
        /// <summary>
        /// 分享页面
        /// </summary>
        public string shareUrl { get; set; }
        /// <summary>
        /// 菜单栏位置
        /// </summary>
        public string toolbarDocked { get; set; }
    }
    /// <summary>
    /// 自定义配置类型
    /// </summary>
    public class CustomizationInfo
    {
        /// <summary>
        /// 开启聊天
        /// </summary>
        public bool chat { get; set; }

        /// <summary>
        /// 反馈意见
        /// </summary>
        public FeedBackInfo feedback { get; set; }
        /// <summary>
        /// 配置打开文件地址配置
        /// </summary>
        public GoBackInfo goback { get; set; }
        /// <summary>
        /// 是否显示帮助配置
        /// </summary>
        public bool help { get; set; }
        /// <summary>
        /// 是否显示关于
        /// </summary>
        public bool about { get; set; }

        /// <summary>
        /// 自定义关于信息
        /// </summary>
        public CustomerInfo customer { get; set; }
    }

    /// <summary>
    /// 反馈配置
    /// </summary>
    public class FeedBackInfo
    {
        /// <summary>
        /// 反馈页面地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 是否显示按钮
        /// </summary>
        public bool visible { get; set; }       
    }

    public class GoBackInfo
    {
        /// <summary>
        /// 是否是在当前页
        /// </summary>
        public bool blank { get; set; }
        /// <summary>
        /// 是否关闭请求
        /// </summary>
        public bool requestClose { get; set; }
        /// <summary>
        /// 打开文件的所在的页面
        /// </summary>
        public string url { get; set; }
    }

    /// <summary>
    /// Logo信息
    /// </summary>
    public class LogoInfo
    {
        /// <summary>
        /// 图像地址
        /// </summary>
        public string image { get; set; }
        public string imageEmbedded { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string url { get; set; }
    }
    /// <summary>
    /// 自定义关于信息
    /// </summary>
    public class CustomerInfo
    {
        /// <summary>
        /// 联系地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 相关信息描述
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// logo图标
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string mail { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string www { get; set; }
    }
}
