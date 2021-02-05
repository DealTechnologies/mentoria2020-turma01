using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Usuario;
using Votacao.Domain.ValueObjects;
using Votacao.Infra.DataContexts;

namespace Votacao.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        private readonly DynamicParameters _parametros = new DynamicParameters();

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Salvar(Usuario usuario)
        {
            try
            {
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login.ToString(), DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"INSERT INTO Usuario (Nome, Login, Senha) VALUES(@Nome, @Login, @Senha); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLServerConexao.ExecuteScalar<int>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parametros.Add("Id", usuario.Id, DbType.Int32);
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login.ToString(), DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha WHERE Id=@Id";

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

                string sql = @"DELETE FROM Usuario WHERE Id = @Id";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioQueryResult Obter(int id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int32);

                string sql = @"SELECT * FROM Usuario WHERE Id = @Id ";

                return _dataContext.SQLServerConexao.Query<UsuarioQueryResult>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                string sql = @"SELECT * FROM Usuario ORDER BY Id ASC ";

                return _dataContext.SQLServerConexao.Query<UsuarioQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioQueryResult Logar(string login, string senha)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);
                _parametros.Add("Senha", senha, DbType.String);

                string sql = @"SELECT * FROM Usuario WHERE Login=@Login and Senha=@Senha";

                return _dataContext.SQLServerConexao.Query<UsuarioQueryResult>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckLogin(string login)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);

                string sql = @"SELECT Login FROM Usuario WHERE Login=@Login";

                string retono = _dataContext.SQLServerConexao.Query<string>(sql, _parametros).FirstOrDefault();

                return retono != null ? true : false;
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

                string sql = @"SELECT Id FROM Usuario WHERE Id=@Id ";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}