using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Queries;
using Locadora.Infra.DataContexts;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context) { }

        public async Task<bool> CheckAutenticacaoAsync(string cpf, string senha)
        {
            try
            {
                Expression<Func<Cliente, bool>> filter =
                    x => x.Cpf.Numero.Equals(cpf) 
                    && x.Senha.Equals(senha);

                var clientResult = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (clientResult != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> CheckIdAsync(Guid id)
        {
            try
            {
                Expression<Func<Cliente, bool>> filter =
                    x => x.Id.Equals(id);

                var clientResult = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (clientResult != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> CheckCpfAsync(string cpf)
        {
            try
            {
                Expression<Func<Cliente, bool>> filter =
                    x => x.Cpf.Numero.Equals(cpf);

                var clientResult = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (clientResult != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Cliente> ObterPorCpfAsync(string cpf)
        {
            try
            {
                Expression<Func<Cliente, bool>> filter =
                    x => x.Cpf.Numero.Equals(cpf);

                return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
