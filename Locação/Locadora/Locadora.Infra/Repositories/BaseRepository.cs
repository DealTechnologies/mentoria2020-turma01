using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.DataContexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Collection = Context.MongoDBConexao.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            try
            {
                return await Collection.FindAsync(Builders<TEntity>.Filter.Eq("_id", id)).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<TEntity>> ListarAsync()
        {
            try
            {
                return await Collection.FindAsync(Builders<TEntity>.Filter.Empty).Result.ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task InserirAsync(TEntity entity)
        {
            try
            {
                await Collection.InsertOneAsync(entity);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task AlterarAsync(TEntity entity)
        {
            try
            {
                await Collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeletarAsync(Guid id)
        {
            try
            {
                await Collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
