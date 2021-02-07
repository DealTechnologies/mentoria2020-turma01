using Locadora.Domain.Entidades;
using Locadora.Domain.Queries;
using MongoDB.Bson.Serialization;

namespace Locadora.Infra
{
    public class MongoBsonClassMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<ClienteQueryResult>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
                cm.SetIgnoreExtraElements(true);
                cm.SetIgnoreExtraElementsIsInherited(true);
                //cm.MapExtraElementsMember(Endereco)
            });
        }
    }
}
