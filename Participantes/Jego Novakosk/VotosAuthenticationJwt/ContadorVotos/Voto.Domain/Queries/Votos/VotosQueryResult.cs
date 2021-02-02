using Voto.Domain.Queries.Filme;
using Voto.Domain.Queries.Usuario;

namespace Voto.Domain.Queries.Votos
{
    public class VotosQueryResult
    {
        public int Id { get;  set; }
        public UsuarioVotoQueryResult Usuario { get;  set; }
        public FilmeQueryResult Filme { get;  set; }
    }
}
