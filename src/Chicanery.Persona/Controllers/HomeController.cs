using Chicanery.Persona.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chicanery.Persona.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAvatarGenerator _generator;

        public HomeController(IAvatarGenerator generator)
        {
            _generator = generator;
        }

        public async Task<IActionResult> Test(string id)
        {
            var avatar = await _generator.GenerateAvatarAsync(id);
            return File(avatar.Image, avatar.MimeType);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
