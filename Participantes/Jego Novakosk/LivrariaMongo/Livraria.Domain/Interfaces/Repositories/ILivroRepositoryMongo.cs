using Livraria.Domain.Entidades;
using Livraria.Domain.Queries.Livro;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface ILivroRepositoryMongo
    {
        string Inserir(Livro livro);
        void Alterar(Livro livro);
        void Deletar(string id);
        List<LivroQueryResult> Listar();
        LivroQueryResult ObterPorID(string id);

        bool CheckId(string id);

    }
}
