using ASP_Project_BLL.Helper;
using ASP_Project_BLL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project_PL.Areas.Admin.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
  
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Passowrd");

                }
            }


            return View(model);

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {

                    UserName = model.UserName,
                    Email = model.Email,

                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);


        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var PasswordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token },Request.Scheme);


                    var SentMail = SendMail.CreateMail(new MailVM { Email=model.Email,Title="Reset Password",Message=PasswordResetLink});
                    return RedirectToAction("ConfirmForgetPassword");
                }
                return RedirectToAction("ConfirmForgetPassword");
            }
            return View(model);
        }
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword(string Email,string Token)
        {


            if(Email==null || Token == null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(model);
                    }
                    
                }
                return RedirectToAction("ConfirmResetPassword");
              
            }

        
            return View(model);
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}
