using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Animals.Models
{
    public class RegisterPostModel
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(2)]
        public string Lang { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}