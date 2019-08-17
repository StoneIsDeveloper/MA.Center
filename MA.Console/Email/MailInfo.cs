using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Email
{
    public class MailInfo
    {
        public MailMessage MailMessage { get; set; }

        public string SmtpHost { get; set; }

        public int? SmtpPort { get; set; }

        public string SmtpUserName { get; set; }

        public string SmtpPassword { get; set; }
    }

    public class ExpectedMail
    {
        public readonly string recipient;
        public readonly string sender;
        public readonly string subject;
        public readonly string message;
        public string ccRecipient;
        public string replyTo;

        public ExpectedMail(string recipient, string sender, string subject, string message)
        {
            this.recipient = recipient;
            this.sender = sender;
            this.subject = subject;
            this.message = message;
        }

    }



}
