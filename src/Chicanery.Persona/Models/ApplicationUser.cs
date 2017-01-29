using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Chicanery.Persona.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Avatar Avatar { get; set; }
    }
}
