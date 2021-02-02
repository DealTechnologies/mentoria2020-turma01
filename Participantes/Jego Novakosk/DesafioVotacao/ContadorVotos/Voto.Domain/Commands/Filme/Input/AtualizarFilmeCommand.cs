using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Filme.Input
{
    public class AtualizarFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                //tratamento erro Id
                if (Id < 0)
                {
                    AddNotification("Id", "Id e um campo obrigatorio");
                }
                //tratamento de erro do campo Titulo 
                if (string.IsNullOrEmpty(Titulo))
                {
                    AddNotification("Titulo", "Titulo e um compo Obrigatorio");
                }
                else if (Titulo.Length > 50)
                {
                    AddNotification("Titulo", "Campo maior que o esperado");
                }

                // tratamento do campo Diretor
                if (string.IsNullOrEmpty(Diretor))
                {
                    AddNotification("Diretor", "Diretor e um campo Obrigatorio");
                }
                else if (Diretor.Length > 50)
                {
                    AddNotification("Diretor", "Campo maior que o esperado");
                }

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

