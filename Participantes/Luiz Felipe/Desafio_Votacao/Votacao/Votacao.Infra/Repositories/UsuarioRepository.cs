﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<long> InserirAsync(Usuario usuario)
        {
            try
            {
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login, DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);
                _parametros.Add("Role", usuario.Role, DbType.String);

                var sql = @"INSERT INTO Usuario (Nome, Login, Senha, Role) VALUES (@Nome, @Login, @Senha, @Role); SELECT SCOPE_IDENTITY();";

                return await _dataContext.SQLConnection.ExecuteScalarAsync<long>(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AlterarAsync(Usuario usuario)
        {
            try
            {
                _parametros.Add("Id", usuario.Id, DbType.Int64);
                _parametros.Add("Nome", usuario.Nome, DbType.String);
                _parametros.Add("Login", usuario.Login, DbType.String);
                _parametros.Add("Senha", usuario.Senha, DbType.String);
                _parametros.Add("Role", usuario.Role, DbType.String);

                var sql = @"UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha, Role=@Role WHERE Id=@Id;";

                await _dataContext.SQLConnection.ExecuteAsync(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeletarAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"DELETE FROM Usuario WHERE Id=@Id;";

                await _dataContext.SQLConnection.ExecuteAsync(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<UsuarioQueryResult>> ListarAsync()
        {
            try
            {
                var sql = @"SELECT * FROM Usuario ORDER BY Nome;";

                var result = await _dataContext.SQLConnection.QueryAsync<UsuarioQueryResult>(sql);

                return result.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioQueryResult> ObterPorIdAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                var result = await _dataContext.SQLConnection.QueryAsync<UsuarioQueryResult>(sql, _parametros);
                
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioQueryResult> ObterPorLoginAsync(string login)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);

                var sql = @"SELECT * FROM Usuario WHERE Login=@Login;";

                var result = await _dataContext.SQLConnection.QueryAsync<UsuarioQueryResult>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CheckIdAsync(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                var sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                var result = await _dataContext.SQLConnection.QueryAsync<bool>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CheckAutenticacaoAsync(string login, string senha)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);
                _parametros.Add("Senha", senha, DbType.String);

                var sql = @"SELECT * FROM Usuario 
                            WHERE Login=@Login AND Senha=@Senha;";

                var result = await _dataContext.SQLConnection.QueryAsync<bool>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CheckLoginAsync(string login)
        {
            try
            {
                _parametros.Add("Login", login, DbType.String);

                var sql = @"SELECT * FROM Usuario WHERE Login=@Login;";

                var result = await _dataContext.SQLConnection.QueryAsync<bool>(sql, _parametros);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
