using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Queries.Filme
{
    public class FilmeQueryResult
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
    }
}
