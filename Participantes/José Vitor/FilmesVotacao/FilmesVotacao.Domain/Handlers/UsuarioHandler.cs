using FilmesVotacao.Domain.Commands.Usuario.Input;
using FilmesVotacao.Domain.Commands.Usuario.Output;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Handlers
{
    public class UsuarioHandler : Notifiable, ICommandHandler<AdicionarUsuarioCommand>,
                                              ICommandHandler<AtualizarUsuarioCommand>,
                                              ICommandHandler<ApagarUsuarioCommand>,
                                              ICommandHandler<LogarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new AdicionarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(0, nome, login, senha);

                id = _repository.Inserir(usuario);

                var retorno = new AdicionarUsuarioCommandResult(true, "Usuário gravado com sucesso", new
                {
                    Id = id,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                });
                return retorno;
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
                if (!command.Valid)
                    return new AtualizarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inexistente");
                    return new AtualizarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", Notifications);
                }

                long id = command.Id;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                _repository.Alterar(usuario);

                var retorno = new AtualizarUsuarioCommandResult(true, "Usuário atualizado com sucesso", new
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                });
                return retorno;
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
                if (!command.Valid)
                    return new ApagarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inexistente");
                    return new ApagarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", Notifications);
                }

                _repository.Deletar(command.Id);

                var retorno = new ApagarUsuarioCommandResult(true, "Usuário atualizado com sucesso", new
                {
                    Id = command.Id,
                });
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handler(LogarUsuarioCommand command)
        {
            try
            {
                if (!command.Valid)
                    return new ApagarUsuarioCommandResult(false, "Corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckLogin(command.Login, command.Senha))
                {
                    return new ApagarUsuarioCommandResult(false, "Login ou senha incorretos", Notifications);
                }

                var retorno = new ApagarUsuarioCommandResult(true, "Usuário Logado com sucesso", new
                {
                    Login = command.Login,
                    Senha = command.Senha
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
