using Livraria.Domain.Entidades;
using Livraria.Domain.Query;
using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        long Inserir(Livro livro);
        void Alterar(Livro livro);
        void Deletar(long id);
        List<LivroQueryResult> Listar();
        LivroQueryResult ObterPorId(long id);
        bool CheckId(long id);
    }
}