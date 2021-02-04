using System;
using System.Collections.Generic;
using FilmesVotacao.Domain.Commands.Voto.Input;
using FilmesVotacao.Domain.Handlers;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Voto;
using Microsoft.AspNetCore.Mvc;

namespace FilmesVotacao.Api.Controllers
{
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/votos")]
        public IEnumerable<VotoQueryResult> Votos()
        {
            try
            {
                return _repository.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("v1/votos/{id}")]
        public VotoQueryResult Voto(long id)
        {
            try
            {
                return _repository.ObterPorId(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("v1/votos")]
        public ICommandResult VotoInserir([FromBody] AdicionarVotoCommand command)
        {
            try
            {
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
