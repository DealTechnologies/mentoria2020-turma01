using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Email
{
    public interface IEmailSender
    {
        Task EnviarEmailAsync(string email, string assunto, string mensagem);
    }
}
