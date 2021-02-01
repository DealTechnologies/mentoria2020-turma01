using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Task<string> InserirAsync(Livro livro);
        Task AlterarAsync(Livro livro);
        Task DeletarAsync(string id);
        Task<List<LivroQueryResult>> ListarAsync();
        Task<LivroQueryResult> ObterPorIdAsync(string id);
        Task<bool> CheckIdAsync(string id);
    }
}
