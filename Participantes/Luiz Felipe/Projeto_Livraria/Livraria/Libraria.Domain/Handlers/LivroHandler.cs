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

        public LivroHandler(ILivroRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AdicionarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                Livro livro = new Livro(command.Nome, command.Autor, command.Edicao, command.Isbn, command.Imagem);

                var id = _repository.InserirAsync(livro).Result;

                return new AdicionarLivroCommandResult(true, "Livro Gravado com sucesso!", new
                {
                    Id = id,
                    Nome = livro.Nome,
                    Autor = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });
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

                if (!_repository.CheckIdAsync(command.Id).Result)
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");
                    return new AtualizarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                string id = command.Id;

                Livro livro = new Livro(command.Nome, command.Autor, command.Edicao, command.Isbn, command.Imagem) { Id = id };

                _repository.AlterarAsync(livro);

                return new AtualizarLivroCommandResult(true, "Livro Atualizado com sucesso!", new
                {
                    Id = id,
                    Nome = livro.Nome,
                    Autor = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });
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

                if (!_repository.CheckIdAsync(command.Id).Result)
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");
                    return new ApagarLivroCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                _repository.DeletarAsync(command.Id);

                return new ApagarLivroCommandResult(true, "Livro Apagado com sucesso!", new
                {
                    Id = command.Id
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
