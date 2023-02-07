using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services
{
    public interface IEmailService
    {
        string getEmailBody(string templeteName);
        Task sendEmail(UserEmailOptions userEmailOptions);
        Task sendEmailtext(UserEmailOptions userEmailOptions);

        string updateplaceholder(string text, List<KeyValuePair<string, string>> placeholder);
    }
}