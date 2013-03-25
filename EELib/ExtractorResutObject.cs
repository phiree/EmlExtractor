using System;
using System.Collections.Generic;
using System.Text;

namespace EELib
{
    /// <summary>
    /// 提取内容的对象
    /// </summary>
    public class ExtractorResutObject
    {
        public enumPlatFrom PlatFrom { get; set; }
        /// <summary>
        /// 询谈时间
        /// </summary>
        public DateTime InquiryTime { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public string ClerkName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        public string CustomEmail { get; set; }
        public string CustomCountry { get; set; }
        public string CustomName { get; set; }
    }
    public enum enumPlatFrom
    {
        Alibaba,
        MadeInChina
    }
}
