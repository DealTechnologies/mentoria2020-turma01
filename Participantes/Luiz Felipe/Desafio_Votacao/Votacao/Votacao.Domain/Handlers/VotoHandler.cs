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
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public VotoHandler(IVotoRepository votoRepository, IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepository)
        {
            _votoRepository = votoRepository;
            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handler(VotarCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotarCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_usuarioRepository.CheckId(command.IdUsuario))
                    AddNotification("IdUsuario", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (!_filmeRepository.CheckId(command.IdFilme))
                    AddNotification("IdFilme", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (_votoRepository.CheckUsuarioVotou(command.IdUsuario))
                    AddNotification("IdUsuario", Avisos.Esse_usuario_ja_votou);

                if (Notifications.Count() > 0)
                    return new VotarCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                long id = 0;
                Voto voto = new Voto(id, command.IdUsuario, command.IdFilme);

                long idVoto = _votoRepository.Inserir(voto);
                var votoReturn = _votoRepository.ObterVoto(idVoto);

                return new VotarCommandResult(true, Avisos.Voto_realizado_com_sucesso, new { votoReturn });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
