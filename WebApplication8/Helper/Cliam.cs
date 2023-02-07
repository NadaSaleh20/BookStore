using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Helper
{
    public class Cliam : UserClaimsPrincipalFactory<Users, IdentityRole>
    {
        public Cliam(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(Users user)
        {
          var idenity = await base.GenerateClaimsAsync(user);
            //Name will use to access First Name   //Name in User Class
            idenity.AddClaim(new Claim("CliamFirstName", user.FirstName?? ""));
            idenity.AddClaim(new Claim("CliamLastName", user.LastName?? ""));
            return idenity;
        }




    }
}
