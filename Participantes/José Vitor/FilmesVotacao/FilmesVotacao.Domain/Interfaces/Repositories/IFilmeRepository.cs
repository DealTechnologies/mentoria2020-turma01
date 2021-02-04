using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Queries.Filme;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Interfaces.Repositories
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
