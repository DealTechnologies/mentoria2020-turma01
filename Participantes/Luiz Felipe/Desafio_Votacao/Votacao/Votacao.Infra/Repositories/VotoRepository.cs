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
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Alterar(Voto voto)
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

        public long Inserir(Voto voto)
        {
            throw new NotImplementedException();
        }

        public List<VotoQueryResult> Listar()
        {
            throw new NotImplementedException();
        }

        public VotoQueryResult ObterPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
