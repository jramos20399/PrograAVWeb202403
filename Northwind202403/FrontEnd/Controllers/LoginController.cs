using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        ISecurityHelper securityHelper;

        public LoginController(ISecurityHelper securityHelper)
        {
                this.securityHelper = securityHelper;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
