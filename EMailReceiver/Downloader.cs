using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;
using System.Net.Mail;
namespace EMailReceiver
{
    //save receivedmail to filesystem
  public  class Downloader
    {
      public void DownLoad()
      { 
        
      }
      private void InitMailServer()
      {
          string pop3Server = System.Configuration.ConfigurationManager.AppSettings["POP3Server"];
          string username = System.Configuration.ConfigurationManager.AppSettings["POP3Server"];
          string shareSecret=System.Configuration.ConfigurationManager.AppSettings["ShareSecret"];
          string pwd =CommonLibrary.Crypto.DecryptStringAES(System.Configuration.ConfigurationManager.AppSettings["POP3Server"],shareSecret);
          EMailReceiver.POP3client pop3client = new POP3client(pop3Server, username, pwd);
         // pop3client.
      }
    }
}
