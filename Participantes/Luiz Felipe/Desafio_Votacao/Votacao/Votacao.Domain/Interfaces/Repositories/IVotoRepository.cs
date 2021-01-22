using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Alterar(Voto voto);
        void Deletar(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult ObterPorId(long id);
        bool CheckId(long id);
    }
}
