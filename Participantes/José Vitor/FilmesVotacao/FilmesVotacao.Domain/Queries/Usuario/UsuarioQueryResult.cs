using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Queries.Usuario
{
    public class UsuarioQueryResult
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
