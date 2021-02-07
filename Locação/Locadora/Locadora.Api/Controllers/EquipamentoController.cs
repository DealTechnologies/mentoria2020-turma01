using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Domain.Commands.Equipamentos.Inputs;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    public class EquipamentoController : ControllerBase
    {
        //private readonly IEquipamentoRepository _repository;
        //private readonly EquipamentoHandler _handler;

        private readonly IUnitOfWork _unitofwork;
        private readonly EquipamentoHandler _handler;

        public EquipamentoController(IUnitOfWork unitofwork, EquipamentoHandler handler)
        {
            _unitofwork = unitofwork;
            _handler = handler;
        }

        //[HttpGet]
        //[Route("v1/Equipamentos")]
        //public IEnumerable<EquipamentoQueryResult> Usuarios()
        //{
        //    try
        //    {
        //        return _unitofwork.Equipamentos.ListarAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[HttpGet]
        //[Route("v1/Equipamentos/{id}")]
        //public EquipamentoQueryResult Usuario(long id)
        //{
        //    try
        //    {
        //        return _repository.ObterPorId(id);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [HttpPost]
        [Route("v1/Equipamentos")]
        public ICommandResult UsuarioInserir([FromBody] AdicionarEquipamentoCommand command)
        {
            try
            {
                return  _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //        [HttpPut]
        //        [Route("v1/Equipamentos/{id}")]
        //        public ICommandResult UsuarioAlterar(long id, [FromBody] AtualizarFilmeCommand command)
        //        {
        //            try
        //            {
        //                command.Id = id;
        //                return _handler.Handler(command);
        //            }
        //            catch (Exception ex)
        //            {

        //                throw ex;
        //            }
        //        }
        //        [HttpDelete]
        //        [Route("v1/Equipamentos/{id}")]
        //        public ICommandResult UsuarioApagar(long id)
        //        {
        //            try
        //            {
        //                ApagarFilmeCommand command = new ApagarFilmeCommand() { Id = id };
        //                return _handler.Handler(command);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        //    }
    }
}