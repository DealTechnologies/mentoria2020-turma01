using FilmesVotacao.Domain.Commands.Filme.Input;
using FilmesVotacao.Domain.Commands.Filme.Output;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Handlers
{
    public class FilmeHandler : Notifiable, ICommandHandler<AdicionarFilmeCommand>,
                                            ICommandHandler<AtualizarFilmeCommand>,
                                            ICommandHandler<ApagarFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new AdicionarFilmeCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(0, titulo, diretor);

                long Id = _repository.Inserir(filme);

                var retorno = new AdicionarFilmeCommandResult(true, "Filme criado com sucesso", new
                {
                    Id = Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ICommandResult Handler(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new AtualizarFilmeCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);
                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado");
                    return new AtualizarFilmeCommandResult(false, "Corrija as inconsistências abaixo", Notifications);
                }

                long id = command.Id;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                _repository.Alterar(filme);

                var retorno = new AdicionarFilmeCommandResult(true, "Filme alterado com sucesso", new
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ICommandResult Handler(ApagarFilmeCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new ApagarFilmeCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);
                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este id não está cadastrado");
                    return new ApagarFilmeCommandResult(false, "Corrija as inconsistências abaixo", Notifications);
                }


                _repository.Deletar(command.Id);

                var retorno = new ApagarFilmeCommandResult(true, "Filme deletado com sucesso", new
                {
                    Id = command.Id,
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

        