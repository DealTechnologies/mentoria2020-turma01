using AutoMapper;
using Flunt.Notifications;
using Locadora.Domain.Autenticacao;
using Locadora.Domain.Commands.Clientes.Inputs;
using Locadora.Domain.Commands.Clientes.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Linq;

namespace Locadora.Domain.Handlers
{
    public class ClienteHandler : Notifiable, ICommandHandler<AdicionarClienteCommand>,
                                            ICommandHandler<AtualizarClienteCommand>,
                                            ICommandHandler<ApagarClienteCommand>,
                                            ICommandHandler<AutenticarClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public ClienteHandler(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public ICommandResult Handler(AdicionarClienteCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (_unitOfWork.Clientes.CheckLoginAsync(command.Cpf).Result)
                    AddNotification("Cpf", "CPF já cadastrado.");

                if (Invalid)
                    return new AdicionarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                Cliente cliente = new Cliente(command.Nome, command.Senha, command.Rg, command.Cpf, command.Email, command.DataNascimentoConvertida);

                if (cliente.Invalid)
                    return new AdicionarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", cliente.Notifications);

                _unitOfWork.Clientes.InserirAsync(cliente);

                var retorno = new AdicionarClienteCommandResult(true, "Cliente gravado com sucesso!", new
                {
                    cliente.Nome,
                    Senha = "******",
                    cliente.Rg,
                    cliente.Cpf,
                    cliente.Email,
                    cliente.DataNascimento,
                    cliente.Role
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handler(AtualizarClienteCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AtualizarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                Cliente cliente = new Cliente(command.Id, command.Nome, command.Senha, command.Rg, command.Cpf, command.Email, command.DataNascimentoConvertida);

                if (cliente.Invalid)
                    return new AtualizarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", cliente.Notifications);

                _unitOfWork.Clientes.AlterarAsync(cliente);

                var retorno = new AtualizarClienteCommandResult(true, "Cliente atualizado com sucesso!", new
                {
                    cliente.Nome,
                    Senha = "******",
                    cliente.Rg,
                    cliente.Cpf,
                    cliente.Email,
                    cliente.DataNascimento,
                    cliente.Role
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handler(ApagarClienteCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new ApagarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (Notifications.Count() > 0)
                    return new ApagarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _unitOfWork.Clientes.DeletarAsync(command.Id);

                return new ApagarClienteCommandResult(true, "Usuario Apagado com sucesso!",
                    new
                    {
                        command.Id
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(AutenticarClienteCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AutenticarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_unitOfWork.Clientes.CheckAutenticacaoAsync(command.Cpf, command.Senha).Result)
                    AddNotification("Autenticação", "CPF ou Senha inválidos");

                if (Notifications.Count() > 0)
                    return new AutenticarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                var usuarioResult = _unitOfWork.Clientes.ObterPorLoginAsync(command.Cpf).Result;
                var usuario = _mapper.Map<Cliente>(usuarioResult);

                var token = _tokenService.GenerateToken(usuario);

                return new AutenticarClienteCommandResult(true, "Usuário Autenticado com sucesso",
                    new
                    {
                        usuario.Cpf,
                        usuario.Nome,
                        usuario.Role,
                        token
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}