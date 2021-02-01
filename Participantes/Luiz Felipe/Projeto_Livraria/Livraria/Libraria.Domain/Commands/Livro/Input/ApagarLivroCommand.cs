using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class ApagarLivroCommand : Notifiable, ICommandPadrao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Isbn { get; set; }
        public string Imagem { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                    AddNotification("Id", "Id é um campo obrigatório");
                if (Id.Length < 24)
                    AddNotification("Id", "Id é um campo Inválido");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
