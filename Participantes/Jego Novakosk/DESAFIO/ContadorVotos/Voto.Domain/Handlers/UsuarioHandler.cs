﻿using Flunt.Notifications;
using System;
using Voto.Domain.Commands.Usuario.Input;
using Voto.Domain.Commands.Usuario.Output;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;

namespace Voto.Domain.Handlers
{
    public class UsuarioHandler : Notifiable, IUsuarioHandler


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
                {
                    return new AdicionarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                int id = 0;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(0, nome, login, senha);

                id = _usuarioRepository.InserirUsuario(usuario);

                var retorno = new AdicionarUsuarioCommandResult(true, "Usuario adicionado com sucesso!", new
                {
                    Id = id,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                });

                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handler(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AtualizarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_usuarioRepository.CheckUsuarioId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Id não cadastrado");
                    return new AtualizarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                int id = command.Id;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                _usuarioRepository.AlterarUsuario(usuario);

                var retorno = new AtualizarUsuarioCommandResult(true, "Usuario Atulizado com sucesso!", new
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
                if (!command.ValidarCommand())
                {
                    return new ApagarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_usuarioRepository.CheckUsuarioId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Id não cadastrado");
                    return new ApagarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                _usuarioRepository.DeletarUsuario(command.Id);

                var retorno = new ApagarUsuarioCommandResult(true, "Usuario Apagado com sucesso", new
                {
                    Id = command.Id
                });
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handler(LoginUsuarioCommand command)
        {
            if (!command.ValidarCommand())
            {
                return new LoginUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
            }
            if (!_usuarioRepository.ValidarLogin(command.Login, command.Senha))
            {
                AddNotification("Login", "Login Invalido. Usuario  não cadastrado");
                return new ApagarUsuarioCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
            }

            _usuarioRepository.ValidarLogin(command.Login, command.Senha);

            var retorna = new LoginUsuarioCommandResult(true, "Usuario Logado", new
            {
                login = true
            });

            return retorna;
        }
    }
}
