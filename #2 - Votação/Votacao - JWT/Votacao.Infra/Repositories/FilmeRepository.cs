using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Filme;
using Votacao.Infra.DataContexts;

namespace Votacao.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DataContext _dataContext;
        private readonly DynamicParameters _parametros = new DynamicParameters();

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Salvar(Filme filme)
        {
            try
            {
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"INSERT INTO Filme (Titulo, Diretor) VALUES(@Titulo, @Diretor); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLServerConexao.ExecuteScalar<int>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Filme filme)
        {
            try
            {
                _parametros.Add("Id", filme.Id, DbType.Int32);
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"UPDATE Filme SET Titulo=@Titulo, Diretor=@Diretor WHERE Id=@Id";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
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
                _parametros.Add("Id", id, DbType.Int32);

                string sql = @"DELETE FROM Filme WHERE Id=@Id";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FilmeQueryResult Obter(int id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int32);

                string sql = @"SELECT * FROM Filme WHERE Id=@Id";

                return _dataContext.SQLServerConexao.Query<FilmeQueryResult>(sql, _parametros).FirstOrDefault();
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
                string sql = @"SELECT * FROM Filme ORDER BY Id ASC";

                return _dataContext.SQLServerConexao.Query<FilmeQueryResult>(sql).ToList();
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
                _parametros.Add("Id", id, DbType.Int32);

                string sql = @"SELECT Id FROM Filme WHERE Id=@Id";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}