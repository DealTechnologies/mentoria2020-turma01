using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        //IRepository<Cliente> Clientes { get; }
        IRepository<Equipamento> Equipamentos { get; }
        //IRepository<Locacao> Locacaos { get; }
    }
}
