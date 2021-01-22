using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Domain.Entidades
{
    public class Filme
    {
        public long Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(long id, string titulo, string diretor)
        {
            Id = id;
            Titulo = titulo;
            Diretor = diretor;
        }
    }
}
