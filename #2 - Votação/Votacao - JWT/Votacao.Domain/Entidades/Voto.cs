using Flunt.Notifications;

namespace Votacao.Domain.Entidades
{
    public class Voto : Notifiable
    {
        public int Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public Filme Filme { get; private set; }

        public Voto(int id, Usuario usuario, Filme filme)
        {
            Id = id;
            Usuario = usuario;
            Filme = filme;
        }
    }
}