using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InspireWealth.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        [PersonalData]
        public string LastName { get; set; } = String.Empty;   
    }
}
