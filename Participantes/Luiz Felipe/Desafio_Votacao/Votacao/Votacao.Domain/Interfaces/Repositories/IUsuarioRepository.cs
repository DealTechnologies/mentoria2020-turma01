using System.Collections.Generic;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<long> InserirAsync(Usuario usuario);
        Task AlterarAsync(Usuario usuario);
        Task DeletarAsync(long id);
        Task<List<UsuarioQueryResult>> ListarAsync();
        Task<UsuarioQueryResult> ObterPorIdAsync(long id);
        Task<UsuarioQueryResult> ObterPorLoginAsync(string login);
        Task<bool> CheckIdAsync(long id);
        Task<bool> CheckAutenticacaoAsync(string login, string senha);
        Task<bool> CheckLoginAsync(string login);
    }
}
