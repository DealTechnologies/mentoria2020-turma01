using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
namespace Livraria.Infra.DataContexts.MongoDataContext
{
    public class MongoDataContext : IDisposable
    {
        public IMongoDatabase MongoDataContext_ { get; set; }

        public MongoDataContext(IOptions<SettingsInfra> options)
        {
            try
            {
                IMongoClient client = new MongoClient(options.Value.ConnectionString);
                MongoDataContext_ = client.GetDatabase(options.Value.NomeBaseDados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (MongoDataContext_ != null)
                    MongoDataContext_ = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}