using AutoMapper;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioQueryResult, Usuario>();
                cfg.CreateMap<Usuario, UsuarioQueryResult>();
            }).CreateMapper();
        }
    }
}
