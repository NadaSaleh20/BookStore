using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services
{
    public class EmailService : IEmailService
    {
        private SMTPConfigModel _SMTPConfigModel;
        public EmailService(IOptions<SMTPConfigModel> smptconfig)
        {
            _SMTPConfigModel = smptconfig.Value;
        }

        //the path of html page       folderName/file.html
        private const string templetePath = @"EmailTempletes/{0}.html";

        public async Task sendEmailtext(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.subject = "This is cofirm email ";
            userEmailOptions.body = updateplaceholder(getEmailBody("EmailConfirmed"), userEmailOptions.placeholder) ;
            await sendEmail(userEmailOptions);
        }


        public async Task sendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mailMessage = new MailMessage()
            {
                Subject = userEmailOptions.subject,
                Body = userEmailOptions.body,
                From = new MailAddress(_SMTPConfigModel.SenderAddress, _SMTPConfigModel.SenderDisplayName),
                IsBodyHtml = _SMTPConfigModel.IsBodyHTMl

            };

            foreach (var item in userEmailOptions.ToEmails)
            {
                mailMessage.To.Add(item);

            }

            NetworkCredential networkCredential = new NetworkCredential(_SMTPConfigModel.UserName, _SMTPConfigModel.Password);
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _SMTPConfigModel.host,
                Port = _SMTPConfigModel.port,
                EnableSsl = _SMTPConfigModel.EnableSSL,
                UseDefaultCredentials = _SMTPConfigModel.UserDefaultCredentias,
                Credentials = networkCredential
            };

            mailMessage.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mailMessage);
        }

        public string getEmailBody(string templeteName)
        {
            var body = File.ReadAllText(string.Format(templetePath, templeteName));

            return body;
        }

        public string updateplaceholder(string text , List<KeyValuePair<string, string>> placeholder)
        {

            if (!string.IsNullOrEmpty(text) && placeholder !=null)   //make ensure that is not null
            {
                foreach (var item in placeholder)
                {
                    if (text.Contains(item.Key))
                    {
                        text = text.Replace(item.Key, item.Value);
                    }
                }
               
            }

            return text;
        }

    }
}
