using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Queries.Livro
{
    public class LivroQueryResult
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Isbn { get; set; }
        public string Imagem { get; set; }
    }
}
