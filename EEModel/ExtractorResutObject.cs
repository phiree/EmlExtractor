using System;
using System.Collections.Generic;
using System.Text;

namespace EEModel
{
    /// <summary>
    /// 提取内容的对象
    /// </summary>
    public class ExtractorResultObject
    {
        //对应邮件的标题
        public string EmailTitle { get; set; }
        //该记录内容的hashcode,用于判断记录是否已经导入.
     //   public int ItemHashcode { get; set; }
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
        /// <summary>
        /// 记录创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 根据内容确定唯一性.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (InquiryTime + ClerkName
                + ProductName + CustomCountry
                + CustomEmail + CustomName).GetHashCode();
        }
    }
    public enum enumPlatFrom
    {
        Alibaba=0,
        MadeInChina
    }
}
