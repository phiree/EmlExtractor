using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EEBiz;
namespace EETest
{
    [TestFixture]
   public class ExtractServiceTest
    {
        [Test]
        public void ExtractFromFolderTest()
        {
            new EESetUp().SetUp();
            string path = @"E:\workspace\code\resources\emailexportfortest\";
            new EEBiz.ExtractService().ExtractFromFolder(path);

        }
        [Test]
        public void GetListTest()
        {
            DateTime begin=DateTime.Parse("2013-03-19 11:56:00");
            DateTime end=DateTime.Parse("2013-03-19 12:13:00");
           IList<EEModel.ExtractorResultObject> result= new EEBiz.ExtractService().GetList(begin, end);
           Assert.AreEqual(6, result.Count);

        }
    }
}
