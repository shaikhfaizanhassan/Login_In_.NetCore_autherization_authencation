using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RoleBaseAuthen_Autroziation.Models;
using System.Security.Claims;

namespace RoleBaseAuthen_Autroziation.Controllers
{
    public class AuthController : Controller
    {
        private readonly RegisterDbContext db;

        public AuthController(RegisterDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Register model)
        {
            var login = db.registers.Where(x=>x.Email.Equals(model.Email) && x.Password.Equals(model.Password)).SingleOrDefault(); 
            if(login != null) 
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,login.Email),
                    new Claim(ClaimTypes.Role,login.Role)
                };

                ClaimsIdentity Claimsidentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties Authproperties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Claimsidentity));
                return RedirectToAction("Index","Home");
            }
            else
            {

                return Content("Invalid Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
