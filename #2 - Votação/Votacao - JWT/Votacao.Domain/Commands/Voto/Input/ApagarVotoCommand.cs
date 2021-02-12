using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Command.Voto.Input
{
    public class ApagarVotoCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }

        public bool ValidarCommand()
        {
            if (Id <= 0)
                AddNotification("Id", "Id não é valido");

            return Valid;
        }
    }
}