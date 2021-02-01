using Flunt.Notifications;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Command.Voto.Input
{
    public class AtualizarVotoCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }

        public bool ValidarCommand()
        {
            if (Id <= 0)
                AddNotification("Id", "Id não é valido");

            if (IdFilme <= 0)
                AddNotification("Id Filme", "Id Filme não é valido");

            return Valid;
        }
    }
}