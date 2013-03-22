using System;
using System.Collections.Generic;

using System.Text;
using NUnit.Framework;
using EELib;
namespace EETest
{
    [TestFixture]
    public class base64decodertest
    {
        [Test]
        public void ParseTest()
        {
            CDO.Message msg = EmlParser.Parse(@"E:\workspace\code\resources\w.eml");

            Console.Write(msg.TextBody);
            
            
        }
    }
}
