using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace EELib
{
  
    /// <summary>
    /// 从邮件内容中提起 客户信息 和 产品信息
    /// </summary>
    public class BodyExtractor
    {
        private ExtractorResutObject resultObject;
        private string mailBody;
        public BodyExtractor(ExtractorResutObject o, string mailBody, enumPlatFrom platform)
            : base()
        {
            this.mailBody = mailBody;
            if (o == null)
                o = new ExtractorResutObject();
            resultObject = o;
            switch (platform)
            {
                case enumPlatFrom.Alibaba: break;
                case enumPlatFrom.MadeInChina: break;

            }

        }
        private string regexProductName;
        private string regexCustomName;
        private string regexCustomCountry;
        private string regexCustomEmail;
        public  void Extract()
        {
            resultObject.CustomCountry = ExtractByRegex(regexCustomCountry);
            resultObject.CustomEmail = ExtractByRegex(regexCustomEmail);
            resultObject.CustomName = ExtractByRegex(regexCustomName);
            resultObject.ProductName = ExtractByRegex(regexProductName);
        }
        private string ExtractByRegex(string regex)
        {
            string result = string.Empty;
            Match match = Regex.Match(mailBody, regex, RegexOptions.IgnoreCase);
            if (match.Success) { result = match.Value; }
            else
            {
                Console.WriteLine("Not Match:" + regex);
            }
            return result;
        }
    }
}
