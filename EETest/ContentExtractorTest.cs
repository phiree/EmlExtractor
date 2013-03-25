using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EELib;
namespace EETest
{
    [TestFixture]
    public class ContentExtractorTest
    {
        [Test]
        public void ExtractorInfoTest()
        {
            
            validateOneResult(@"E:\workspace\code\resources\7阿里有产品.eml",
            "\"vivi@ntsmart.com\" <vivi@ntsmart.com>",
            "China (Mainland)",
            "nicci20121118@gmail.com",
            "Mr.  nicci  liu",
            DateTime.Parse("2013-03-25 11:24:05.000"),
            enumPlatFrom.Alibaba,
            "Cafe Black Durable Porcelain Cup SaucerCafe Black Durable Porcelain Cup Saucer\r");

            validateOneResult(@"E:\workspace\code\resources\7阿里没产品.eml",
          "\"alibaba@ntsmart.com\" <alibaba@ntsmart.com>",
          "United Kingdom",
          "apex_trade@yahoo.co.uk",
          "Ms.  Audrey  Sinclair",
          DateTime.Parse("2013-03-23 21:12:58.000"),
          enumPlatFrom.Alibaba,
          string.Empty);

            validateOneResult(@"E:\workspace\code\resources\中国制造有产品.eml",
          "\"vanco@ntsmart.com\" <vanco@ntsmart.com>",
          "United States",
          "nklansek@me.com",
          "Mr. Niko Klansek",
          DateTime.Parse("2013-03-18 21:21:53.000"),
          enumPlatFrom.MadeInChina,
         "Cotton Hotel Bath Towel Set (N000020820/N000020821)");

        }

        private void validateOneResult(string emlFilePath,
            string clertname, string country, string email
            , string name, DateTime time, enumPlatFrom platform, string pname
           )
        {

            ContentExtractor ce = new ContentExtractor(emlFilePath);
            ce.ExtractInfo();
            ExtractorResutObject resultobject = ce.ResultObject;
            Assert.AreEqual(clertname, resultobject.ClerkName);
            Assert.AreEqual(country, resultobject.CustomCountry);
            Assert.AreEqual(email, resultobject.CustomEmail);
            Assert.AreEqual(name, resultobject.CustomName);
            Assert.AreEqual(time, resultobject.InquiryTime);
            Assert.AreEqual(platform, resultobject.PlatFrom);
            Assert.AreEqual(pname, resultobject.ProductName);
        }
    }
}
