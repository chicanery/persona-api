using System.Threading.Tasks;

namespace Chicanery.Persona.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
