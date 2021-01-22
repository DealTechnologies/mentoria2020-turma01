using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class AdicionarLivroCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Nome { get; private set; }
        public string Autor { get; private set; }
        public int Edicao { get; private set; }
        public string Isbn { get; private set; }
        public string Imagem { get; private set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que o esperado");

                if (string.IsNullOrEmpty(Autor))
                    AddNotification("Autor", "Autor é um campo obrigatório");
                else if (Autor.Length > 50)
                    AddNotification("Autor", "Autor maior que o esperado");

                if (Edicao <= 0)
                    AddNotification("Edicao", "Edicao é um campo obrigatório");

                if (string.IsNullOrEmpty(Isbn))
                    AddNotification("Isbn", "Isbn é um campo obrigatório");
                else if (Isbn.Length > 50)
                    AddNotification("Isbn", "Isbn maior que o esperado");

                if (string.IsNullOrEmpty(Imagem))
                    AddNotification("Imagem", "Imagem é um campo obrigatório");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
