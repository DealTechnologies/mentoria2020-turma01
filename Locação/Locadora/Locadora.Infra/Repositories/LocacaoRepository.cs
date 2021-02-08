using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;

namespace Locadora.Infra.Repositories
{
    public class LocacaoRepository : BaseRepository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(DataContext context) : base(context) { }
    }
}
