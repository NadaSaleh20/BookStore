using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Repositry
{
    public class Message : IMessage
    {
        public  readonly NewBookAlert _NewBookAlert;
        public Message(IOptionsMonitor<NewBookAlert> NewBookAlert)
        {
            _NewBookAlert = NewBookAlert.CurrentValue;
        }
        public string GetName()
        {
            return _NewBookAlert.bookName;
                }
    }
}
