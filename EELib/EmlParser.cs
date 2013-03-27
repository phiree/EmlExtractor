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
            throw new NotImplementedException();
            //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //CDO.Message msg = new CDO.MessageClass();
            //ADODB.Stream stream = new ADODB.StreamClass();

            //stream.Open(Type.Missing, ADODB.ConnectModeEnum.adModeUnknown, 
            //    ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified, 
            //    String.Empty, String.Empty);
            //stream.LoadFromFile(emlFileName);
            //stream.Flush();
            //msg.DataSource.OpenObject(stream, "_Stream");
            //msg.DataSource.Save();
            //stream.Close();
            //EEEmailMessage em = new EEEmailMessage();
            //em.Body = msg.HTMLBody;
            //em.Subject = msg.Subject;
            //em.From = msg.From;
            //em.ReceivedTime = msg.ReceivedTime;
            //em.To = msg.To;
            
            //return em;
        }

    }
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
}
