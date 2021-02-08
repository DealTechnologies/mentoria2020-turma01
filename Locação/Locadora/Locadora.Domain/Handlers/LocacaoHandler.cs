using AutoMapper;
using Flunt.Notifications;
using Locadora.Domain.Autenticacao;
using Locadora.Domain.Commands.Locacoes.Inputs;
using Locadora.Domain.Commands.Locacoes.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
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

        public LocacaoHandler(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
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

            Locacao locacao = new Locacao(cliente, command.Equipamentos, command.DataLocacaoConvertida, command.DataDevolucaoConvertida, command.ValorFrete, command.ValorAluguel, command.ValorTotal);

            if (locacao.Invalid)
                return new AdicionarLocacaoCommandResult(false, "Por favor, corrija as inconsistências abaixo", locacao.Notifications);

            _unitOfWork.Locacoes.InserirAsync(locacao);

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