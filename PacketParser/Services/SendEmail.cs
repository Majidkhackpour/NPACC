using System;
using System.Net.Mail;

namespace PacketParser.Services
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body, string sender = "", string password = "")
        {
            try
            {
                if (string.IsNullOrEmpty(sender))
                {
                    sender = "aradenj2211@gmail.com";
                    password = "09382420272";
                }
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(sender, "چرم آراد");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                //System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                // mail.Attachments.Add(attachment);

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(sender, password);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}