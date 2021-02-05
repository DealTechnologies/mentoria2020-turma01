using Locadora.Domain.Interfaces;
using Locadora.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext Context;
        //private BaseRepository<Cliente> _clientes;
        //private BaseRepository<Equipamento> _equipamentos;
        //private BaseRepository<Locacao> _locacacoes;

        //public UnitOfWork(DataContext context)
        //{
        //    Context = context;
        //}

        //public IRepository<Cliente> Clientes
        //{
        //    get
        //    {
        //        return _clientes ??
        //            (_clientes = new BaseRepository<Cliente>(Context));
        //    }
        //}

        //public IRepository<Equipamento> Equipamentos
        //{
        //    get
        //    {
        //        return _equipamentos ??
        //            (_equipamentos = new BaseRepository<Equipamento>(Context));
        //    }
        //}
        
        //public IRepository<Locacao> Locacacoes
        //{
        //    get
        //    {
        //        return _locacacoes ??
        //            (_locacacoes = new BaseRepository<Locacao>(Context));
        //    }
        //}
    }
}
