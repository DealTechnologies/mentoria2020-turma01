using Locadora.Domain.Entidades;
using Locadora.Domain.Queries;
using System;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<ClienteQueryResult> ObterPorLoginAsync(string cpf);
        Task<bool> CheckIdAsync(Guid id);
        Task<bool> CheckAutenticacaoAsync(string cpf, string senha);
        Task<bool> CheckLoginAsync(string cpf);
    }
}