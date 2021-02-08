using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(DataContext context) : base(context){}

        public async Task<bool> CheckIdAsync(Guid id)
        {
            try
            {
                Expression<Func<Equipamento, bool>> filter =
                    x => x.Id.Equals(id);

                var equipamentoResult = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (equipamentoResult != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
