namespace Usuario.Domain.Entidades
{
    public class UsuarioCad
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public UsuarioCad(int id, string nome, string cpf, string email, string senha)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
        }
    }
}
