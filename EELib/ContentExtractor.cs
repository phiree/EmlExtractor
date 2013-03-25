using System;
using System.Collections.Generic;
using System.Text;

namespace EELib
{
    /// <summary>
    /// 提取需要的内容.
    /// </summary>
    public class ContentExtractor
    {
       
        public ExtractorResutObject ResultObject { get { return resultObject; } }
        private string emlFilePath;
        private ExtractorResutObject resultObject;
        public ContentExtractor(string emlPath)
        {
            resultObject = new ExtractorResutObject();
            emlFilePath = emlPath;
        }
        /// <summary>
        /// parse邮件结构,获取相关信息
        /// </summary>
        public void ExtractInfo()
        {
            CDO.Message emlMsg = EmlParser.Parse(emlFilePath);
            resultObject.InquiryTime = emlMsg.ReceivedTime;
            
            resultObject.ClerkName = emlMsg.To.Split(',')[0];//取第一个邮箱
            enumPlatFrom plateform = enumPlatFrom.MadeInChina;
            if (emlMsg.From.ToLower().Contains("alibaba"))
            {
                plateform = enumPlatFrom.Alibaba;
            }
            resultObject.PlatFrom = plateform;
            new BodyExtractor(resultObject, emlMsg.HTMLBody, plateform).Extract();
        }
       
    }

}
