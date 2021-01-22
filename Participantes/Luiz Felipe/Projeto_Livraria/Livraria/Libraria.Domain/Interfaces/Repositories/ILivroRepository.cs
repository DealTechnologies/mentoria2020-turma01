using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;
using System;
using System.Collections.Generic;
using System.Text;

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
