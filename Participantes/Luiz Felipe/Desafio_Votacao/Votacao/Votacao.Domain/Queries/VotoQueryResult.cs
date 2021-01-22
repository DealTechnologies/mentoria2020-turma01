using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Domain.Queries
{
    public class VotoQueryResult
    {
        public long Id { get; private set; }
        public long IdUsuario { get; private set; }
        public long IdFilme { get; private set; }
    }
}
