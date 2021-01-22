using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Domain.Queries
{
    public class FilmeQueryResult
    {
        public long Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }
    }
}
