using Locadora.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IEquipamentoRepository : IRepository<Equipamento>
    {
        Task<bool> CheckIdAsync(Guid id);
    }
}
