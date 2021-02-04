using FilmesVotacao.Domain.Queries.Filme;
using FilmesVotacao.Domain.Queries.Usuario;

namespace FilmesVotacao.Domain.Queries.Voto
{
    public class VotoQueryResult
    {
        public long Id { get; set; }
        public UsuarioQueryResult Usuario { get; set; }
        public FilmeQueryResult Filme { get; set; }
    }
}
