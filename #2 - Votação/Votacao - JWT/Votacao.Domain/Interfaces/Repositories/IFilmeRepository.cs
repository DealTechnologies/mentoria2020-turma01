using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Query.Filme;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        int Salvar(Filme filme);
        void Atualizar(Filme filme);
        void Deletar(int id);

        FilmeQueryResult Obter(int id);
        List<FilmeQueryResult> Listar();

        bool CheckId(int id);
    }
}