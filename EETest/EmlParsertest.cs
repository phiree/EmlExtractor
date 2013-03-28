using System;
using System.Collections.Generic;

using System.Text;
using NUnit.Framework;
using EEBiz;
using System.IO;
namespace EETest
{
    [TestFixture]
    public class EmlParsertest
    {
        [Test]
        public void CDOParseTest()
        {
           



            EEEmailMessage msgAliNoProduct =new CDOParser().Parse(@"E:\workspace\code\resources\7阿里没产品.eml");
            EEEmailMessage msgAliHasProduct = new CDOParser().Parse(@"E:\workspace\code\resources\7阿里有产品.eml");
            EEEmailMessage msgMicNoProduct = new CDOParser().Parse(@"E:\workspace\code\resources\中国制造没产品.eml");
            EEEmailMessage msgMicHasProduct = new CDOParser().Parse(@"E:\workspace\code\resources\中国制造有产品.eml");
          
            //
            //CommonLibrary.IOHelper.WriteContentToFile(@"E:\workspace\code\resources\7阿里没产品.html", msgAliNoProduct.HTMLBody);
            //CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\7阿里有产品.html",msgAliHasProduct.HTMLBody);
            //CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\中国制造没产品.html",msgMicNoProduct.HTMLBody);
            //CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\中国制造有产品.html",msgMicHasProduct.HTMLBody);

            Console.Write(msgAliNoProduct.Body+Environment.NewLine+"----------------------------------------"+Environment.NewLine);

            Console.Write(msgAliHasProduct.Body + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
            Console.Write(msgMicNoProduct.Body + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
            Console.Write(msgMicHasProduct.Body + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
        
            
            
        }
        [Test]
        public void SasaParserTest()
        {
          //  EEEmailMessage msgSasaParser1 = new Sasaparser().Parse(@"E:\workspace\code\resources\7阿里有产品.eml");

        }
        [Test]
        public void MIMERParserTest()
        {
           // EEEmailMessage msgSasaParser1 = new MIMECompliantParser().Parse(@"E:\workspace\code\resources\7阿里有产品.eml");

        }
    }
}
