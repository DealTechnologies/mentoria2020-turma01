using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Commands.Votos.Input;
using Voto.Domain.Commands.Votos.Output;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;

namespace Voto.Domain.Handlers
{
    public class VotosHandler : Notifiable, IVotosHandler
    {
        private readonly IVotoRepository _repository;
        private readonly IUsuarioRepository _usuario;
        private readonly IFilmeRepository _filme;

        public VotosHandler(IVotoRepository repository, IUsuarioRepository usuario, IFilmeRepository filme)
        {
            _repository = repository;
            _usuario = usuario;
            _filme = filme;
        }
        public ICommandResult Handler(AdicionarVotosCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AdicionarVotosCommandResult(false, "Por Favor arrumar as inconsistência abaico", command.Notifications);
                }

                if (!_usuario.CheckUsuarioId(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "IdUsuario Invalido. Este ai nao esta cadastrado");
                    return new AdicionarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                if (!_filme.CheckId(command.IdFilme))
                {
                    AddNotification("IdFilme", "IdFilme Invalido. Este ai nao esta cadastrado");
                    return new AdicionarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                if (_repository.CheckIdUsuario(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "IdUsuario Invalido. Este usuario ja Votou");
                    return new AdicionarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                int id = 0;
                int idUsuario = command.IdUsuario;
                int idFilme = command.IdFilme;

                Votos votos = new Votos(0, idUsuario, idFilme);

                id = _repository.Inserir(votos);

                var ret = new AdicionarVotosCommandResult(true, "Voto adicionado com sucesso!", new
                {
                    Id = id,
                    IdUsuario = votos.IdUsuario,
                    IdFilme = votos.IdFilme
                });

                return ret;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(AtualizarVotosCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AtualizarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Este ai nao esta cadastrado");
                    return new AtualizarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                if (!_usuario.CheckUsuarioId(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "IdUsuario Invalido. Este ai nao esta cadastrado");
                    return new AdicionarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                if (!_filme.CheckId(command.IdFilme))
                {
                    AddNotification("IdFilme", "IdFilme Invalido. Este ai nao esta cadastrado");
                    return new AdicionarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                int id = command.Id;
                int idUsuario = command.IdUsuario;
                int idFilme = command.IdFilme;

                Votos votos = new Votos(id, idUsuario, idFilme);

                _repository.Alterar(votos);

                var retorna = new AtualizarVotosCommandResult(true, "Voto atualizado com sucesso", new
                {
                    Id = votos.Id,
                    IdUsuario = votos.IdUsuario,
                    IdFilme = votos.IdFilme

                });

                return retorna;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(ApagarVotosCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new ApagarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Este ai nao esta cadastrado");
                    return new ApagarVotosCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                _repository.Deletar(command.Id);

                var retorna = new ApagarVotosCommandResult(true, "Voto apagado com sucesso!", new
                {
                    Id = command.Id
                });
                return retorna;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


}
