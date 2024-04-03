using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TomatoSorterDashboard.Models
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(10, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DisplayName("Username")]
        public string UserName { get; set; }
    }
}
