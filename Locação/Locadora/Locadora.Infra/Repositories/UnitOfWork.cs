using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;

namespace Locadora.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext Context;
        private ClienteRepository _clientes;
        private EquipamentoRepository _equipamentos;
        private LocacaoRepository _locacoes;

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }

        public IClienteRepository Clientes
        {
            get
            {
                return _clientes ??
                    (_clientes = new ClienteRepository(Context));
            }
        }

        public IEquipamentoRepository Equipamentos
        {
            get
            {
                return _equipamentos ??
                    (_equipamentos = new EquipamentoRepository(Context));
            }
        }

        public ILocacaoRepository Locacoes
        {
            get
            {
                return _locacoes ??
                    (_locacoes = new LocacaoRepository(Context));
            }
        }
    }
}
