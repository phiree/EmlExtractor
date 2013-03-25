using System;
using System.Collections.Generic;

using System.Text;
using NUnit.Framework;
using EELib;
using System.IO;
namespace EETest
{
    [TestFixture]
    public class EmlParsertest
    {
        [Test]
        public void ParseTest()
        {
            CDO.Message msgAliNoProduct = EmlParser.Parse(@"E:\workspace\code\resources\7阿里没产品.eml");
            CDO.Message msgAliHasProduct = EmlParser.Parse(@"E:\workspace\code\resources\7阿里有产品.eml");
            CDO.Message msgMicNoProduct = EmlParser.Parse(@"E:\workspace\code\resources\中国制造没产品.eml");
            CDO.Message msgMicHasProduct = EmlParser.Parse(@"E:\workspace\code\resources\中国制造有产品.eml");
          
            //
            CommonLibrary.IOHelper.WriteContentToFile(@"E:\workspace\code\resources\7阿里没产品.html", msgAliNoProduct.HTMLBody);
            CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\7阿里有产品.html",msgAliHasProduct.HTMLBody);
            CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\中国制造没产品.html",msgMicNoProduct.HTMLBody);
            CommonLibrary.IOHelper.WriteContentToFile( @"E:\workspace\code\resources\中国制造有产品.html",msgMicHasProduct.HTMLBody);

            Console.Write(msgAliNoProduct.HTMLBody+Environment.NewLine+"----------------------------------------"+Environment.NewLine);
            
            Console.Write(msgAliHasProduct.HTMLBody + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
            Console.Write(msgMicNoProduct.HTMLBody + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
            Console.Write(msgMicHasProduct.HTMLBody + Environment.NewLine + "----------------------------------------" + Environment.NewLine);
        
            
            
        }
    }
}
