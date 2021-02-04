using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Filme;
using Voto.Domain.Queries.Usuario;
using Voto.Domain.Queries.Votos;
using Voto.Infra.DataContexts;

namespace Voto.Infra.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        StringBuilder Sql = new StringBuilder();
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Alterar(Votos votos)
        {
            try
            {
                _parameters.Add("Id", votos.Id, DbType.Int32);
                _parameters.Add("IdUsuario", votos.IdUsuario, DbType.Int32);
                _parameters.Add("IdFilme", votos.IdFilme, DbType.Int32);

                string sql = @"UPDATE Voto SET IdUsuario=@IdUsuario, IdFilme=@IdFilme WHERE Id=@Id ";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
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
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"SELECT id FROM Voto WHERE Id=@Id";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckIdUsuario(int id)
        {
            try
            {
                _parameters.Add("IdUsuario", id, DbType.Int32);


                string sql = @"SELECT id FROM Voto WHERE IdUsuario=@IdUsuario";

                return _dataContext.SQLServerConnection.Query<bool>(sql, _parameters).FirstOrDefault();
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
                _parameters.Add("Id", id, DbType.Int32);


                string sql = @"DELETE FROM Voto WHERE Id=@Id";

                _dataContext.SQLServerConnection.Execute(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Inserir(Votos votos)
        {
            try
            {
                _parameters.Add("IdUsuario", votos.IdUsuario, DbType.Int32);
                _parameters.Add("IdFilme", votos.IdFilme, DbType.Int32);

                string sql = @"INSERT INTO Voto (IdUsuario, IdFilme) VALUES (@IdUsuario, @IdFilme) SELECT SCOPE_IDENTITY()";

                return _dataContext.SQLServerConnection.ExecuteScalar<int>(sql, _parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VotosQueryResult> Listar()
        {
            try
            {

                Sql.Clear();
                Sql.Append("SELECT ");
                Sql.Append("Voto.Id AS Id, ");

                Sql.Append("Usuario.Id AS Id, ");
                Sql.Append("Usuario.Nome AS Nome, ");
                //Sql.Append("Usuario.Login AS Login, ");
                //Sql.Append("Usuario.Senha AS Senha, ");

                Sql.Append("Filme.Id AS Id, ");
                Sql.Append("Filme.Titulo AS Titulo,");
                Sql.Append("Filme.Diretor AS Diretor ");

                Sql.Append("FROM Voto ");
                Sql.Append("INNER JOIN Usuario ON Voto.IdUsuario = Usuario.Id ");
                Sql.Append("INNER JOIN Filme ON Voto.IdFilme = Filme.Id ");
           

                return _dataContext.SQLServerConnection.Query<VotosQueryResult, UsuarioVotoQueryResult, FilmeQueryResult, VotosQueryResult>(
                    Sql.ToString(),
                    map: (voto, usuario, filme) =>
                    {
                        voto.Usuario = usuario;
                        voto.Filme = filme;
                        return voto;
                    }, splitOn: "Id, Id, Id").ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public VotosQueryResult ObterPorId(int id)
        {
            try
            {
                Sql.Clear();
                Sql.Append("SELECT ");
                Sql.Append("Voto.Id AS Id, ");

                Sql.Append("Usuario.Id AS Id, ");
                Sql.Append("Usuario.Nome AS Nome, ");
               // Sql.Append("Usuario.Login AS Login, ");
                //Sql.Append("Usuario.Senha AS Senha, ");

                Sql.Append("Filme.Id AS Id, ");
                Sql.Append("Filme.Titulo AS Titulo,");
                Sql.Append("Filme.Diretor AS Diretor ");

                Sql.Append("FROM Voto ");
                Sql.Append("INNER JOIN Usuario ON Voto.IdUsuario = Usuario.Id ");
                Sql.Append("INNER JOIN Filme ON Voto.IdFilme = Filme.Id ");
                Sql.Append("WHERE Voto.Id = @Id ");

                return _dataContext.SQLServerConnection.Query<VotosQueryResult,UsuarioVotoQueryResult, FilmeQueryResult, VotosQueryResult>(
                    Sql.ToString(),
                    map: (voto, usuario, filme) =>
                    {
                        voto.Usuario = usuario;
                        voto.Filme = filme;
                        return voto;
                    },
                    new {Id = id},
                    splitOn: "Id, Id, Id").FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
