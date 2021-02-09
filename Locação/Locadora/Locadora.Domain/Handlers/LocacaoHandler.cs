using AutoMapper;
using Flunt.Notifications;
using Locadora.Domain.Autenticacao;
using Locadora.Domain.Commands.Locacoes.Inputs;
using Locadora.Domain.Commands.Locacoes.Outputs;
using Locadora.Domain.EmailConfs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Interfaces.Email;
using Locadora.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Domain.Handlers
{
    public class LocacaoHandler : Notifiable, ICommandHandler<AdicionarLocacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        private readonly IEmailSender _emailSender;

        public LocacaoHandler(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                TokenService tokenService,
                                IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailSender = emailSender;
        }

        public ICommandResult Handler(AdicionarLocacaoCommand command)
        {
            if (!command.ValidarCommand())
                return new AdicionarLocacaoCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

            if (!_unitOfWork.Clientes.CheckIdAsync(command.IdUsuario).Result)
                AddNotification("Id", "Id inválido. Este id não está cadastrado");

            if (Invalid)
                return new AdicionarLocacaoCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);

            var cliente = _unitOfWork.Clientes.ObterPorIdAsync(command.IdUsuario).Result;

            var listaEquipamentos = _mapper.Map<List<EquipamentoDto>, List<Equipamento>>(command.Equipamentos);

            Locacao locacao = new Locacao(cliente, listaEquipamentos, command.DataLocacaoConvertida, command.DataDevolucaoConvertida, command.ValorFrete, command.ValorAluguel, command.ValorTotal);

            if (locacao.Invalid)
                return new AdicionarLocacaoCommandResult(false, "Por favor, corrija as inconsistências abaixo", locacao.Notifications);

            var locacaoRealizada = _unitOfWork.Locacoes.InserirAsync(locacao).IsCompleted;

            if (locacaoRealizada)
            {
                string mensagemBody = MensagemEmail.EmailConfirmacaoLocacao(locacao);
                _emailSender.EnviarEmailAsync(cliente.Email.EnderecoEmail, "Locadora de Equipamentos", mensagemBody);
            }

            var locacaoResult = _mapper.Map<LocacaoQueryResult>(locacao);

            return new AdicionarLocacaoCommandResult(true, "Locacao realizada com sucesso",
                new
                {
                    IdCliente = locacaoResult.Cliente.Id,
                    locacaoResult.DataLocacao,
                    locacaoResult.DataDevolucao,
                    locacaoResult.ValorFrete,
                    locacaoResult.ValorAluguel,
                    locacaoResult.ValorTotal
                });
        }
    }
}