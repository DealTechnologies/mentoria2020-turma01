using FilmesVotacao.Domain.Commands.Voto.Input;
using FilmesVotacao.Domain.Commands.Voto.Output;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Handlers
{
    public class VotoHandler : Notifiable, ICommandHandler<AdicionarVotoCommand>
    {
        private readonly IVotoRepository _repository;

        public VotoHandler(IVotoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new AdicionarVotoCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                if (_repository.CheckJaVotou(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "Esse Usuário ja votou!");
                    return new AdicionarVotoCommandResult(false, "Corrija as inconsistências abaixo", Notifications);

                }
                if (!_repository.CheckIdUsuarioExiste(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "IdUsuario não existe!");
                    return new AdicionarVotoCommandResult(false, "Corrija as inconsistências abaixo", Notifications);

                }
                if (!_repository.CheckIdFilmeExiste(command.IdFilme))
                {
                    AddNotification("IdFilme", "IdFilme não existe!");
                    return new AdicionarVotoCommandResult(false, "Corrija as inconsistências abaixo", Notifications);

                }

                long id = 0;
                long idusuario= command.IdUsuario;
                long idfilme = command.IdFilme;

                Voto voto = new Voto(0, idusuario, idfilme);

                id = _repository.Inserir(voto);

                var retorno = new AdicionarVotoCommandResult(true, "Voto computado com sucesso", new
                {
                    Id = id,
                    IdUsuario = voto.IdUsuario,
                    IdFilme = voto.IdFilme
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
