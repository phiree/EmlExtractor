using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace EEBiz
{
    public interface ExtractorRule
    {
        string ExtractProductName();
        string ExtractCustomName();
        string ExtractCustomCountry();
        string ExtractCustomEmail();
    }
    public class ExtractorRuleAli : ExtractorRule
    {
        private string content;
        public ExtractorRuleAli(string content)
        {
            this.content = content;
        }

        public  string ExtractProductName()
        {

            string regex = @"(?<=I'm interested in your product\(s\)).+?(?=%#%)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;
        }


        public  string ExtractCustomName()
        {
            string regex = @"(?<=View detail).+(?=Company:)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;
        }

        public  string ExtractCustomCountry()
        {
            string regex = @"(?<=Country/Region:).+?(?=Address:)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;
        }

        public  string ExtractCustomEmail()
        {
            string regex = @"(?<=Email:)\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(?=\s*?(.+\[Unverified Email\])?TEL:)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }

            return m.Groups[0].Value;

        }
    }

    public class ExtractorRuleMic : ExtractorRule
    {
        private string content;
        public ExtractorRuleMic(string content)
        {
            this.content = content;
        }

        public string ExtractProductName()
        {

            string regex = @"(?<=Inquired\s+(Product|Offer)(%#%)?).+(?=Message Basics)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value.Replace("%#%",string.Empty) ;
        }


        public string ExtractCustomName()
        {
            string regex = @"(?<=Sender)[^'].+?(?=Company)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;
        }

        public string ExtractCustomCountry()
        {
            string regex = @"(?<=Country/Region).+?(?=(Sender's IP|Homepage))";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;
        }

        public string ExtractCustomEmail()
        {
            string regex = @"(?<=Email)\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(?=\(NOTE:)";
            Match m = Regex.Match(content, regex, RegexOptions.Singleline);
            if (!m.Success) { return string.Empty; }
            return m.Value;

        }
    }
}
