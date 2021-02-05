using Flunt.Notifications;

namespace Votacao.Domain.Entidades
{
    public class Filme : Notifiable
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(int id, string titulo, string diretor)
        {
            Id = id;
            Titulo = titulo;
            Diretor = diretor;
        }

        public Filme(int id)
        {
            Id = id;
        }
    }
}