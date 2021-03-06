﻿using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Livraria.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public void Alterar(Livro livro)
        {
            try
            {
                _parametros.Add("Id", livro.Id, DbType.Int64);
                _parametros.Add("Nome", livro.Nome, DbType.String);
                _parametros.Add("Autor", livro.Autor, DbType.String);
                _parametros.Add("Edicao", livro.Edicao, DbType.Int32);
                _parametros.Add("Isbn", livro.Isbn, DbType.String);
                _parametros.Add("Imagem", livro.Imagem, DbType.String);

                string sql = @"UPDATE LIVRO
                                SET Nome = @Nome, Autor = @Autor, Edicao = @Edicao, Isbn = @Isbn, Imagem = @Imagem
                                WHERE Id = @Id;" ;

                _dataContext.SqlServerConexao.Execute(sql, _parametros);
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

                string sql = @"SELECT Id FROM LIVRO WHERE Id = @Id;";

                return _dataContext.SqlServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
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

                string sql = @"DELETE FROM LIVRO WHERE Id = @Id;";

                _dataContext.SqlServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

                string sql = @"INSERT INTO Livro (Nome, Autor, Edicao, Isbn, Imagem) 
                               VALUES (@Nome, @Autor, @Edicao, @Isbn, @Imagem);
                               SELECT SCOPE_IDENTITY();";

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(sql, _parametros);
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
                string sql = @"SELECT * FROM LIVRO ORDER BY NOME;";

                return _dataContext.SqlServerConexao.Query<LivroQueryResult>(sql).ToList();
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

                string sql = @"SELECT * FROM LIVRO WHERE Id = @Id;";

                return _dataContext.SqlServerConexao.Query<LivroQueryResult>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}