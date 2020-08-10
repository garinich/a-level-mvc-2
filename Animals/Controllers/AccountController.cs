using Animals.Models;
using BusinessLayer.Managers;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Animals.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginPostModel model)
        {
            var ctx = HttpContext.GetOwinContext();
            var userManager = ctx.GetUserManager<EmployeeManager>();
            var auth = ctx.Authentication;
            var user = await userManager.FindAsync(model.UserName, model.Password);
            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                identity.AddClaim(new Claim("Lang", user.Lang));
                auth.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false,
                }, identity);
            }

            return RedirectToAction("Index", "Animals");
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterPostModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<EmployeeManager>();

            var employee = new Emploee
            {
                Email = model.Email,
                UserName = model.UserName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                City = model.City,
                Lang = model.Lang
            };

            var testUser = await userManager.CreateAsync(employee, model.Password);

            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult SingOut()
        {
            var ctx = HttpContext.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");
        }
    }
}