using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
namespace EEBiz
{
    public class EEEmailMessage
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public DateTime ReceivedTime { get; set; }
        
    }
    //邮件解析
    public interface IEmlParser
    {
        EEEmailMessage Parse(string emlFileName);
    }
    public class CDOParser:IEmlParser
    {

        public EEEmailMessage Parse(string emlFileName)
        {
            EEEmailMessage eeemsg = new EEEmailMessage();
            //throw new NotImplementedException();
            /*    EMLReaer
            FileStream fs = File.Open(emlFileName, FileMode.Open, FileAccess.ReadWrite);
            EMLReader reader = new EMLReader(fs);

          
            eeemsg.Body = reader.Body;
            eeemsg.From = reader.From;
            eeemsg.ReceivedTime = reader.Date;
            eeemsg.Subject = reader.Subject;
            eeemsg.To = reader.To;
            return eeemsg;*/

            /*
            EAGetMail.Mail eamail = new EAGetMail.Mail("TryIt");
            eamail.Load(emlFileName, true);
            eeemsg.Body = eamail.HtmlBody;
            eeemsg.From = eamail.From.Address;
            eeemsg.ReceivedTime = eamail.ReceivedDate;
            eeemsg.Subject = eamail.Subject;
            eeemsg.To = eamail.To[0].Address;
            // reader.Date
            */
            CDO.Message cdomsg = new CDO.MessageClass();
            ADODB.Stream stream = new ADODB.StreamClass();

            stream.Open(Type.Missing, ADODB.ConnectModeEnum.adModeUnknown,
                ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified,
                String.Empty, String.Empty);
            stream.LoadFromFile(emlFileName);
            stream.Flush();
            cdomsg.DataSource.OpenObject(stream, "_Stream");
            cdomsg.DataSource.Save();
            stream.Close();

            eeemsg.Body = cdomsg.HTMLBody;
            eeemsg.Subject = cdomsg.Subject;
            eeemsg.From = cdomsg.From;
            eeemsg.ReceivedTime = cdomsg.ReceivedTime;
            eeemsg.To = cdomsg.To;

            return eeemsg;
        }

    }
    /*
    public class Sasaparser : IEmlParser
    {
        public List<string> HeadersToPrint = new List<string>();

        public EEEmailMessage Parse(string emlFileName)
        {
            var mail = Sasa.Net.Mail.Message.ParseMailMessage(File.ReadAllText(emlFileName));

            Console.WriteLine("SUBJECT:\t{0}", mail.Subject);
            Console.WriteLine("FROM:\t{0}", mail.From);

            foreach (var to in mail.To)
            {
                Console.WriteLine("TO:\t{0}", to);
            }

            var headersPresent = mail.Headers.Keys.OfType<string>().Select(s => s.ToLower());

            foreach (var header in HeadersToPrint)
            {
                if (headersPresent.Contains(header.ToLower()))
                {
                    Console.WriteLine("{0}:\t{1}", header.ToUpper(), mail.Headers[header]);
                }
            }

            Console.WriteLine("BODY:");
            Console.WriteLine(mail.Body);
            return new EEEmailMessage();
        }
    }

    public class MIMECompliantParser : IEmlParser
    {

        public EEEmailMessage Parse(string emlFileName)
        {
            MIMER.IMailReader reader=new MIMER.RFC2045.MailReader();

            Stream emlFileStream= new FileStream(emlFileName, FileMode.Open);
           MIMER.IMailMessage msg= reader.Read(ref emlFileStream, (MIMER.IEndCriteriaStrategy)new MyEndStratege());

           return new EEEmailMessage();
        }
    }
    public class MyEndStratege : MIMER.IEndCriteriaStrategy
    {

        public bool IsEndReached(char[] data, int size)
        {
            return true;
        }
    }
     * 
     * */
}
