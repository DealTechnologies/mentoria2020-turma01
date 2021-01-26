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
                    return new VotarCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_usuarioRepository.CheckId(command.IdUsuario))
                    AddNotification("IdUsuario", "IdUsuario inválido. Este Usuario não está cadastrado.");

                if (!_filmeRepository.CheckId(command.IdFilme))
                    AddNotification("IdFilme", "IdFilme inválido. Este Filme não está cadastrado.");

                if (_votoRepository.CheckUsuarioVotou(command.IdUsuario))
                    AddNotification("IdUsuario", "Esse usuário já votou.");

                if (Notifications.Count() > 0)
                    return new VotarCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                long id = 0;
                Voto voto = new Voto(id, command.IdUsuario, command.IdFilme);

                _votoRepository.Inserir(voto);

                var usuario = _usuarioRepository.ObterPorId(command.IdUsuario);
                var filme = _filmeRepository.ObterPorId(command.IdFilme);

                return new VotarCommandResult(true, "Voto realizado com sucesso!",
                    new
                    {
                        Usuario = new { 
                            usuario.Id,
                            usuario.Nome,
                            usuario.Login,
                            Senha = "******"
                        },
                        Filme = new { 
                            filme.Id,
                            filme.Titulo,
                            filme.Diretor
                        },
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
