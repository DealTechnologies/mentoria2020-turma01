using Votacao.Domain.Query.Filme;
using Votacao.Domain.Query.Usuario;

namespace Votacao.Domain.Query.Voto
{
    public class VotoQueryResult
    {
        public int Id { get; set; }
        public UsuarioQueryResult Usuario { get; set; }
        public FilmeQueryResult Filme { get; set; }
    }
}