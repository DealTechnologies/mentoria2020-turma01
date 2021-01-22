using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Filme.Inputs
{
    public class AtualizarFilmeCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id é um campo obrigatório");

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
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
