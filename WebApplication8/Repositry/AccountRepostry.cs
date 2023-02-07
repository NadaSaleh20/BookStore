using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services;
using Microsoft.AspNetCore.Identity;

namespace WebApplication8.Repositry
{
    public class AccountRepostry : IAccountRepostry
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IServicesUser _servicesUser;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepostry(UserManager<Users> userManager, SignInManager<Users> signInManager, IServicesUser servicesUser, IEmailService emailService, IConfiguration configuration , RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _servicesUser = servicesUser;
            _emailService = emailService;
            _configuration = configuration;
            _roleManager = RoleManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignIn userModel)
        {
            //UserModel Email , password, confirm password
            //output IdentityResult we cast userModel to IdentityResult 
            var user = new Users()   //user have type IdentityUser must have email , userName both the same here
            {
                Email = userModel.Email,       //Email equal userName
                UserName = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded) //result added to database
            {
                await _userManager.AddToRoleAsync(user, "User");
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await sendEmailConfirmation(user, token);
                }

            }

            return result;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(Login Login)
        {
            var result = await _signInManager.PasswordSignInAsync(Login.Email, Login.Password, false, true);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePassword(ChangePassword changePassword)
        {
            //we must Know the id of the user
            var userid = _servicesUser.getUserId();
            var userinfo = await _userManager.FindByIdAsync(userid);



            //this method take user , current Password , New Password
            return await _userManager.ChangePasswordAsync(userinfo, changePassword.Password, changePassword.changepassword);
        }

        public async Task<IdentityResult> EmailConfirmAsync(string id , string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(id) , token);
           
        }

        public async Task sendEmailConfirmation(Users users, string token)
        {
            //get the data from appsetting file
            var AppDomain = _configuration.GetSection("Application:AppDomain").Value;
            var EmailConfirmation = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions userEmailOptions = new UserEmailOptions()
            {
                ToEmails = new List<string>() { users.Email },
                placeholder = new List<KeyValuePair<string, string>>()
                {
                     new KeyValuePair<string,string>("{{UserName}}", users.FirstName),
                     //get the full path and added in the  link                                 link       arg1      arg2
                     new KeyValuePair<string,string>("{{link}}",string.Format(AppDomain+EmailConfirmation,users.Id ,token))
                }
            };

            await _emailService.sendEmailtext(userEmailOptions);

        }




    }
}
