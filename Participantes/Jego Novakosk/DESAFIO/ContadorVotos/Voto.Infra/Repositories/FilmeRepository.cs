using System.Collections.Generic;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Filme;
using Dapper;
using Voto.Infra.DataContexts;
using System;
using System.Data;
using System.Linq;

namespace Voto.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContexts;

        public FilmeRepository(DataContext dataContexts)
        {
            _dataContexts = dataContexts;
        }

        public void Alterar(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.Id, DbType.Int32);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"UPDATE Filme SET Titulo=@Titulo, Diretor=@Diretor WHERE Id=@Id";

                 _dataContexts.SQLServerConnection.Execute(sql, _parameters);
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


                string sql = @"SELECT id FROM Filme WHERE Id=@Id";

                return _dataContexts.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
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
                

                string sql = @"DELETE FROM Filme WHERE Id=@Id";

                _dataContexts.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Inserir(Filme filme)
        {
            try
            {
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"INSERT INTO Filme (Titulo, Diretor) VALUES (@Titulo, @Diretor) SELECT SCOPE_IDENTITY()";

                return _dataContexts.SQLServerConnection.ExecuteScalar<int>(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {
               
                string sql = @"SELECT * FROM Filme ORDER BY Titulo";

                return _dataContexts.SQLServerConnection.Query<FilmeQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FilmeQueryResult ObterPorId(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"SELECT * FROM Filme WHERE Id=@Id";

               return _dataContexts.SQLServerConnection.Query<FilmeQueryResult>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
