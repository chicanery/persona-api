using Chicanery.Persona.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chicanery.Persona.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(applicationUser => applicationUser.Avatar)
                .WithOne(avatar => avatar.ApplicationUser)
                .HasForeignKey<Avatar>(avatar => avatar.ApplicationUserId);
        }

        public DbSet<Avatar> Avatars { get; set; }
    }
}
