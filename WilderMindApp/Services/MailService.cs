using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WilderMindApp.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from,string to,string subject, string body)
        { 
            return true;
        }

    }
}