namespace Votacao.Domain.Entidades.Filme
{
    public class Filme
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public Filme(long id, string titulo, string diretor)
        {
            Id = id;
            Titulo = titulo;
            Diretor = diretor;
        }
    }
}
