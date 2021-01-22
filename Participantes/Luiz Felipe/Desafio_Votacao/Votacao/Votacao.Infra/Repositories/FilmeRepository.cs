using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;
using Votacao.Infra.DataContexts;

namespace Votacao.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Alterar(Filme filme)
        {
            throw new NotImplementedException();
        }

        public bool CheckId(long id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public long Inserir(Filme filme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeQueryResult> Listar()
        {
            throw new NotImplementedException();
        }

        public FilmeQueryResult ObterPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
