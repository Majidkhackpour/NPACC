using System;
using System.Net.Mail;

namespace PacketParser.Services
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            try
            {
                var mail = new MailMessage();
                var SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("aradenj2211@gmail.com", "چرم آراد");
                mail.To.Add(To);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("aradenj2211@gmail.com", "09382420272");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}