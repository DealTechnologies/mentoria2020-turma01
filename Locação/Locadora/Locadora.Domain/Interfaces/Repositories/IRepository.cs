using Locadora.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : Entity
    {
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ListarAsync();
        Task<Guid> InserirAsync(TEntity entity);
        Task AlterarAsync(TEntity entity);
        Task DeletarAsync(Guid id);
    }
}
