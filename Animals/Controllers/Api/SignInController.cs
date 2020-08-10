using Animals.Models;
using BusinessLayer.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Animals.Controllers.Api
{
    public class SignInController : ApiController
    {
        public async Task<bool> PostAsync([FromBody]LoginPostModel model)
        {
            var ctx = HttpContext.Current.GetOwinContext();
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

                return true;
            }

            return false;
        }
    }
}
