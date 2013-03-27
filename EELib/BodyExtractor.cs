using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using EEModel;
namespace EEBiz
{
  
    /// <summary>
    /// 从邮件内容中提起 客户信息 和 产品信息
    /// </summary>
    public class BodyExtractor
    {
        private ExtractorResultObject resultObject;
        private string mailBody;
        public BodyExtractor(ExtractorResultObject o, string mailBody, enumPlatFrom platform)
            : base()
        {
            mailBody=Regex.Replace(Regex.Replace(mailBody, @"<[^>]*>", string.Empty),@"\s{3,}",string.Empty);//replace html tags and blank lines

            this.mailBody = mailBody;
            if (o == null)
                o = new ExtractorResultObject();
            resultObject = o;
            switch (platform)
            {
                case enumPlatFrom.Alibaba:
                    extractRule = new ExtractorRuleAli(mailBody);
                    break;
                case enumPlatFrom.MadeInChina:
                    extractRule = new ExtractorRuleMic(mailBody);
                    break;

            }

        }
        private ExtractorRule extractRule;
        public  void Extract()
        {
            //resultObject.CustomCountry = ExtractByRegex(regexCustomCountry);
            //resultObject.CustomEmail = ExtractByRegex(regexCustomEmail);
            //resultObject.CustomName = ExtractByRegex(regexCustomName);
           // resultObject.ProductName = ExtractByRegex(extractRule.regexProductName);
            resultObject.ProductName = extractRule.ExtractProductName();
            resultObject.CustomCountry = extractRule.ExtractCustomCountry();
            resultObject.CustomEmail = extractRule.ExtractCustomEmail();
            resultObject.CustomName = extractRule.ExtractCustomName();
        }
      
    }
}
