using Locadora.Domain.Entidades;
using Locadora.Infra.DataContexts;
using MongoDB.Driver;

namespace Locadora.Infra.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>
    {
        public EquipamentoRepository(DataContext context) : base(context){}
    }
}
