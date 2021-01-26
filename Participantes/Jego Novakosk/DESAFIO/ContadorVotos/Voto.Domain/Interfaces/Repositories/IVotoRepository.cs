using System.Collections.Generic;
using Voto.Domain.Entidades;
using Voto.Domain.Queries.Votos;

namespace Voto.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        int  Inserir(Votos votos );
        void Alterar(Votos votos );
        void Deletar(int id);
        List<VotosQueryResult> Listar();
        VotosQueryResult ObterPorId(int id);
        bool CheckId(int id);
        bool CheckIdUsuario(int id);
    }
}
