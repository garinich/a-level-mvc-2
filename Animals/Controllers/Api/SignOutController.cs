using System.Web;
using System.Web.Http;

namespace Animals.Controllers.Api
{
    public class SignOutController : ApiController
    {
        [Authorize]
        public void Post()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut();
        }
    }
}
