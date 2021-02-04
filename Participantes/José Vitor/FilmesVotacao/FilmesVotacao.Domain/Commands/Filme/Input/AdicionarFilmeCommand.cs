using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace FilmesVotacao.Domain.Commands.Filme.Input
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Titulo))
                    AddNotification("Titulo", "Titulo é um campo obrigatório");
                else if (Titulo.Length > 50)
                    AddNotification("Titulo", "Titulo não pode ter mais que 50 caracteres");

                if (string.IsNullOrEmpty(Diretor))
                    AddNotification("Diretor", "Diretor é um campo obrigatório");
                else if (Titulo.Length > 50)
                    AddNotification("Diretor", "Diretor não pode ter mais que 50 caracteres");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}