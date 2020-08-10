using Animals.Models;
using BusinessLayer.Managers;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Animals.Controllers.Api
{
    public class RegisterController : ApiController
    {

        public async Task<bool> PostAsync([FromBody]RegisterPostModel model)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<EmployeeManager>();

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

            return testUser != null;
        }
    }
}
