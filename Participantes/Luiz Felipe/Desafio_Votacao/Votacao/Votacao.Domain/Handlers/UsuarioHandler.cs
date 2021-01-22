using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
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
                {
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");
                    return new AtualizarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

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
                {
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");
                    return new ApagarUsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

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
    }
}
