using AutoMapper;
using Flunt.Notifications;
using System;
using System.Linq;
using Votacao.Domain.Autenticacao;
using Votacao.Domain.Commands.Usuario.Inputs;
using Votacao.Domain.Commands.Usuario.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Domain.Handlers
{
    public class UsuarioHandler : Notifiable, ICommandHandler<AdicionarUsuarioCommand>,
                                                ICommandHandler<AtualizarUsuarioCommand>,
                                                ICommandHandler<ApagarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioHandler(IUsuarioRepository usuarioRepository,
                                IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public ICommandResult Handler(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (_usuarioRepository.CheckLoginAsync(command.Login).Result)
                    AddNotification("Login", Avisos.Login_ja_existente_Por_favor_tente_um_login_diferente);

                if (Notifications.Count() > 0)
                    return new AdicionarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                long id = 0;
                Usuario usuario = new Usuario(id, command.Nome, command.Login, command.Senha, command.Role);

                id = _usuarioRepository.InserirAsync(usuario).Result;

                return new AdicionarUsuarioCommandResult(true, Avisos.Usuario_Gravado_com_sucesso,
                    new
                    {
                        Id = id,
                        Nome = usuario.Login,
                        Role = usuario.Role,
                        Senha = "******"
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AtualizarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_usuarioRepository.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (Notifications.Count() > 0)
                    return new AtualizarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                Usuario usuario = new Usuario(command.Id, command.Nome, command.Login, command.Senha, command.Role);

                _usuarioRepository.AlterarAsync(usuario);

                return new AdicionarUsuarioCommandResult(true, Avisos.Usuario_Atualizado_com_sucesso,
                    new
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Login = usuario.Login,
                        Role = usuario.Role,
                        Senha = "******"
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(ApagarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new ApagarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_usuarioRepository.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (Notifications.Count() > 0)
                    return new ApagarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                _usuarioRepository.DeletarAsync(command.Id);

                return new ApagarUsuarioCommandResult(true, Avisos.Usuario_Apagado_com_sucesso,
                    new
                    {
                        Id = command.Id
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(AutenticarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AutenticarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_usuarioRepository.CheckAutenticacaoAsync(command.Login, command.Senha).Result)
                    AddNotification("Autenticação", Avisos.Login_ou_Senha_invalidos);

                if (Notifications.Count() > 0)
                    return new AutenticarUsuarioCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                var usuarioResult = _usuarioRepository.ObterPorLoginAsync(command.Login).Result;
                var usuario = _mapper.Map<Usuario>(usuarioResult);

                var token = TokenService.GenerateToken(usuario);

                return new AutenticarUsuarioCommandResult(true, Avisos.Usuario_Autenticado_com_sucesso,
                    new
                    {
                        Login = usuario.Login,
                        Role = usuario.Role,
                        Token = token
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
