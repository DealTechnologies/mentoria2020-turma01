using Locadora.Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> CheckIdAsync(Guid id);
        Task<Cliente> ObterPorCpfAsync(string cpf);
        Task<bool> CheckAutenticacaoAsync(string cpf, string senha);
        Task<bool> CheckCpfAsync(string cpf);
    }
}