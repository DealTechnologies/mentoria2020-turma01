using Flunt.Notifications;
using System;
using Votacao.Domain.Commands;
using Votacao.Domain.Commands.Usuario.Input;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.ValueObjects;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Handlers
{
    public class UsuarioHandler : Notifiable, IUsuarioHandler
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                int id = 0;
                string nome = command.Nome;
                Email login = new Email(command.Login);
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                AddNotifications(login.Notifications);

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                id = _repository.Salvar(usuario);

                return new CommandResult(true, "Usuário gravado com sucesso!", new
                {
                    Id = id,
                    Nome = usuario.Nome,
                    Login = usuario.Login.ToString(),
                    Senha = usuario.Senha
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                int id = command.Id;
                string nome = command.Nome;
                Email login = new Email(command.Login);
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                AddNotifications(login.Notifications);

                if (usuario.Id == 0)
                    AddNotification("Id", "Id não está vinculado à operação solicitada");

                if (!_repository.CheckId(usuario.Id))
                    AddNotification("Id", "Este Id não está cadastrado! Impossível prosseguir com este Id.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _repository.Atualizar(usuario);

                return new CommandResult(true, "Usuário atualizado com sucesso!", new
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Login = usuario.Login.ToString(),
                    Senha = usuario.Senha
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public ICommandResult Handle(ApagarUsuarioCommand command)
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

                return new CommandResult(true, "Usuário excluído com sucesso!", new { Id = command.Id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(LogarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                string login = command.Login;
                string senha = command.Senha;

                if (!_repository.CheckLogin(login))
                    AddNotification("Login", "Este Login não está cadastrado! Impossível prosseguir com este Login.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                var usuarioQR = _repository.Logar(login, senha);

                if (usuarioQR == null)
                    AddNotification("Senha", "Senha incorreta.");

                if (Invalid)
                    return new CommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                return new CommandResult(true, "Usuário logado com sucesso!", usuarioQR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}