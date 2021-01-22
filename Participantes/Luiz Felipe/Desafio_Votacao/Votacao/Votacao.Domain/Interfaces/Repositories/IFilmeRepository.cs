using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
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
