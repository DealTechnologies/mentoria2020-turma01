using System.Collections.Generic;
using Voto.Domain.Entidades;
using Voto.Domain.Queries.Filme;

namespace Voto.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        int Inserir(Filme filme);
        void Alterar(Filme filme);
        void Deletar(int id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult ObterPorId(int id);
        bool CheckId(int id);

    }
}
