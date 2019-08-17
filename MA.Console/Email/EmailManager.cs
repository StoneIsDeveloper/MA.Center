using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Email
{
    public static class EmailManager
    {
        #region 发送方信息
        private static readonly  string smtpServer = "smtp.163.com"; //SMTP服务器
        private static readonly string mailFrom = "m18146611430@163.com"; //登陆用户名
        private static readonly string userPassword = "li3963li2072";//登陆密码
        #endregion


        public static bool SendMail(string mailTo,string mailSubject, string mailContent)
        {
            if (mailTo == string.Empty || mailSubject == string.Empty)
                throw new Exception("Email reciver is null ! Please set recicver.");

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级
       
            return ExeuctSendMail(mailMessage); ;
        }

        private static  bool ExeuctSendMail(MailMessage mailMessage)
        {
            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }

        
  
    }
}
