using System;
using System.Collections.Generic;
using System.Text;
using log4net;
namespace EEBiz
{
    public class EELog
    {
        public static readonly ILog EELogger = LogManager.GetLogger("EELogger");
    }
}
