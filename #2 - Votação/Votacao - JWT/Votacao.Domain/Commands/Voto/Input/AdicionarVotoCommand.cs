using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Command.Voto.Input
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public int IdUsuario { get; set; }
        public int IdFilme { get; set; }

        public bool ValidarCommand()
        {
            if (IdUsuario <= 0)
                AddNotification("Id Usuário", "Id Usuário não é valido");

            if (IdFilme <= 0)
                AddNotification("Id Filme", "Id Filme não é valido");

            return Valid;
        }
    }
}