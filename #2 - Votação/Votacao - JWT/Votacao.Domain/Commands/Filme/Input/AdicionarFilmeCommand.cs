using Flunt.Notifications;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Command.Filme.Input
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            if (string.IsNullOrEmpty(Titulo))
                AddNotification("Titulo", "Titulo é um campo obrigatório");
            else if (Titulo.Length > 50)
                AddNotification("Titulo", "Titulo maior que o esperado");

            if (string.IsNullOrEmpty(Diretor))
                AddNotification("Diretor", "Diretor é um campo obrigatório");
            else if (Diretor.Length > 50)
                AddNotification("Diretor", "Diretor maior que o esperado");

            return Valid;
        }
    }
}