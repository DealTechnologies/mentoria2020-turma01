using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Context;
        protected readonly IMongoCollection<TEntity> Collection;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            var data = await Collection.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> ListarAsync()
        {
            var all = await Collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<Guid> InserirAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity.GetId();
        }

        public virtual async Task AlterarAsync(TEntity entity)
        {
            await Collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity);
        }

        public virtual async Task DeletarAsync(Guid id)
        {
            await Collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
        }
    }
}
