using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Votos;
using Voto.Infra.DataContexts;
using System.Data;
using System.Linq;

namespace Voto.Infra.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Alterar(Votos votos)
        {
            try
            {
                _parameters.Add("Id", votos.Id, DbType.Int32);
                _parameters.Add("IdUsuario", votos.IdUsuario, DbType.Int32);
                _parameters.Add("IdFilme", votos.IdFilme, DbType.Int32);

                string sql = @"UPDATE Voto SET IdUsuario=@IdUsuario, IdFilme=@IdFilme WHERE Id=@Id ";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckId(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"SELECT id FROM Voto WHERE Id=@Id";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckIdUsuario(int id)
        {
            try
            {
                _parameters.Add("IdUsuario", id, DbType.Int32);


                string sql = @"SELECT id FROM Voto WHERE IdUsuario=@IdUsuario";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"DELETE FROM Voto WHERE Id=@Id";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Inserir(Votos votos)
        {
            try
            {
                _parameters.Add("IdUsuario", votos.IdUsuario, DbType.Int32);
                _parameters.Add("IdFilme", votos.IdFilme, DbType.Int32);

                string sql = @"INSERT INTO Voto (IdUsuario, IdFilme) VALUES (@IdUsuario, @IdFilme) SELECT SCOPE_IDENTITY()";

                return _dataContext.SQLServerConnection.ExecuteScalar<int>(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VotosQueryResult> Listar()
        {
            try
            {

                string sql = @"SELECT * FROM Voto ORDER BY Id";

                return _dataContext.SQLServerConnection.Query<VotosQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public VotosQueryResult ObterPorId(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"SELECT * FROM Voto WHERE Id=@Id";

                return _dataContext.SQLServerConnection.Query<VotosQueryResult>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
