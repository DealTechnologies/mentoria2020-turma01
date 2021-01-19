using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Livraria.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Livraria.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Livro livro)
        {
            try
            {
                _parametros.Add("Nome", livro.Nome, DbType.String);
                _parametros.Add("Autor", livro.Autor, DbType.String);
                _parametros.Add("Edicao", livro.Edicao, DbType.Int32);
                _parametros.Add("Isbn", livro.Isbn, DbType.String);
                _parametros.Add("Imagem", livro.Imagem, DbType.String);

                string sql = @"INSERT INTO Livro VALUES(Nome, Autor, Edicao, Isbn, Imagem) VALUES (@Nome, @Autor, @Edicao, @Isbn, @Imagem); SELECT SCOPE_IDENTITY();";

                //return _dataContext.SQLServerConexao.ExecuteScalar<long>(sql, new { Nome = livro.Nome });
                return _dataContext.SQLServerConexao.ExecuteScalar<long>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Livro livro)
        {
            try
            {
                _parametros.Add("Id", livro.Nome, DbType.Int64);
                _parametros.Add("Nome", livro.Nome, DbType.String);
                _parametros.Add("Autor", livro.Autor, DbType.String);
                _parametros.Add("Edicao", livro.Edicao, DbType.Int32);
                _parametros.Add("Isbn", livro.Isbn, DbType.String);
                _parametros.Add("Imagem", livro.Imagem, DbType.String);

                string sql = @"UPDATE Livro SET Nome=@Nome, Autor=@Autor, Edicao=@Edicao, Isbn=@Isbn, Imagem=@Imagem WHERE Id=@Id;";
                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                string sql = @"DELETE FROM Livro WHERE Id=@Id;";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroQueryResult> Listar()
        {
            try
            {
                string sql = @"SELECT * FROM Livro ORDER BY Nome;";

                return _dataContext.SQLServerConexao.Query<LivroQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroQueryResult ObterPorId(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                string sql = @"SELECT * FROM Livro WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<LivroQueryResult>(sql).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                string sql = @"SELECT * FROM Livro WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
