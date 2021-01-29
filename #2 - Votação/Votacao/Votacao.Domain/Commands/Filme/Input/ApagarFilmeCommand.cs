using Flunt.Notifications;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Command.Filme.Input
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
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