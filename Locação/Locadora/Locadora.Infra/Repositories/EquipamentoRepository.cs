using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;
using MongoDB.Driver;

namespace Locadora.Infra.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(DataContext context) : base(context){}
    }
}
