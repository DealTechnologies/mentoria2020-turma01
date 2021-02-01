using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using MongoDB.Bson;
using System;
using System.Text.Json.Serialization;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class AtualizarLivroCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
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
                // TRATAMENTO DE ERRO ID
                if (string.IsNullOrEmpty(Id.ToString()))
                {
                    AddNotification("Id", "Id e um campo obrigatorio");
                }
                else if (Id.ToString().Length < 24)
                {
                    AddNotification("Id", "Id é um compo menor do que o esperado");
                }

                // tratamento de error nome 
                if (string.IsNullOrEmpty(Nome))
                {
                    AddNotification("Nome", "Nome e um campo obrigatorio");
                }
                else if (Nome.Length > 50)
                {
                    AddNotification("Nome", "Nome e maior que esperado");
                }


                // TRATAMENTO DE ERRO DE AUTOR
                if (string.IsNullOrEmpty(Autor) )
                {
                    AddNotification("Autor", "Autor e um campo obrigatorio");
                }
                else if (Autor.Length > 50)
                {
                    AddNotification("Autor", "Autor e maior que esperado");
                }

                //TRATAMENTO DE ERRO DO CAMPO EDIÇÃO
                if (Edicao <= 0)
                {
                    AddNotification("Adicao", "Edicao e um campo obrigatorio");
                }


                //TRATAMENTO E VALIDAÇÃO DO CAMPO DE ISBN
                if (string.IsNullOrEmpty(Isbn))
                {
                    AddNotification("Isbn", "Isbn e um campo obrigatorio");
                }
                else if (Isbn.Length > 50)
                {
                    AddNotification("Isbn", "Isbn e maior que esperado");
                }

                // VALIDAR O CAMPO DE IMAGEM

                if (string.IsNullOrEmpty(Imagem))
                {
                    AddNotification("Imagem", "Imagem e um compo obrigatorio");
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
