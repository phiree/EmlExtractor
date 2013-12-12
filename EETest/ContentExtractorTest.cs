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
            /*
             ---------------找不到对应的测试邮件了------------
           
            validateOneResult(@"E:\workspace\code\resources\7阿里有产品.eml",
        "vivi",
        "China (Mainland)",
        "nicci20121118@gmail.com",
        "Mr.  nicci  liu",
        DateTime.Parse("2013-03-25 11:24:05.000"),
        enumPlatFrom.Alibaba,
        "Cafe Black Durable Porcelain Cup Saucer");

            validateOneResult(@"E:\workspace\code\resources\7阿里没产品.eml",
          "alibaba",
          "United Kingdom",
          "apex_trade@yahoo.co.uk",
          "Ms.  Audrey  Sinclair",
          DateTime.Parse("2013-03-23 21:12:58.000"),
          enumPlatFrom.Alibaba,
          string.Empty);

            validateOneResult(@"E:\workspace\code\resources\中国制造有产品.eml",
          "vanco",
          "United States",
          "nklansek@me.com",
          "Mr. Niko Klansek",
          DateTime.Parse("2013-03-18 21:21:53.000"),
          enumPlatFrom.MadeInChina,
         "Cotton Hotel Bath Towel Set (N000020820/N000020821)");
              
             * */
            //            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\Notification_ Business Message from Mr. Mathew Oluwasegun Adeniyi.eml",
//"vanco",
//"Nigeria",
//"semadexcom@yahoo.com",
//"Mr. Mathew Oluwasegun Adeniyi",
//DateTime.Parse("2013-03-13 10:38:03.000"),
//enumPlatFrom.MadeInChina,
//"Cotton Hotel Bath Towel Set (N000020820/N000020821)");
            /*
             InquiryProduct 后面没有 %#%
             */
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\Notification_ Business Message from Mr. Amer Shahzad.eml",
"vanco",
"Pakistan",
"mespinner93@gmail.com",
"Mr. Amer Shahzad",
DateTime.Parse("2013-03-24 12:09:03.000"),
enumPlatFrom.MadeInChina,
"Cotton Hotel Bath Towel Set (N000020820/N000020821)");


            /*made in china  产品名称前是 offer 或者 product*/

            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\Notification_ Business Message from Miss Sofia.eml",
"vivi",
"Singapore",
"sofia_yusof@hotmail.com",
"Miss Sofia",
DateTime.Parse("2013-03-22 13:54:58.000"),
enumPlatFrom.MadeInChina,
"Chocolate Fountain (CP-60)");

        
            /*
            产品名称之后 没有跟着回车
             */
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[dg4@dg4.com.br]What is the MOQ.eml",
         "vincent",
         "Brazil",
         "dg4@dg4.com.br",
         "Mr.  Leonardo  Barbosa",
         DateTime.Parse("2013-03-21 09:07:03"),
         enumPlatFrom.Alibaba,
        "Synthetic rattan home furniture");

            /*产品名称里面包含数字1*/
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[9166853@qq.com]pls quote best price for the hotel safe.eml",
        "vanco",
        "China (Mainland)",
        "9166853@qq.com",
        "Mr.  Daniel  Liu",
        DateTime.Parse("2013-03-23 13:09:04"),
        enumPlatFrom.Alibaba,
       "2012 new mechanical cheap hotel safe");

            /*客户邮件地址后面有[Unverified Email]*/
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[manager assigned] [hossenoomur@hotmail.com]Inquiry about Guangzhou Nantian Sources Co., Ltd..eml",
        "vanco",
        "Mauritius",
        "hossenoomur@hotmail.com",
        "Mr.  Mohammad hossen  OOMUR",
        DateTime.Parse("2013-03-18 15:12:35.000"),
        enumPlatFrom.Alibaba,
       "");

            /*kalina 2013-12-10 alibaba改版 客户名片栏目 view detail 改为 view more-->.*/
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[san@upowercorp.com]ask for quote.eml",
                   "service",
                   "Hong Kong",
                   "san@upowercorp.com",
                   "Ms.  San  Koo",
                   DateTime.Parse("2013-12-02 12:35:54"),
                   enumPlatFrom.Alibaba,
                  "(Likely) a TROUSER HANGER &amp; JACKET HANGER for export to ");
            //没有获取到产品信息
            validateOneResult(AppDomain.CurrentDomain.BaseDirectory + @"\TestResource\[jamesyeunghh_lfsourcing@hotmail.com]Inquiry about Guangzhou Nantian Sources Co., Ltd..eml",
                 "service",
                 "Hong Kong",
                 "san@upowercorp.com",
                 "Ms.  San  Koo",
                 DateTime.Parse("2013-12-02 12:35:54"),
                 enumPlatFrom.Alibaba,
                "(Likely) a TROUSER HANGER &amp; JACKET HANGER for export to ");


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
