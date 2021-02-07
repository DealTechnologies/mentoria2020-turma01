using AutoMapper;
using Locadora.Domain.Entidades;
using Locadora.Domain.Queries;

namespace Votacao.Domain
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteQueryResult, Cliente>();
                cfg.CreateMap<Cliente, ClienteQueryResult>();
            }).CreateMapper();
        }
    }
}
