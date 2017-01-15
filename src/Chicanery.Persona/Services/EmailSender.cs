using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chicanery.Persona.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IOptions<EmailSenderOptions> _options;

        public EmailSender(IOptions<EmailSenderOptions> options)
        {
            _options = options;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _options.Value.ApiKeyId);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var body = new
            {
                personalizations = new[] { new { to = new[] { new { email } } } },
                from = new { email = _options.Value.From },
                subject,
                content = new[] { new { type = "text/html", value = message } }
            };
            var response = await _client.PostAsync("https://api.sendgrid.com/v3/mail/send",
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }

    public class EmailSenderOptions
    {
        public string ApiKeyId { get; set; }
        public string From { get; set; }
    }
}
