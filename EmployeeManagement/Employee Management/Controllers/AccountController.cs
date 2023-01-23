using employee_management.models;
using Employee_Management.Models;
using Employee_Management.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Employee_Management.Controllers {
    public class AccountController : Controller 
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }


        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            return View("Register");
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            } else
            {
                return Json($"Email : {email} is already in use.");
            }

        }
       

        [HttpPost]
        [AllowAnonymous]
        public async Task <IActionResult> Register(RegisterUserViewModel model)
        {
            if(ModelState.IsValid) 
            {
                var user  = new IdentityUser { UserName = model.Email,Email = model.Email };
              var result= await userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    } else
                    {
                    return RedirectToAction("index", "home");

                    }
                } else { 
               
                    ModelState.AddModelError(string.Empty, "Invalid Login Credentials");
                }
            }

            return View(model);
        }
    }
}
