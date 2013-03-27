using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace EETest
{
    
   public class EESetUp
    {
        [SetUp]
        public void SetUp()
        {
            System.IO.FileInfo finfo = new System.IO.FileInfo(Environment.CurrentDirectory + "\\config\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(finfo);
        }
    }
}
