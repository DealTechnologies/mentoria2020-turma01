using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Queries.Voto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Alterar(Voto voto);
        void Deletar(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult ObterPorId(long id);
        bool CheckId(long id);
        bool CheckJaVotou(long IdUsuario);
        public bool CheckIdUsuarioExiste(long IdUsuario);
        public bool CheckIdFilmeExiste(long IdFilme);
    }
}
