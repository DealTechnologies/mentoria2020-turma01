using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Usuario.Domain.Command.Usuario.Input;
using Usuario.Domain.Command.Usuario.Output;
using Usuario.Domain.Entidades;
using Usuario.Domain.Interface.Commands;
using Usuario.Domain.Interface.Handlers;
using Usuario.Domain.Interface.Repositories;

namespace Usuario.Domain.Handlers
{
    public class UsuarioHandler : Notifiable, IUsuarioHandler

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
                if (!command.ValidarCommand())
                {
                    return new AdicionarUsuarioCommandResult(false, "Favor corrigir os Erros Abaixo", command.Notifications);
                }

                int id = 0;
                string nome = command.Nome;
                string cpf = command.CPF;
                string email = command.Email;
                string senha = command.Senha;

                UsuarioCad usuario = new UsuarioCad(0, nome, cpf, email, senha);

                id = _repository.Inserir(usuario);

                var retorno = new AdicionarUsuarioCommandResult(true, "Usuario cadastrado com sucesso", new
                {
                    Id = id,
                    Nome = nome,
                    CPF = cpf,
                    Email = email,
                    Senha = senha
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
                if (!command.ValidarCommand())
                {
                    return new AtualizarUsuarioCommandResult(false, "Favor corrigir os Erros Abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id, Id não cadastrado");
                    return new AtualizarUsuarioCommandResult(false, "Favor corrigir os Erros Abaixo", Notifications);
                }

                int id = command.Id;
                string nome = command.Nome;
                string cpf = command.CPF;
                string email = command.Email;
                string senha = command.Senha;

                UsuarioCad usuario = new UsuarioCad(id, nome, cpf, email, senha);

                _repository.Alterar(usuario);

                var retorno = new AtualizarUsuarioCommandResult(true, "Usuario Atualizado  com sucesso", new
                {
                    Id = id,
                    Nome = nome,
                    CPF = cpf,
                    Email = email,
                    Senha = senha
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
                    return new ApagarUsuarioCommandResult(false, "Favor corrigir os Erros Abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id, Id não cadastrado");
                    return new ApagarUsuarioCommandResult(false, "Favor corrigir os Erros Abaixo", Notifications);
                }

                int id = command.Id;

                _repository.Deletar(command.Id);

                var retorno = new ApagarUsuarioCommandResult(true, "Usuario Deletado com sucesso", new
                {
                    Id = id,

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
