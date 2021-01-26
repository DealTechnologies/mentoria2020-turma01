using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Filme.Inputs
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Titulo))
                    AddNotification("Titulo", Avisos.Campo_obrigatorio);
                else if (Titulo.Length > 50)
                    AddNotification("Titulo", Avisos.Campo_maior_que_o_esperado);

                if (string.IsNullOrEmpty(Diretor))
                    AddNotification("Diretor", Avisos.Campo_obrigatorio);
                else if (Diretor.Length > 50)
                    AddNotification("Diretor", Avisos.Campo_maior_que_o_esperado);

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
