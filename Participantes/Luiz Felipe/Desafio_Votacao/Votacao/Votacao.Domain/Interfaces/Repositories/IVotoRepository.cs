﻿using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        List<VotoQueryResult> ListarVotos();
        bool CheckUsuarioVotou(long idUsuario);
        VotoQueryResult ObterVoto(long id);
    }
}
