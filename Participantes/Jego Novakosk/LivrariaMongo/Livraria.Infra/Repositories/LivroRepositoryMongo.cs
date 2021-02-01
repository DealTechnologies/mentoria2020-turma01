using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Livraria.Infra.DataContexts;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Livraria.Infra.Repositories
{
    public class LivroRepositoryMongo : ILivroRepositoryMongo
    {

        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContextMongo _dataContext;

        public LivroRepositoryMongo(DataContextMongo dataContext)
        {
            _dataContext = dataContext;
        }

        public void Alterar(Livro livro)
        {
            try
            {
                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<Livro> colNews = database.GetCollection<Livro>("livro");
                             
                Expression<Func<Livro, bool>> filter = x => x.Id.Equals(livro.Id);

                 _dataContext.Livros.Find(filter).FirstOrDefault();

                if (_dataContext != null)
                {
                    _dataContext.Livros.ReplaceOne(filter, livro);
                }        
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckId(string id)
        {
            try
            {

                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<LivroQueryResult> colNews = database.GetCollection<LivroQueryResult>("livro");

                Expression<Func<LivroQueryResult, bool>> filter = x => x.Id.Equals(id);

                var livroresult = _dataContext.LivrosQuery.Find(filter).FirstOrDefault();

                if (livroresult != null)
                    return true;
                
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(string id)
        {
            try
            {

                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<Livro> colNews = database.GetCollection<Livro>("livro");

                Expression<Func<Livro, bool>> filter = x => x.Id.Equals(id);

                var livroresult = _dataContext.Livros.DeleteOne(filter);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Inserir(Livro livro)
        {
            try
            {


                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<Livro> colNews = database.GetCollection<Livro>("livro");

                 _dataContext.Livros.InsertOne(livro);

                return livro.Id;

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

                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<LivroQueryResult> colNews = database.GetCollection<LivroQueryResult>("livro");

                

                IMongoQueryable<LivroQueryResult> ListarLivros = _dataContext.LivrosQuery.AsQueryable();
                List<LivroQueryResult> items = ListarLivros.ToList();

                

                return items;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LivroQueryResult ObterPorID(string Id)
        {
            try
            {

                //IMongoClient client = new MongoClient("mongodb://localhost:27017");
                //IMongoDatabase database = client.GetDatabase("Livro");
                //IMongoCollection<LivroQueryResult> colNews = database.GetCollection<LivroQueryResult>("livro");

                Expression<Func<LivroQueryResult, bool>> filter = x => x.Id.Equals(Id);

                var livroresult = _dataContext.LivrosQuery.Find(filter).FirstOrDefault();

                return livroresult;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
