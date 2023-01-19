using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers {
    public class AccountController : Controller {
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
