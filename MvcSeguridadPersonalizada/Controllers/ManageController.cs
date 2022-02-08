using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcSeguridadPersonalizada.Controllers
{
    public class ManageController : Controller
    {

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if(username.ToLower() == "admin" && password.ToLower() == "admin")
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                Claim claimUserName = new Claim(ClaimTypes.Name,username);
                identity.AddClaim(claimUserName);
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,new AuthenticationProperties 
                { 
                    ExpiresUtc = DateTime.Now.AddMinutes(15)
                });
                return RedirectToAction("Perfil","Usuario");
            }
            else
            {
                ViewData["MENSAJE"] = "Credenciales Incorrectas";
            }
            return View();
        }
    }
}
