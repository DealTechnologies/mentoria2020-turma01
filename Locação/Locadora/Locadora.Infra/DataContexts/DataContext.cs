using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Infra.DataContexts
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

        //public IMongoCollection<ClienteQueryResult> Clientes
        //{
        //    get
        //    {
        //        return _database.GetCollection<ClienteQueryResult>("Livro");
        //    }
        //}

        //public IMongoCollection<EquipamentoQueryResult> Equipamentos
        //{
        //    get
        //    {
        //        return _database.GetCollection<EquipamentoQueryResult>("Livro");
        //    }
        //}

        //public IMongoCollection<LocacaoQueryResult> Locacoes
        //{
        //    get
        //    {
        //        return _database.GetCollection<LocacaoQueryResult>("Livro");
        //    }
        //}
    }
}
