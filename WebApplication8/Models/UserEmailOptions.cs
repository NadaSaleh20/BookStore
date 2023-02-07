using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class UserEmailOptions
    {
        public List<string> ToEmails { get; set; }
        public string subject { get; set; }

        public string body { get; set; }

        public List<KeyValuePair<string,string>> placeholder { get; set; }


    }
}
