using Flunt.Notifications;
using Locadora.Domain.Commands.Equipamentos.Inputs;
using Locadora.Domain.Commands.Equipamentos.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using System;

namespace Locadora.Domain.Handlers
{
    public class EquipamentoHandler : Notifiable, ICommandHandler<AdicionarEquipamentoCommand>,
                                            ICommandHandler<AtualizarEquipamentoCommand>,
                                            ICommandHandler<ApagarEquipamentoCommand>
    {
        private readonly IUnitOfWork _unitofwork;

        public EquipamentoHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public ICommandResult Handler(AdicionarEquipamentoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarEquipamentoCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                string nome = command.Nome;
                string descricao = command.Descricao;
                string cor = command.Cor;
                string modelo = command.Modelo;
                double saldoEstoque = command.SaldoEstoque;
                double valorDiaria = command.ValorDiaria;

                Equipamento equipamento = new Equipamento(Guid.Empty, nome, descricao, cor, modelo, saldoEstoque, valorDiaria);

                _unitofwork.Equipamentos.InserirAsync(equipamento);

                var retorno = new AdicionarEquipamentoCommandResult(true, "Livro gravado com sucesso!", new
                {
                    Id = equipamento.Id,
                    Nome = equipamento.Nome,
                    Descricao = equipamento.Descricao,
                    Cor = equipamento.Cor,
                    Modelo = equipamento.Modelo,
                    SaldoEstoque = equipamento.SaldoEstoque,
                    ValorDiaria = equipamento.ValorDiaria
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handler(AtualizarEquipamentoCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handler(ApagarEquipamentoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}