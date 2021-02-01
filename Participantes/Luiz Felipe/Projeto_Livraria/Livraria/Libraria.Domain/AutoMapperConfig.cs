using AutoMapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;

namespace Livraria.Domain
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LivroQueryResult, Livro>();
                cfg.CreateMap<Livro, LivroQueryResult>();
            }).CreateMapper();
        }
    }
}
