using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EEBiz;
using EEModel;
using log4net;
namespace EETest
{
    /// <summary>
    /// yan
    /// </summary>
    [TestFixture]
    public class ContentExtractorTest
    {
       
        [Test]
        public void ExtractorInfoTest()
        {
            new EESetUp().SetUp();
            
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
            /*
            产品名称之后 没有跟着回车
             */
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[dg4@dg4.com.br]What is the MOQ.eml",
         "\"vincent@ntsmart.com\" <vincent@ntsmart.com>",
         "Brazil",
         "dg4@dg4.com.br",
         "Mr.  Leonardo  Barbosa",
         DateTime.Parse("2013-03-21 09:07:03"),
         enumPlatFrom.Alibaba,
        "Synthetic rattan home furnitureRattan home furniture");

            /*产品名称里面包含数字1*/
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[9166853@qq.com]pls quote best price for the hotel safe.eml",
        "\"vanco@ntsmart.com\" <vanco@ntsmart.com>",
        "China (Mainland)",
        "9166853@qq.com",
        "Mr.  Daniel  Liu",
        DateTime.Parse("2013-03-23 13:09:04"),
        enumPlatFrom.Alibaba,
       "2012 new mechanical cheap hotel safe hotel safe");


           new ExtractService().SaveResultList(resultList);
        }

        private void validateOneResult(string emlFilePath,
            string clertname, string country, string email
            , string name, DateTime time, enumPlatFrom platform, string pname
           )
        {

            ContentExtractor ce = new ContentExtractor(emlFilePath);
            ce.ExtractInfo();
            ExtractorResultObject resultobject = ce.ResultObject;

            Assert.AreEqual(clertname, resultobject.ClerkName);
            Assert.AreEqual(country, resultobject.CustomCountry);
            Assert.AreEqual(email, resultobject.CustomEmail);
            Assert.AreEqual(name, resultobject.CustomName);
            Assert.AreEqual(time, resultobject.InquiryTime);
            Assert.AreEqual(platform, resultobject.PlatFrom);
            Assert.AreEqual(pname, resultobject.ProductName);
            resultList.Add(resultobject);
        } 
        IList<ExtractorResultObject> resultList = new List<ExtractorResultObject>();
      
    }
}
