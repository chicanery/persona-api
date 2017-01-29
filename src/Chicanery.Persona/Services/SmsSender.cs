using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chicanery.Persona.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }

    public class SmsSenderOptions
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string Number { get; set; }
    }

    public class SmsSender : ISmsSender
    {
        private readonly IOptions<SmsSenderOptions> _options;
        private readonly HttpClient _client;

        public SmsSender(IOptions<SmsSenderOptions> options, HttpClient client)
        {
            _options = options;
            _client = client;
            _client.SetBasicAuthentication(_options.Value.AccountSid, _options.Value.AuthToken);
        }

        public async Task SendSmsAsync(string number, string message)
        {
            var body = new Dictionary<string, string>
            {
                { "To", number },
                { "From", _options.Value.Number },
                { "Body", message }
            };
            var response = await _client.PostAsync($"https://api.twilio.com/2010-04-01/Accounts/{_options.Value.AccountSid}/Messages",
                new FormUrlEncodedContent(body));
            response.EnsureSuccessStatusCode();
        }
    }
}
