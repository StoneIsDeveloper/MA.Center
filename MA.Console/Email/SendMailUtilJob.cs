using log4net;
using Quartz;
using Quartz.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Email
{
   public class SendMailUtilJob : IJob
    {
       
        private static readonly ILog logger = LogManager.GetLogger(typeof(SendMailUtilJob));

        public MailMessage actualMailSent = new MailMessage();
        public string actualSmtpHost = "ad";
        public string actualSmtpUserName;
        public string actualSmtpPassword;
        public int? actualSmtpPort;

        public async  Task Execute(IJobExecutionContext context)
        {
            logger.Info("SampleJob running...");
            await Task.Delay(TimeSpan.FromSeconds(1));

            new Task( () =>
            {
                Send();
            }).RunSynchronously();
        }

        protected void  Send()
        {

            Random rd = new Random();
            var number = rd.Next(1, 100);

            var mailTo = "m18146611430@163.com";
            var mailSubject = "Test Mial 2019";
            var mailContent = $@"{DateTime.Now.ToString()} <br/>
                                 <h3> Test Mail Contect ： {number} </h3> <br/>";

            EmailManager.SendMail(mailTo, mailSubject, mailContent);

            logger.Info($"Send Mail to m18146611430@163.com : number ");
        }


    }
}
