using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Domain.Queries.FIlme
{
    public class FilmeQueryResult
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
    }
}
