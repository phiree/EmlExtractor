using System;
using System.Collections.Generic;
using System.Text;

namespace EELib
{
    public class EmlParser
    {
        public static CDO.Message Parse(string emlFileName)
        {
            CDO.Message msg = new CDO.MessageClass();
            ADODB.Stream stream = new ADODB.StreamClass();

            stream.Open(Type.Missing, ADODB.ConnectModeEnum.adModeUnknown, ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified, String.Empty, String.Empty);
            stream.LoadFromFile(emlFileName);
            stream.Flush();
            msg.DataSource.OpenObject(stream, "_Stream");
            msg.DataSource.Save();

            stream.Close();
            return msg;
        }
    }
}
