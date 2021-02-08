using AutoMapper;
using Flunt.Notifications;
using Locadora.Domain.Autenticacao;
using Locadora.Domain.Commands.Clientes.Inputs;
using Locadora.Domain.Commands.Clientes.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Queries;
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

                if (_unitOfWork.Clientes.CheckCpfAsync(command.Cpf).Result)
                    AddNotification("Cpf", "CPF já cadastrado.");

                if (Invalid)
                    return new AdicionarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                Cliente cliente = new Cliente(command.Nome, command.Senha, command.Rg, command.Cpf, command.Email, command.DataNascimentoConvertida);

                if (cliente.Invalid)
                    return new AdicionarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", cliente.Notifications);

                _unitOfWork.Clientes.InserirAsync(cliente);

                var retorno = new AdicionarClienteCommandResult(true, "Cliente gravado com sucesso!", new
                {
                    Id = cliente.GetId(),
                    cliente.Nome,
                    Senha = "******",
                    cliente.Rg,
                    CPF = cliente.Cpf.Numero,
                    cliente.Email.EnderecoEmail,
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

                if (!_unitOfWork.Clientes.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");

                if (Invalid)
                    return new AtualizarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                Cliente cliente = new Cliente(command.Id, command.Nome, command.Senha, command.Rg, command.Cpf, command.Email, command.DataNascimentoConvertida);
                cliente.AtribuirEndereco(command.Cep, command.Rua, command.Numero, command.Complemento, command.Cidade, command.Estado, command.Pais);

                if (cliente.Invalid)
                    return new AtualizarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", cliente.Notifications);

                _unitOfWork.Clientes.AlterarAsync(cliente);

                var clienteResult = _mapper.Map<ClienteQueryResult>(cliente);

                var retorno = new AtualizarClienteCommandResult(true, "Cliente atualizado com sucesso!", new
                {
                    Id = cliente.GetId(),
                    cliente.Nome,
                    Senha = "******",
                    cliente.Rg,
                    CPF = cliente.Cpf.Numero,
                    cliente.Email.EnderecoEmail,
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

                if (!_unitOfWork.Clientes.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", "Id inválido. Este id não está cadastrado.");

                if (Invalid)
                    return new ApagarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                _unitOfWork.Clientes.DeletarAsync(command.Id);

                return new ApagarClienteCommandResult(true, "Cliente Apagado com sucesso!",
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

                if (Invalid)
                    return new AutenticarClienteCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

                var cliente = _unitOfWork.Clientes.ObterPorCpfAsync(command.Cpf).Result;

                var token = _tokenService.GenerateToken(cliente);

                var clienteResult = _mapper.Map<ClienteQueryResult>(cliente);

                return new AutenticarClienteCommandResult(true, "Usuário Autenticado com sucesso",
                    new
                    {
                        clienteResult.Id,
                        clienteResult.Cpf,
                        clienteResult.Nome,
                        clienteResult.Role,
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