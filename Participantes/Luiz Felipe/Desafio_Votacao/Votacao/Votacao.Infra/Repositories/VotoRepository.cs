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
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<long> InserirAsync(Voto voto)
        {
            try
            {
                _parametros.Add("IdUsuario", voto.IdUsuario, DbType.Int64);
                _parametros.Add("IdFilme", voto.IdFilme, DbType.Int64);

                var sql = @"INSERT INTO Voto (IdUsuario, IdFilme) VALUES (@IdUsuario, @IdFilme); SELECT SCOPE_IDENTITY();";

                return await _dataContext.SQLConnection.ExecuteScalarAsync<long>(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<VotoQueryResult>> ListarVotosAsync()
        {
            try
            {
                var sql = @"SELECT 
	                             v.Id
	                            ,u.Id
	                            ,u.Nome
	                            ,u.Login
	                            ,u.Senha
	                            ,u.Perfil
	                            ,f.Id
	                            ,f.Titulo
	                            ,f.Diretor
                            FROM Voto v
                            INNER JOIN Usuario u ON v.IdUsuario = u.Id
                            INNER JOIN Filme f ON v.IdFilme = f.Id
                            ORDER BY v.Id ASC;";

                var result = await _dataContext.SQLConnection.QueryAsync<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;

                            return voto;
                        },
                        splitOn: "Id, Id, Id");

                return result.Distinct().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CheckUsuarioVotouAsync(long idUsuario)
        {
            try
            {
                _parametros.Add("IdUsuario", idUsuario, DbType.Int64);

                var sql = @"SELECT * FROM Usuario u
                            INNER JOIN Voto v ON v.IdUsuario = u.Id
                            WHERE v.IdUsuario=@IdUsuario;";

                var result = await _dataContext.SQLConnection.QueryAsync<bool>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<VotoQueryResult> ObterVotoAsync(long id)
        {
            try
            {
                var sql = @"SELECT 
	                             v.Id
	                            ,u.Id
	                            ,u.Nome
	                            ,u.Login
	                            ,u.Senha
	                            ,u.Perfil
	                            ,f.Id
	                            ,f.Titulo
	                            ,f.Diretor
                            FROM Voto v
                            INNER JOIN Usuario u ON v.IdUsuario = u.Id
                            INNER JOIN Filme f ON v.IdFilme = f.Id
                            WHERE v.Id = @id;";

                var result = await _dataContext.SQLConnection.QueryAsync<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;

                            return voto;
                        },
                        new { Id = id },
                        splitOn: "Id, Id, Id");

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
