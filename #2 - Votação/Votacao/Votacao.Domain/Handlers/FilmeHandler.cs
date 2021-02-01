using Flunt.Notifications;
using System;
using Votacao.Domain.Command.Filme.Input;
using Votacao.Domain.Commands;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Domain.Handlers
{
    public class FilmeHandler : Notifiable, IFilmeHandler
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                int id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                id = _repository.Salvar(filme);

                return new CommandResult(true, "Filme gravado com sucesso!", new
                {
                    Id = id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                int id = command.Id;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                if (filme.Id == 0)
                    AddNotification("Id", "Id não está vinculado à operação solicitada");

                if (!_repository.CheckId(filme.Id))
                    AddNotification("Id", "Este Id não está cadastrado! Impossível prosseguir com este Id.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _repository.Atualizar(filme);

                return new CommandResult(true, "Filme atualizado com sucesso!", new
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ApagarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    AddNotification("Id", "Este Id não está cadastrado! Impossível prosseguir sem um Id válido.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _repository.Deletar(command.Id);

                return new CommandResult(true, "Filme excluído com sucesso!", new { Id = command.Id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}