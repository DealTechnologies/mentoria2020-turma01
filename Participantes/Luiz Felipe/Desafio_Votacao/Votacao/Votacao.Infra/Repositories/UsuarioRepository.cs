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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Alterar(Usuario usuario)
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

        public long Inserir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioQueryResult> Listar()
        {
            throw new NotImplementedException();
        }

        public UsuarioQueryResult ObterPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
