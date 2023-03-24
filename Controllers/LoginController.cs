using bitirmeSonProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bitirmeSonProje.Controllers
{
    public class LoginController : Controller
    {
        dbContext c = new dbContext();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Kullanici a)
        {
            var bilgiler =c.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi &&
                 x.Parola == a.Parola);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,a.KullaniciAdi)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);


                return RedirectToAction("DuyuruList", "Admin");



            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");


        }
    }
}

