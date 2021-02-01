using System.Collections.Generic;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        Task<long> InserirAsync(Filme filme);
        Task AlterarAsync(Filme filme);
        Task DeletarAsync(long id);
        Task<List<FilmeQueryResult>> ListarAsync();
        Task<FilmeQueryResult> ObterPorIdAsync(long id);
        Task<bool> CheckIdAsync(long id);
    }
}
