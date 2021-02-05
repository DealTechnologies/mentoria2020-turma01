using Flunt.Notifications;
using Votacao.Domain.ValueObjects;

namespace Votacao.Domain.Entidades
{
    public class Usuario : Notifiable
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Email Login { get; private set; }
        public string Senha { get; private set; }

        public Usuario(int id, string nome, Email login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public Usuario(int id)
        {
            Id = id;
        }
    }
}