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
        List<VotoQueryResult> Listar();
        bool CheckUsuarioVotou(long idUsuario);
        bool CheckIdFilme(long idFilme);
        bool CheckIdUsuario(long idUsuario);
    }
}
