namespace Voto.Domain.Entidades
{
    public  class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha  { get;  private set; }

        public Usuario(int id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }
    }
}
