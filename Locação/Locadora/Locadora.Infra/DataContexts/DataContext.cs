using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;

namespace Locadora.Infra.DataContexts
{
    public class DataContext
    {
        public IMongoDatabase MongoDBConexao { get; set; }
        public MongoClient MongoClient { get; set; }

        public DataContext(IOptions<SettingsInfra> settingsInfra)
        {
            try
            {
                MongoBsonClassMap.Register();

                var mongoClient = new MongoClient(settingsInfra.Value.ConnectionString);
                if (mongoClient != null)
                    MongoDBConexao = mongoClient.GetDatabase(settingsInfra.Value.DataBaseName);
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível se conectar com o Banco de Dados.", ex);
            }
        }

        public void Dispose()
        {
            try
            {
                if (MongoDBConexao != null)
                    MongoDBConexao = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
