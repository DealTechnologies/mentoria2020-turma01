using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Filme;
using Votacao.Domain.Query.Usuario;
using Votacao.Domain.Query.Voto;
using Votacao.Infra.Data.DataContexts;

namespace Votacao.Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DataContext _dataContext;
        private readonly DynamicParameters _parametros = new DynamicParameters();

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Salvar(Voto voto)
        {
            try
            {
                _parametros.Add("IdUsuario", voto.Usuario.Id, DbType.Int32);
                _parametros.Add("IdFilme", voto.Filme.Id, DbType.Int32);

                string sql = @"INSERT INTO Voto (IdUsuario, IdFilme) VALUES(@IdUsuario, @IdFilme); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLServerConexao.ExecuteScalar<int>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Voto voto)
        {
            try
            {
                _parametros.Add("Id", voto.Id, DbType.Int32);
                _parametros.Add("IdUsuario", voto.Usuario.Id, DbType.Int32);
                _parametros.Add("IdFilme", voto.Filme.Id, DbType.Int32);

                string sql = @"UPDATE Voto SET IdUsuario=@IdUsuario, IdFilme=@IdFilme WHERE Id=@Id";

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

                string sql = @"DELETE FROM Voto WHERE Id = @Id";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VotoQueryResult Obter(int id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int32);

                string sql = @" SELECT 
                                Voto.Id AS Id,

                                Usuario.Id AS Id,
                                Usuario.Nome AS Nome,
                                Usuario.Login AS Login, 
                                Usuario.Senha AS Senha,

                                FIlme.Id AS Id, 
                                FIlme.Titulo AS Titulo, 
                                FIlme.Diretor AS Diretor 

                                FROM Voto 
                                INNER JOIN Usuario ON Voto.IdUsuario = Usuario.Id 
                                INNER JOIN Filme ON Voto.IdFilme = Filme.Id 
                                WHERE Voto.Id = @Id ";

                return _dataContext.SQLServerConexao.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;
                            return voto;
                        },
                        _parametros,
                        splitOn: "Id, Id, Id").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                string sql = @" SELECT 
                                Voto.Id AS Id,

                                Usuario.Id AS Id,
                                Usuario.Nome AS Nome,
                                Usuario.Login AS Login, 
                                Usuario.Senha AS Senha,

                                FIlme.Id AS Id, 
                                FIlme.Titulo AS Titulo, 
                                FIlme.Diretor AS Diretor 

                                FROM Voto 
                                INNER JOIN Usuario ON Voto.IdUsuario = Usuario.Id 
                                INNER JOIN Filme ON Voto.IdFilme = Filme.Id 
                                ORDER BY Voto.Id ASC ";

                return _dataContext.SQLServerConexao.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                        sql,
                        map: (voto, usuario, filme) =>
                        {
                            voto.Usuario = usuario;
                            voto.Filme = filme;
                            return voto;
                        },
                        splitOn: "Id, Id, Id").Distinct().ToList();
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

                string sql = @"SELECT Id FROM Voto WHERE Id=@Id";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUsuarioVotou(int idUsuario)
        {
            try
            {
                _parametros.Add("IdUsuario", idUsuario, DbType.Int32);

                string sql = @"SELECT IdUsuario FROM Voto WHERE IdUsuario=@IdUsuario";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}