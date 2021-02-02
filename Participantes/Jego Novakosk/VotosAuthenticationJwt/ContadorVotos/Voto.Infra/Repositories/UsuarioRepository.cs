using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Usuario;
using Voto.Infra.DataContexts;

namespace Voto.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();

        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AlterarUsuario(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.Id, DbType.Int32);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"UPDATE Usuario SET  Senha=@Senha, Login=@Login, Nome=@Nome WHERE Id=@Id";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool CheckUsuarioId(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);

                string sql = @"SELECT id FROM Usuario WHERE Id=@Id";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletarUsuario(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);

                string sql = @"DELETE FROM Usuario WHERE Id=@Id";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public int InserirUsuario(Usuario usuario)
        {
            try
            {
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                string sql = @"INSERT INTO Usuario (Nome, Login, Senha) VALUES (@Nome, @Login, @Senha) SELECT SCOPE_IDENTITY()";

                return _dataContext.SQLServerConnection.ExecuteScalar<int>(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UsuarioQueryResult> ListarUsuario()
        {
            try
            {
                string sql = @"SELECT * FROM Usuario ORDER BY Id";

                return _dataContext.SQLServerConnection.Query<UsuarioQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UsuarioQueryResult ObterUsuarioPorId(int id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int32);

                string sql = @"SELECT * FROM Usuario WHERE Id=@Id";

                return _dataContext.SQLServerConnection.Query<UsuarioQueryResult>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool ValidarLogin(string login, string senha)
        {
            try
            {
                _parameters.Add("Login", login, DbType.String);
                _parameters.Add("Senha", senha, DbType.String);

                string sql = @"SELECT * FROM Usuario WHERE Login=@Login AND Senha=@Senha ";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
