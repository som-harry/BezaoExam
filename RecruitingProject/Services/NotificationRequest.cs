using RecruitingProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace RecruitingProject.Services
{
    public class NotificationRequest: IMail
    {
        public  async Task SendMail(string recieverEmail, string messageBody, string messageSubject)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "chisomekeh71@gmail.com",
                    Password = "judeallowedyou1519"
                };
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage()
                {
                    To = { recieverEmail },
                    Body = messageBody,
                    From = new MailAddress("harryapp@gmail.com"),
                    Subject = messageSubject
                };

                await smtpClient.SendMailAsync(mailMessage);
                smtpClient.Dispose();
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
            }


        }
    }
}