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
        private ExtractorResutObject resultObject;
        public string emlFilePath { get; set; }
        public ContentExtractor(string emlPath)
        {
            resultObject = new ExtractorResutObject();
            emlFilePath = emlPath;
        }
        /// <summary>
        /// parse邮件结构,获取相关信息
        /// </summary>
        private void ExtractInfo()
        {
            CDO.Message emlMsg = EmlParser.Parse(emlFilePath);
            resultObject.InquiryTime = emlMsg.ReceivedTime;
            resultObject.ClerkName = emlMsg.To;
            enumPlatFrom plateform = enumPlatFrom.MadeInChina;
            if (emlMsg.From.ToLower().Contains("alibaba"))
            {
                plateform = enumPlatFrom.Alibaba;
            }
            new BodyExtractor(resultObject, emlMsg.TextBody, plateform).Extract();
           // bodyExtractor.ExtractInfo(emlMsg.TextBody, resultObject,enumPlatform);
            
        }
       
    }

}
