using System.Collections.Generic;
using Usuario.Domain.Entidades;
using Usuario.Domain.Interface.Repositories;
using Usuario.Domain.Queries.Usuario;
using Dapper;
using Usuario.Infra.DataContexts;
using System.Data;
using System;
using System.Linq;

namespace Usuario.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DynamicParameters _parametro = new DynamicParameters();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Alterar(UsuarioCad usuarios)
        {
            try
            {
                _parametro.Add("Id", usuarios.Id, DbType.Int32);
                _parametro.Add("Nome", usuarios.Nome, DbType.String);
                _parametro.Add("CPF", usuarios.CPF, DbType.String);
                _parametro.Add("Email", usuarios.Email, DbType.String);
                _parametro.Add("Senha", usuarios.Senha, DbType.String);

                string sql = @"UPDATE  Usuario SET  Nome=@Nome, CPF=@CPF, Email=@Email, Senha=@Senha WHERE Id=@Id";

                _dataContext.SQLConexao.Execute(sql, _parametro);

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
                _parametro.Add("Id", id, DbType.Int32);

                string sql = @"SELECT Id FROM Usuario WHERE Id=@Id";

                return _dataContext.SQLConexao.Query<bool>(sql, _parametro).FirstOrDefault();
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
                _parametro.Add("Id", id, DbType.Int32);
                

                string sql = @"DELETE FROM Usuario WHERE Id=@Id";

                _dataContext.SQLConexao.Execute(sql, _parametro);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Inserir(UsuarioCad usuarios)
        {
            try
            {
                _parametro.Add("Nome", usuarios.Nome, DbType.String);
                _parametro.Add("CPF", usuarios.CPF, DbType.String);
                _parametro.Add("Email", usuarios.Email, DbType.String);
                _parametro.Add("Senha", usuarios.Senha, DbType.String);

                string sql = @"INSERT INTO Usuario (Nome, CPF, Email, Senha) VALUES (@Nome, @CPF, @Email, @Senha) SELECT SCOPE_IDENTITY()";

                return _dataContext.SQLConexao.ExecuteScalar<int>(sql, _parametro);

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
                string sql = @"SELECT * FROM Usuario ORDER BY Nome";

                return _dataContext.SQLConexao.Query<UsuarioQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public UsuarioQueryResult ObterPorId(int id)
        {
            try
            {
                _parametro.Add("Id", id, DbType.Int32);
                string sql = @"SELECT * FROM Usuario WHERE Id=@Id";

                return _dataContext.SQLConexao.Query<UsuarioQueryResult>(sql, _parametro).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
