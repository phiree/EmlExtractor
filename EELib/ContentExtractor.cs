using System;
using System.Collections.Generic;
using System.Text;
using EEModel;
using EEPersistant;
using System.Text.RegularExpressions;
namespace EEBiz
{
    /// <summary>
    /// 提取需要的内容.
    /// </summary>
    public class ContentExtractor
    {
      
        public ExtractorResultObject ResultObject { get { return resultObject; } }
        private string emlFilePath;
        private ExtractorResultObject resultObject;
        public ContentExtractor()
        { }
        
        public ContentExtractor(string emlPath)
        {
            resultObject = new ExtractorResultObject();
            emlFilePath = emlPath;
        }
        /// <summary>
        /// parse邮件结构,获取相关信息
        /// </summary>
        public void ExtractInfo()
        {
            IEmlParser parser = new CDOParser();

            EEEmailMessage emlMsg = parser.Parse(emlFilePath);
            resultObject.InquiryTime = emlMsg.ReceivedTime;
            resultObject.EmailFileName = System.IO.Path.GetFileName(emlFilePath);
            resultObject.EmailTitle = emlMsg.Subject;
            string emailRegex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match firstMatch = Regex.Match(emlMsg.To, emailRegex);

            resultObject.ClerkName = firstMatch.Value.Replace("@ntsmart.com",string.Empty);//取第一个邮箱
            enumPlatFrom platfrom = enumPlatFrom.MadeInChina;
            if (emlMsg.From.ToLower().Contains("alibaba"))
            {
                platfrom = enumPlatFrom.Alibaba;
            }
            resultObject.PlatFrom = platfrom;
            resultObject.CreationTime = DateTime.Now;
            
            new BodyExtractor(resultObject, emlMsg.Body, platfrom).Extract();
            //EELog.EELogger.Debug("开始保存");
           
        }
       

       
    }

}
