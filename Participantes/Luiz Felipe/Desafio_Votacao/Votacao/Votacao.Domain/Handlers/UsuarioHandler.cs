using Flunt.Notifications;
using System;
using System.Linq;
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

        public UsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handler(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                Usuario usuario = new Usuario(id, command.Nome, command.Login, command.Senha);

                id = _usuarioRepository.Inserir(usuario);

                return new AdicionarUsuarioCommandResult(true, "Usuario Gravado com sucesso!",
                    new
                    {
                        Id = id,
                        Nome = usuario.Login,
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
                    return new AtualizarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_usuarioRepository.CheckId(command.Id))
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");

                if (Notifications.Count() > 0)
                    return new AtualizarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                Usuario usuario = new Usuario(command.Id, command.Nome, command.Login, command.Senha);

                _usuarioRepository.Alterar(usuario);

                return new AdicionarUsuarioCommandResult(true, "Usuário Atualizado com sucesso!",
                    new
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Login = usuario.Login,
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
                    return new ApagarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_usuarioRepository.CheckId(command.Id))
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");

                if (Notifications.Count() > 0)
                    return new ApagarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _usuarioRepository.Deletar(command.Id);

                return new ApagarUsuarioCommandResult(true, "Usuario Apagado com sucesso!",
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
                    return new AutenticarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_usuarioRepository.CheckAutenticacao(command.Login, command.Senha))
                    AddNotification("Autenticação", "Login ou Senha inválidos.");

                if (Notifications.Count() > 0)
                    return new AutenticarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                return new AutenticarUsuarioCommandResult(true, "Usuário Autenticado com sucesso!",
                    new
                    {
                        Login = command.Login,
                        Senha = "******"
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
