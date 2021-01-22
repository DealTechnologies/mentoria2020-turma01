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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Usuario usuario)
        {
            try
            {
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login, DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);

                var sql = @"INSERT INTO Usuario (Nome, Login, Senha) VALUES (@Nome, @Login, @Senha); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLConnection.ExecuteScalar<long>(sql, _parametros);
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

                var sql = @"UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha WHERE Id=@Id;";

                _dataContext.SQLConnection.Execute(sql, _parametros);
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

                var sql = @"DELETE FROM Usuario WHERE Id=@Id;";

                _dataContext.SQLConnection.Execute(sql, _parametros);
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
                var sql = @"SELECT * FROM Usuario ORDER BY Nome;";

                return _dataContext.SQLConnection.Query<UsuarioQueryResult>(sql).ToList();
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

                var sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                return _dataContext.SQLConnection.Query<UsuarioQueryResult>(sql).FirstOrDefault();
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
