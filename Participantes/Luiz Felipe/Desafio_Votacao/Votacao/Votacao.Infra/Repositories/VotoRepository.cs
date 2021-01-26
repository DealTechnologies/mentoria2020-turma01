using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

        public List<VotoQueryResult> Listar()
        {
            try
            {
                var sql = @"SELECT * FROM Voto ORDER BY Id;";

                return _dataContext.SQLConnection.Query<VotoQueryResult>(sql).ToList();
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

        public bool CheckIdFilme(long idFilme)
        {
            try
            {
                _parametros.Add("Id", idFilme, DbType.Int64);

                var sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                return _dataContext.SQLConnection.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckIdUsuario(long idUsuario)
        {
            try
            {
                _parametros.Add("Id", idUsuario, DbType.Int64);

                var sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                return _dataContext.SQLConnection.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
