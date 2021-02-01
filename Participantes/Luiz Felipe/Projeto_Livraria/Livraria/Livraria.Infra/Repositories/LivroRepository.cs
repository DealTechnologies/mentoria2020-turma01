using AutoMapper;
using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Livraria.Infra.DataContexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LivroRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<string> InserirAsync(Livro livro)
        {
            try
            {
                var livroQueryResult = _mapper.Map<LivroQueryResult>(livro);
                await _dataContext.Livros.InsertOneAsync(livroQueryResult);

                return livroQueryResult.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AlterarAsync(Livro livro)
        {
            try
            {
                var livroQueryResult = _mapper.Map<LivroQueryResult>(livro);

                Expression<Func<LivroQueryResult, bool>> filter =
                    x => x.Id.Equals(livroQueryResult.Id);

                var livroresult = await _dataContext.Livros.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (livroresult != null)
                    await _dataContext.Livros.ReplaceOneAsync(filter, livroQueryResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarAsync(string id)
        {
            try
            {
                Expression<Func<LivroQueryResult, bool>> filter =
                    x => x.Id.Equals(id);

                await _dataContext.Livros.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LivroQueryResult>> ListarAsync()
        {
            try
            {
                return await _dataContext.Livros.FindAsync(_ => true).Result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LivroQueryResult> ObterPorIdAsync(string id)
        {
            try
            {
                Expression<Func<LivroQueryResult, bool>> filter =
                    x => x.Id.Equals(id);

                return await _dataContext.Livros.FindAsync(filter).Result.FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckIdAsync(string id)
        {
            try
            {
                Expression<Func<LivroQueryResult, bool>> filter =
                    x => x.Id.Equals(id);

                var livroResult = await _dataContext.Livros.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (livroResult != null)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
