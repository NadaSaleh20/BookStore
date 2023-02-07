using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using System.Dynamic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApplication8.Repositry;
using WebApplication8.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsSnapshot<NewBookAlert> newbookalretconfiguration;
        private readonly IMessage _IMessage;
        private readonly IServicesUser _servicesUser;
        private readonly IEmailService _emailService;
        private readonly NewBookAlert _newbookalretconfiguration;
        private readonly NewBookAlert _Secondnewbookalretconfiguration;

        public HomeController(ILogger<HomeController> logger,IOptionsSnapshot<NewBookAlert> newbookalretconfiguration , IMessage IMessage , IServicesUser servicesUser , IEmailService emailService)
        {
            _logger = logger;
            this.newbookalretconfiguration = newbookalretconfiguration;
            _IMessage = IMessage;
            _servicesUser = servicesUser;
            _emailService = emailService;
            _newbookalretconfiguration = newbookalretconfiguration.Get("First");
            _Secondnewbookalretconfiguration = newbookalretconfiguration.Get("Second");

        }

        public async Task <IActionResult>  Index()
        {

        

           
            
           // var val = _servicesUser.getUserId();
           // var val2 = _servicesUser.IsLogged();
           //var name = _newbookalretconfiguration.bookName;
           // var name2 = _Secondnewbookalretconfiguration.bookName;
            return View();

        }

        
        public IActionResult Contact(string name)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
