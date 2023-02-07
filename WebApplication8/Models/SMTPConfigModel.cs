﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class SMTPConfigModel
    {

        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UserDefaultCredentias { get; set; }

        public bool IsBodyHTMl { get; set; }

    }
}
