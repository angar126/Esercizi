using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using DataLayer;
using Microsoft.Extensions.Options;

namespace Services
{
    public class EmailService:IEmailService
    {
        readonly string _mailAddress;
        public EmailService()
        {
        }
        public EmailService(IOptions<MySetting> email)
        {
            _mailAddress = email.Value.OrderEmail;
        }

        public void SendEmail(User user,string toAddress, string subject, string body)
        {

            var FromAddress = new MailAddress(user.Email);
            var ToAddress = new MailAddress(toAddress);
            var fromPassword = user.Password;


            var smtp = new SmtpClient
            {
                Host = user.Host,
                Port = user.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(FromAddress, ToAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        //prova
        public void SendEmail(User user,  string subject, string body)
        {

            var FromAddress = new MailAddress(user.Email);
            var ToAddress = new MailAddress(_mailAddress);
            var fromPassword = user.Password;


            var smtp = new SmtpClient
            {
                Host = user.Host,
                Port = user.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(FromAddress, ToAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
