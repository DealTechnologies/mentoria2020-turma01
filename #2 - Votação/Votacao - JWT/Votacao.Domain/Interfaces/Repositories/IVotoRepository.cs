using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Query.Voto;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        int Salvar(Voto voto);
        void Atualizar(Voto voto);
        void Deletar(int id);

        VotoQueryResult Obter(int id);
        List<VotoQueryResult> Listar();

        bool CheckId(int id);
        bool CheckUsuarioVotou(int idUsuario);
    }
}