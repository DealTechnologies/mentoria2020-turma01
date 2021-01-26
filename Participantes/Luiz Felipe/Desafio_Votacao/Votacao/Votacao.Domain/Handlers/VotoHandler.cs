using Flunt.Notifications;
using System;
using System.Linq;
using Votacao.Domain.Commands.Voto.Inputs;
using Votacao.Domain.Commands.Voto.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Domain.Handlers
{
    public class VotoHandler : Notifiable, ICommandHandler<VotarCommand>
    {
        private readonly IVotoRepository _votoRepository;

        public VotoHandler(IVotoRepository votoRepository)
        {
            _votoRepository = votoRepository;
        }

        public ICommandResult Handler(VotarCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotarCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_votoRepository.CheckIdUsuario(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "IdUsuario inválido. Este Usuario não está cadastrado.");
                }

                if (!_votoRepository.CheckIdFilme(command.IdFilme))
                {
                    AddNotification("IdFilme", "IdFilme inválido. Este Filme não está cadastrado.");
                }

                if (_votoRepository.CheckUsuarioVotou(command.IdUsuario))
                {
                    AddNotification("IdUsuario", "Esse usuário já votou.");
                }

                if (Notifications.Count() > 0)
                    return new VotarCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                long id = 0;
                Voto voto = new Voto(id, command.IdUsuario, command.IdFilme);

                _votoRepository.Inserir(voto);

                return new VotarCommandResult(true, "Voto realizado com sucesso!",
                    new
                    {
                        IdUsuario = voto.IdUsuario,
                        IdFilme = voto.IdFilme,
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
