using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;
using Votacao.Infra.DataContexts;

namespace Votacao.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<long> InserirAsync(Filme filme)
        {
            try
            {
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretor", filme.Diretor, DbType.String);

                var sql = @"INSERT INTO Filme (Titulo, Diretor) VALUES (@Titulo, @Diretor); SELECT SCOPE_IDENTITY();";

                return await _dataContext.SQLConnection.ExecuteScalarAsync<long>(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AlterarAsync(Filme filme)
        {
            try
            {
                _parametros.Add("Id", filme.Id, DbType.Int64);
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretor", filme.Diretor, DbType.String);

                var sql = @"UPDATE Filme SET Titulo=@Titulo, Diretor=@Diretor WHERE Id=@Id;";

                await _dataContext.SQLConnection.ExecuteAsync(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeletarAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"DELETE FROM Filme WHERE Id=@Id;";

                await _dataContext.SQLConnection.ExecuteAsync(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<FilmeQueryResult>> ListarAsync()
        {
            try
            {
                var sql = @"SELECT * FROM Filme ORDER BY Titulo;";

                var result = await _dataContext.SQLConnection.QueryAsync<FilmeQueryResult>(sql);

                return result.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<FilmeQueryResult> ObterPorIdAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                var result = await _dataContext.SQLConnection.QueryAsync<FilmeQueryResult>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CheckIdAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                var result = await _dataContext.SQLConnection.QueryAsync<bool>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
