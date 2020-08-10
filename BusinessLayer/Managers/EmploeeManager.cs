using DataAccess;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BusinessLayer.Managers
{
    public class EmployeeManager : UserManager<Emploee>
    {
        public EmployeeManager(IUserStore<Emploee> store) : base(store){}
        public static EmployeeManager Create(IdentityFactoryOptions<EmployeeManager> options, IOwinContext context)
        {
            AnimalsContext db = context.Get<AnimalsContext>();
            EmployeeManager manager = new EmployeeManager(new UserStore<Emploee>(db));

            return manager;
        }

    }
}
