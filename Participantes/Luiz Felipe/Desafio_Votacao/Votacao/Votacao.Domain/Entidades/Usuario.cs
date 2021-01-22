using System;
using System.Collections.Generic;
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
            if (!ValidarJaVotouFilme(idFilme))
                Votos.Add(new Voto(0, Id, idFilme));
        }

        public bool ValidarJaVotouFilme(long idFilme)
        {
            bool jaVotou = false;
            foreach (var itemFilme in Votos)
            {
                jaVotou = itemFilme.Id == idFilme;
            }

            return jaVotou;
        }
    }
}
