using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Livraria.Infra.DataContexts
{
    public class DataContextMongo 
    { 
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database;

        public DataContextMongo()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoCollection<Livro> Livros
        {
            get
            {
                return _database.GetCollection<Livro>("livro");
            }
        }

        public IMongoCollection<LivroQueryResult> LivrosQuery
        {
            get
            {
                return _database.GetCollection<LivroQueryResult>("livro");
            }
        }
    }
}
