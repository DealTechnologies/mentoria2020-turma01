using Flunt.Notifications;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Command.Voto.Input;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Commands;
using System;
using Votacao.Domain.Query.Voto;

namespace Votacao.Domain.Handlers
{
    public class VotoHandler : Notifiable, IVotoHandler
    {
        private readonly IVotoRepository _repository;
        private readonly IUsuarioRepository _repositoryUsuario;
        private readonly IFilmeRepository _repositoryFilme;

        public VotoHandler(IVotoRepository repository, IUsuarioRepository repositoryUsuario, IFilmeRepository repositoryFilme)
        {
            _repository = repository;
            _repositoryUsuario = repositoryUsuario;
            _repositoryFilme = repositoryFilme;
        }

        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                int id = 0;
                Usuario usuario = new Usuario(command.IdUsuario);
                Filme filme = new Filme(command.IdFilme);

                Voto voto = new Voto(id, usuario, filme);

                if (voto.Usuario.Id == 0)
                    AddNotification("Id Usuário", "Id não está vinculado à operação solicitada");

                if (voto.Filme.Id == 0)
                    AddNotification("Id Filme", "Id não está vinculado à operação solicitada");

                if (!_repositoryUsuario.CheckId(voto.Usuario.Id))
                    AddNotification("Id Usuário", "Este Id Usuário não está cadastrado! Impossível prosseguir com este Id Usuário.");

                if (!_repositoryFilme.CheckId(voto.Filme.Id))
                    AddNotification("Id Filme", "Este Id Filme não está cadastrado! Impossível prosseguir com este Id Filme.");

                if (_repository.CheckUsuarioVotou(voto.Usuario.Id))
                    AddNotification("Id Usuário", "Este Id Usuário já possui um voto registrado.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                id = _repository.Salvar(voto);

                return new CommandResult(true, "Voto gravado com sucesso!", new
                {
                    Id = id,
                    IdUsuario = voto.Usuario.Id,
                    IdFilme = voto.Filme.Id
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    AddNotification("Id", "Este Id não está cadastrado! Impossível prosseguir com este Id.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                VotoQueryResult usuarioQR = _repository.Obter(command.Id);

                int id = usuarioQR.Id;
                Usuario usuario = new Usuario(usuarioQR.Usuario.Id);
                Filme filme = new Filme(command.IdFilme);

                Voto voto = new Voto(id, usuario, filme);

                if (voto.Id == 0)
                    AddNotification("Id", "Id não está vinculado à operação solicitada");

                if (voto.Usuario.Id == 0)
                    AddNotification("Id Usuário", "Id não está vinculado à operação solicitada");

                if (voto.Filme.Id == 0)
                    AddNotification("Id Filme", "Id não está vinculado à operação solicitada");

                if (!_repositoryUsuario.CheckId(voto.Usuario.Id))
                    AddNotification("Id Usuário", "Este Id Usuário não está cadastrado! Impossível prosseguir com este Id Usuário.");

                if (!_repositoryFilme.CheckId(voto.Filme.Id))
                    AddNotification("Id Filme", "Este Id Filme não está cadastrado! Impossível prosseguir com este Id Filme.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _repository.Atualizar(voto);

                return new CommandResult(true, "Voto atualizado com sucesso!", new
                {
                    Id = voto.Id,
                    IdUsuario = voto.Usuario.Id,
                    IdFilme = voto.Filme.Id
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ApagarVotoCommand command)
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

                return new CommandResult(true, "Voto excluído com sucesso!", new { Id = command.Id });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}