using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Repositry;

namespace WebApplication8.Controllers
{
    public class Account : Controller
    {
        private readonly IAccountRepostry _IAccountRepostry;

        public Account(IAccountRepostry IAccountRepostry)
        {
            _IAccountRepostry = IAccountRepostry;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public async  Task <IActionResult> SignUp(SignIn userModel )
        {
            if (ModelState.IsValid)
            {
               var result =await _IAccountRepostry.CreateUserAsync(userModel);
               if (!(result.Succeeded))        //if user information doesnt store in database Display error Message
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        
                        return View(userModel);
                    }
                }
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login  , string returnURl)
        {
            if (ModelState.IsValid)
            {
                var result = await _IAccountRepostry.PasswordSignInAsync(login);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnURl))
                    {
                        return LocalRedirect(returnURl);
                    }
                    return RedirectToAction("Index" , "Home");
                }

                if (result.IsNotAllowed)    //vertify account
                {
                    ModelState.AddModelError("", "Not allowed to login");
                }

                else if(result.IsLockedOut)    //blocked
                {
                    ModelState.AddModelError("", "Account BLocked , Try Later :)");
                }

                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                }
               

            }


            return View();
        }

        public async Task<IActionResult>Logout()
        {
           await _IAccountRepostry.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public async Task<IActionResult> ChangPassword()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ChangPassword(ChangePassword _ChangePassword)
        {

            if(ModelState.IsValid)
            {
              var result =  await _IAccountRepostry.ChangePassword(_ChangePassword);
                //if the process succeeded
                if (result.Succeeded)
                {
                    ViewBag.succeed = true;
                    ModelState.Clear();
                    return View();
                }

                //if it vaild to change password print errors
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
           
            //if requried false
            return View(_ChangePassword);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult>EmailConfirm(string id, string token)
        {

            if (!string.IsNullOrEmpty(id) & !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
               var result = await _IAccountRepostry.EmailConfirmAsync(id , token);

                if (result.Succeeded)
                {
                    ViewBag.IsSucceeded = true;
                }
                return View("EmailConfirm");
            }

            return View(nameof(Login));
        }
    }
}

