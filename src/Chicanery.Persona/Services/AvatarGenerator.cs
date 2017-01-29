using Chicanery.Persona.Models;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chicanery.Persona.Services
{
    public interface IAvatarGenerator
    {
        Task<Avatar> GenerateAvatarAsync(string value);
    }

    public class AvatarGenerator : IAvatarGenerator
    {
        private readonly HttpClient _client;

        public AvatarGenerator(HttpClient client)
        {
            _client = client;
        }

        public async Task<Avatar> GenerateAvatarAsync(string value)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = string.Join("", data.Select(b => b.ToString("x2")));
                var response = await _client.GetAsync($"https://www.gravatar.com/avatar/{hash}?d=identicon&s=200");
                response.EnsureSuccessStatusCode();
                var mime = response.Headers.FirstOrDefault(h => h.Key == "Content-Type").Value?.First() ?? "image/png";
                var image = await response.Content.ReadAsByteArrayAsync();
                return new Avatar
                {
                    MimeType = mime,
                    Image = image
                };
            }
        }
    }
}
