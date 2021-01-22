using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Votacao.Domain.Entidades
{
    public class Usuario
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public List<Voto> Votos { get; set; }

        public Usuario(long id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public void VotarFilme(long idFilme)
        {
            if (!ValidarVotouFilme(idFilme))
                Votos.Add(new Voto(0, Id, idFilme));
        }

        public bool ValidarVotouFilme(long idFilme)
        {
            return Votos.Any(x => x.IdFilme == idFilme);
        }
    }
}
