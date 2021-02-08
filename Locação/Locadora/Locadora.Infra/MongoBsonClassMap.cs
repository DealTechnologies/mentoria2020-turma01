using Locadora.Domain.Entidades;
using Locadora.Domain.ValueObjects;
using MongoDB.Bson.Serialization;

namespace Locadora.Infra
{
    public class MongoBsonClassMap
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Cliente)))
            {
                BsonClassMap.RegisterClassMap<Cliente>(cm =>
                {
                    cm.SetIsRootClass(true);
                    cm.MapMember(c => c.Nome);
                    cm.MapMember(c => c.Senha);
                    cm.MapMember(c => c.Rg);
                    cm.MapMember(c => c.Cpf);
                    cm.MapMember(c => c.Email);
                    cm.MapMember(c => c.DataNascimento);
                    cm.MapMember(c => c.DataNascimento);
                    cm.MapMember(c => c.Role);
                    cm.MapMember(c => c.Endereco);
                });

                BsonClassMap.RegisterClassMap<Endereco>(cm =>
                {
                    cm.SetIsRootClass(false);
                    cm.SetIgnoreExtraElements(true);
                    cm.MapMember(c => c.Cep);
                    cm.MapMember(c => c.Rua);
                    cm.MapMember(c => c.Numero);
                    cm.MapMember(c => c.Complemento);
                    cm.MapMember(c => c.Cidade);
                    cm.MapMember(c => c.Estado);
                    cm.MapMember(c => c.Pais);
                    cm.MapMember(c => c.Principal);
                });

                BsonClassMap.RegisterClassMap<Cep>(cm =>
                {
                    cm.SetIsRootClass(false);
                    cm.SetIgnoreExtraElements(true);
                    cm.MapMember(c => c.NumeroCep);
                });

                BsonClassMap.RegisterClassMap<Cpf>(cm =>
                {
                    cm.SetIsRootClass(false);
                    cm.SetIgnoreExtraElements(true);
                    cm.MapMember(c => c.Numero);
                });

                BsonClassMap.RegisterClassMap<Email>(cm =>
                {
                    cm.SetIsRootClass(false);
                    cm.SetIgnoreExtraElements(true);
                    cm.MapMember(c => c.EnderecoEmail);
                });

                BsonClassMap.RegisterClassMap<Entity>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIsRootClass(false);
                    cm.SetIgnoreExtraElements(true);
                    cm.MapIdMember(c => c.Id);
                });
            }
        }
    }
}
