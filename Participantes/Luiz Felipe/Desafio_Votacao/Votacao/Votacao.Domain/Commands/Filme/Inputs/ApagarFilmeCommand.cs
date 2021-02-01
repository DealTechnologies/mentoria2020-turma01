using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Filme.Inputs
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", Avisos.Campo_obrigatorio);

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
