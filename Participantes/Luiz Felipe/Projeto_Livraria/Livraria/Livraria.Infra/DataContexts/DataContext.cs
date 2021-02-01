using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Livraria.Infra.DataContexts
{
    public class DataContext
    {
        private readonly IMongoDatabase _database;

        public DataContext(IOptions<SettingsInfra> settingsInfra)
        {
            try
            {
                var mongoClient = new MongoClient(settingsInfra.Value.ConnectionString);
                if (mongoClient != null)
                    _database = mongoClient.GetDatabase(settingsInfra.Value.DataBaseName);
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível se conectar com o Banco de Dados.", ex);
            }
        }

        public IMongoCollection<LivroQueryResult> Livros
        {
            get
            {
                return _database.GetCollection<LivroQueryResult>("Livro");
            }
        }
    }
}
