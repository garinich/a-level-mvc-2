using System.ComponentModel.DataAnnotations;

namespace Animals.Models
{
    public class LoginPostModel
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}