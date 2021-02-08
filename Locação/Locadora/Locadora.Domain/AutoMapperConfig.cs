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
                cfg.CreateMap<Cliente, ClienteQueryResult>()
                    .ForMember(cr => cr.Id, c => c.MapFrom(x => x.Id))
                    .ForMember(cr => cr.Nome, c => c.MapFrom(x => x.Nome))
                    .ForMember(cr => cr.Senha, c => c.MapFrom(x => x.Senha))
                    .ForMember(cr => cr.Rg, c => c.MapFrom(x => x.Rg))
                    .ForMember(cr => cr.Cpf, c => c.MapFrom(x => x.Cpf.Numero))
                    .ForMember(cr => cr.Email, c => c.MapFrom(x => x.Email.EnderecoEmail))
                    .ForMember(cr => cr.DataNascimento, c => c.MapFrom(x => x.DataNascimento.ToString("dd/MM/yyyy")))
                    .ForMember(cr => cr.Role, c => c.MapFrom(x => x.Role))

                    .ForMember(cr => cr.Cep, c => c.MapFrom(x => x.Endereco.Cep.NumeroCep))
                    .ForMember(cr => cr.Rua, c => c.MapFrom(x => x.Endereco.Rua))
                    .ForMember(cr => cr.Numero, c => c.MapFrom(x => x.Endereco.Numero))
                    .ForMember(cr => cr.Complemento, c => c.MapFrom(x => x.Endereco.Complemento))
                    .ForMember(cr => cr.Cidade, c => c.MapFrom(x => x.Endereco.Cidade))
                    .ForMember(cr => cr.Estado, c => c.MapFrom(x => x.Endereco.Estado))
                    .ForMember(cr => cr.Pais, c => c.MapFrom(x => x.Endereco.Pais))
                    .ForMember(cr => cr.Principal, c => c.MapFrom(x => x.Endereco.Principal));

                cfg.CreateMap<Equipamento, EquipamentoQueryResult>()
                   .ForMember(cr => cr.Id, c => c.MapFrom(x => x.Id))
                   .ForMember(cr => cr.Nome, c => c.MapFrom(x => x.Nome))
                   .ForMember(cr => cr.Descricao, c => c.MapFrom(x => x.Descricao))
                   .ForMember(cr => cr.Cor, c => c.MapFrom(x => x.Cor))
                   .ForMember(cr => cr.Modelo, c => c.MapFrom(x => x.Modelo))
                   .ForMember(cr => cr.Imagem, c => c.MapFrom(x => x.Imagem))
                   .ForMember(cr => cr.SaldoEstoque, c => c.MapFrom(x => x.SaldoEstoque))
                   .ForMember(cr => cr.ValorDiaria, c => c.MapFrom(x => x.ValorDiaria));

            }).CreateMapper();
        }
    }
}
