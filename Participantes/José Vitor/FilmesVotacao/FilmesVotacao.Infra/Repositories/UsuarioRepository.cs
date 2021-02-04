using Dapper;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Usuario;
using FilmesVotacao.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FilmesVotacao.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _datacontext;

        public UsuarioRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                string sql = @"SELECT * FROM Usuario ORDER BY Nome;";

                return _datacontext.SQLServerConexao.Query<UsuarioQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioQueryResult ObterPorId(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);
                string sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                return _datacontext.SQLServerConexao.Query<UsuarioQueryResult>(sql, _parametros).FirstOrDefault();
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
                string sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                return _datacontext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Inserir(Usuario usuario)
        {
            try
            {
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login, DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"INSERT INTO Usuario (Nome, Login, Senha) Values (@Nome, @Login, @Senha); SELECT SCOPE_IDENTITY();";
                
                return _datacontext.SQLServerConexao.ExecuteScalar<long>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(Usuario usuario)
        {
            try
            {
                _parametros.Add("Id", usuario.Id, DbType.Int64);
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login, DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha WHERE Id=@Id;";

                _datacontext.SQLServerConexao.Execute(sql, _parametros);
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

                string sql = @"DELETE FROM Usuario WHERE Id=@Id;";

                _datacontext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckLogin(string login, string senha)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);
                _parametros.Add("Senha", senha, DbType.String);
                string sql = @"SELECT * FROM Usuario WHERE Login=@Login AND Senha=@Senha;";

                return _datacontext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
