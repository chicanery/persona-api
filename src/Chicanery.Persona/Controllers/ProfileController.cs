using Chicanery.Persona.Data;
using Chicanery.Persona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Chicanery.Persona.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ProfileController(
           UserManager<ApplicationUser> userManager,
           ApplicationDbContext context,
           ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _context = context;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        public async Task<IActionResult> Picture()
        {
            var user = await GetCurrentUserAsync();
            var avatar = _context.Avatars.First(a => a.ApplicationUser.Id == user.Id);
            return File(user.Avatar.Image, user.Avatar.MimeType);
        }

        #region Helpers

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        #endregion
    }
}
