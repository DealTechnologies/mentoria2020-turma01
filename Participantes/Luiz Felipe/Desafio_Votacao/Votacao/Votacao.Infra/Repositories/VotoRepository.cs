using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public long Inserir(Voto voto)
        {
            try
            {
                _parametros.Add("IdUsuario", voto.IdUsuario, DbType.Int64);
                _parametros.Add("IdFilme", voto.IdFilme, DbType.Int64);

                var sql = @"INSERT INTO Voto (IdUsuario, IdFilme) VALUES (@IdUsuario, @IdFilme); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLConnection.ExecuteScalar<long>(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VotoQueryResult> ListarVotos()
        {
            try
            {
                var sql = @"SELECT 
	                             v.Id
	                            ,u.Id
	                            ,u.Nome
	                            ,u.Login
	                            ,u.Senha
	                            ,f.Id
	                            ,f.Titulo
	                            ,f.Diretor
                            FROM Voto v
                            INNER JOIN Usuario u ON v.IdUsuario = u.Id
                            INNER JOIN Filme f ON v.IdFilme = f.Id
                            ORDER BY v.Id ASC;";

                return _dataContext.SQLConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;

                            return voto;
                        },
                        splitOn: "Id, Id, Id").Distinct().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckUsuarioVotou(long idUsuario)
        {
            try
            {
                _parametros.Add("IdUsuario", idUsuario, DbType.Int64);

                var sql = @"SELECT * FROM Usuario u
                            INNER JOIN Voto v ON v.IdUsuario = u.Id
                            WHERE v.IdUsuario=@IdUsuario;";

                return _dataContext.SQLConnection.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VotoQueryResult ObterVoto(long id)
        {
            try
            {
                var sql = @"SELECT 
	                             v.Id
	                            ,u.Id
	                            ,u.Nome
	                            ,u.Login
	                            ,u.Senha
	                            ,f.Id
	                            ,f.Titulo
	                            ,f.Diretor
                            FROM Voto v
                            INNER JOIN Usuario u ON v.IdUsuario = u.Id
                            INNER JOIN Filme f ON v.IdFilme = f.Id
                            WHERE v.Id = @id;";

                return _dataContext.SQLConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;

                            return voto;
                        },
                        new { Id = id },
                        splitOn: "Id, Id, Id").FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
