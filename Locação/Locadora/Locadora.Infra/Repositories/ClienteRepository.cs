using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Queries;
using Locadora.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context) { }

        public Task<bool> CheckAutenticacaoAsync(string cpf, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckLoginAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteQueryResult> ObterPorLoginAsync(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
