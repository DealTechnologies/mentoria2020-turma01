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

                Equipamento equipamento = new Equipamento(command.Nome, command.Descricao, command.Cor, command.Modelo, command.Imagem, command.SaldoEstoque, command.ValorDiaria);

                _unitofwork.Equipamentos.InserirAsync(equipamento);

                var retorno = new AdicionarEquipamentoCommandResult(true, "Equipamento gravado com sucesso!", new
                {
                    Id = equipamento.Id,
                    Nome = equipamento.Nome,
                    Descricao = equipamento.Descricao,
                    Cor = equipamento.Cor,
                    Modelo = equipamento.Modelo,
                    Imagem = equipamento.Imagem,
                    SaldoEstoque = equipamento.SaldoEstoque,
                    ValorDiaria = equipamento.ValorDiaria,
                    QuantidadeAlugado = equipamento.QuantidadeAlugado
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
            try
            {
                if (!command.ValidarCommand())
                    return new AtualizarEquipamentoCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_unitofwork.Equipamentos.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", "Id inválido. Este id não está cadastrado");
                
                if (Invalid)
                    return new AtualizarEquipamentoCommandResult(false, "Corrija as inconsistências abaixo", Notifications);
                
                
                Equipamento equipamento = new Equipamento(command.Id, command.Nome, command.Descricao, command.Cor, command.Modelo, command.Imagem, command.SaldoEstoque, command.ValorDiaria);

                _unitofwork.Equipamentos.AlterarAsync(equipamento);

                var retorno = new AtualizarEquipamentoCommandResult(true, "Equipamento atualizado com sucesso!", new
                {
                    Nome = equipamento.Nome,
                    Descricao = equipamento.Descricao,
                    Cor = equipamento.Cor,
                    Modelo = equipamento.Modelo,
                    Imagem = equipamento.Imagem,
                    SaldoEstoque = equipamento.SaldoEstoque,
                    ValorDiaria = equipamento.ValorDiaria,
                    QuantidadeAlugado = equipamento.QuantidadeAlugado
                }) ;

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handler(ApagarEquipamentoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new ApagarEquipamentoCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_unitofwork.Equipamentos.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", "Id inválido. Este id não está cadastrado");

                if (Invalid)
                    return new AtualizarEquipamentoCommandResult(false, "Corrija as inconsistências abaixo", Notifications);

                _unitofwork.Equipamentos.DeletarAsync(command.Id);

                return new ApagarEquipamentoCommandResult(true, "Usuario Apagado com sucesso!",
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