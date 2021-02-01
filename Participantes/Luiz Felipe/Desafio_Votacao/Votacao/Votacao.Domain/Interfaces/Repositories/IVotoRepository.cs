using System.Collections.Generic;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        Task<long> InserirAsync(Voto voto);
        Task<List<VotoQueryResult>> ListarVotosAsync();
        Task<bool> CheckUsuarioVotouAsync(long idUsuario);
        Task<VotoQueryResult> ObterVotoAsync(long id);
    }
}
