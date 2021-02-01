using System.Collections.Generic;
using Votacao.Domain.Commands;
using Votacao.Domain.Entidades.Filme;
using Votacao.Domain.Queries.FIlme;
namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme filme);
        void Alterar(Filme filme);
        void Deletar(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult ObterPorId(long id);
        bool CheckId(long id);
    }
}
