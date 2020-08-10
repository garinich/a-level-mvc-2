using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Emploee : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string LastName { get; set; }

        [StringLength(2)]
        public string Lang { get; set; }
    }
}
