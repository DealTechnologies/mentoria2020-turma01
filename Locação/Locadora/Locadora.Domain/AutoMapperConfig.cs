using AutoMapper;
using Locadora.Domain.Commands.Locacoes.Inputs;
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
                   .ForMember(cr => cr.ValorDiaria, c => c.MapFrom(x => x.ValorDiaria))
                   .ForMember(cr => cr.QuantidadeAlugado, c => c.MapFrom(x => x.QuantidadeAlugado));

                cfg.CreateMap<Locacao, LocacaoQueryResult>()
                    .ForPath(lr => lr.Cliente.Id, l => l.MapFrom(x => x.Cliente.Id))
                    .ForPath(lr => lr.Cliente.Nome, l => l.MapFrom(x => x.Cliente.Nome))
                    .ForPath(lr => lr.Cliente.Senha, l => l.MapFrom(x => x.Cliente.Senha))
                    .ForPath(lr => lr.Cliente.Rg, l => l.MapFrom(x => x.Cliente.Rg))
                    .ForPath(lr => lr.Cliente.Cpf, l => l.MapFrom(x => x.Cliente.Cpf.Numero))
                    .ForPath(lr => lr.Cliente.Email, l => l.MapFrom(x => x.Cliente.Email.EnderecoEmail))
                    .ForPath(lr => lr.Cliente.DataNascimento, l => l.MapFrom(x => x.Cliente.DataNascimento.ToString("dd/MM/yyyy")))
                    .ForPath(lr => lr.Cliente.Role, l => l.MapFrom(x => x.Cliente.Role))

                    .ForMember(lr => lr.DataLocacao, l => l.MapFrom(x => x.DataLocacao.ToString("dd/MM/yyyy")))
                    .ForMember(lr => lr.DataDevolucao, l => l.MapFrom(x => x.DataDevolucao.ToString("dd/MM/yyyy")))
                    .ForMember(lr => lr.ValorFrete, l => l.MapFrom(x => x.ValorFrete))
                    .ForMember(lr => lr.ValorAluguel, l => l.MapFrom(x => x.ValorAluguel))
                    .ForMember(lr => lr.ValorTotal, l => l.MapFrom(x => x.ValorTotal));

                cfg.CreateMap<Equipamento, EquipamentoDto>();
                cfg.CreateMap<EquipamentoDto, Equipamento>();

            }).CreateMapper();
        }
    }
}
