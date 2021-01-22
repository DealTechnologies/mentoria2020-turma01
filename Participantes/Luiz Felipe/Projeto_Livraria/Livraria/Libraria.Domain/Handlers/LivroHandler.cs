using Flunt.Notifications;
using Livraria.Domain.Commands.Livro.Input;
using Livraria.Domain.Commands.Livro.Output;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Commands;
using Livraria.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Handlers
{
    public class LivroHandler : Notifiable, ICommanHandler<AdicionarLivroCommand>,
                                            ICommanHandler<AtualizarLivroCommand>,
                                            ICommanHandler<ApagarLivroCommand>
    {
        private readonly ILivroRepository _repository;

        public ICommandResult Handler(AdicionarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                string nome = command.Nome;
                string autor = command.Autor;
                int edicao = command.Edicao;
                string isbn = command.Isbn;
                string imagem = command.Imagem;

                Livro livro = new Livro(0, nome, autor, edicao, isbn, imagem);

                id = _repository.Inserir(livro);

                var retorno = new AdicionarLivroCommandResult(true, "Livro Gravado com sucesso!", new
                {
                    Id = id,
                    Nome = livro.Nome,
                    Autor = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(AtualizarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AtualizarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");
                    return new AtualizarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                long id = command.Id;
                string nome = command.Nome;
                string autor = command.Autor;
                int edicao = command.Edicao;
                string isbn = command.Isbn;
                string imagem = command.Imagem;

                Livro livro = new Livro(0, nome, autor, edicao, isbn, imagem);

                _repository.Alterar(livro);

                var retorno = new AtualizarLivroCommandResult(true, "Livro Atualizado com sucesso!", new
                {
                    Id = id,
                    Nome = livro.Nome,
                    Autor = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(ApagarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new ApagarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");
                    return new ApagarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                long id = command.Id;

                _repository.Deletar(command.Id);

                var retorno = new ApagarLivroCommandResult(true, "Livro Apagado com sucesso!", new
                {
                    Id = id
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
