using Dapper;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Filme;
using FilmesVotacao.Domain.Queries.Usuario;
using FilmesVotacao.Domain.Queries.Voto;
using FilmesVotacao.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FilmesVotacao.Infra.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        StringBuilder Sql = new StringBuilder();
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;
        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                string sql = @"SELECT * FROM Voto ORDER BY Id;";

                return _dataContext.SQLServerConexao.Query<VotoQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VotoQueryResult ObterPorId(long id)
        {
            try
            {
                Sql.Clear();
                Sql.Append("SELECT ");
                Sql.Append("Voto.Id as Id, ");

                Sql.Append("Usuario.Id AS Id, ");
                Sql.Append("Usuario.Nome AS Nome, ");
                Sql.Append("Usuario.Login AS Login, ");
                Sql.Append("Usuario.Senha AS Senha, ");

                Sql.Append("Filme.Id as Id, ");
                Sql.Append("Filme.Titulo as Titulo, ");
                Sql.Append("Filme.Diretor as Diretor ");

                Sql.Append("FROM Voto ");
                Sql.Append("INNER JOIN Usuario ON Voto.IdUsuario = Usuario.Id ");
                Sql.Append("INNER JOIN Filme ON Voto.IdFilme = Filme.Id ");
                Sql.Append("WHERE Voto.Id = @Id;");

                return _dataContext.SQLServerConexao.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    Sql.ToString(),
                    map: (voto, usuario, filme) =>
                    {
                        voto.Usuario = usuario;
                        voto.Filme = filme;
                        return voto;
                    },
                    new {Id = id},
                    splitOn:"Id, Id, Id").FirstOrDefault();
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
                string sql = @"SELECT * FROM Voto WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parametros.Add("IdUsuario", voto.IdUsuario, DbType.Int64);
                _parametros.Add("IdFilme", voto.IdFilme, DbType.Int64);


                string sql = @"INSERT INTO Voto (IdFilme, IdUsuario) Values (@IdFilme, @IdUsuario); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLServerConexao.ExecuteScalar<long>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(Voto voto)
        {
            try
            {
                //_parametros.Add("Id", filme.Id, DbType.Int64);
                //_parametros.Add("Titulo", filme.Titulo, DbType.String);
                //_parametros.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"UPDATE Filme SET Titulo=@Titulo, Diretor=@Diretor WHERE Id=@Id;";

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

                string sql = @"DELETE FROM Filme WHERE Id=@Id;";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckJaVotou(long IdUsuario)
        {
            try
            {
                _parametros.Add("IdUsuario", IdUsuario, DbType.Int64);
                string sql = @"SELECT * FROM Voto WHERE IdUsuario=@IdUsuario;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckIdUsuarioExiste(long IdUsuario)
        {
            try
            {
                _parametros.Add("Id", IdUsuario, DbType.Int64);
                string sql = @"SELECT * FROM Usuario WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckIdFilmeExiste(long IdFilme)
        {
            try
            {
                _parametros.Add("Id", IdFilme, DbType.Int64);
                string sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
