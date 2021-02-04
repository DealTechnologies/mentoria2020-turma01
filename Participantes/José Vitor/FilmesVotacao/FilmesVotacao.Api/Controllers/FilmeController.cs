using FilmesVotacao.Domain.Commands.Filme.Input;
using FilmesVotacao.Domain.Handlers;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Filme;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FilmesVotacao.Api.Controllers
{
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/filmes")]
        public IEnumerable<FilmeQueryResult> Usuarios()
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
        [Route("v1/filmes/{id}")]
        public FilmeQueryResult Usuario(long id)
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
        [Route("v1/filmes")]
        public ICommandResult UsuarioInserir([FromBody] AdicionarFilmeCommand command)
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
        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult UsuarioAlterar(long id, [FromBody] AtualizarFilmeCommand command)
        {
            try
            {
                command.Id = id;
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete]
        [Route("v1/filmes/{id}")]
        public ICommandResult UsuarioApagar(long id)
        {
            try
            {
                ApagarFilmeCommand command = new ApagarFilmeCommand() { Id = id };
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
