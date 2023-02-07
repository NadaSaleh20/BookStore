using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication8.Services
{
    public class ServicesUser : IServicesUser
    {
        private readonly IHttpContextAccessor  _httpContextAccessor;

        public ServicesUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string getUserId()
        { 
                                                     // ? if the user null
           var val = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return val;
        }

        public bool IsLogged()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
