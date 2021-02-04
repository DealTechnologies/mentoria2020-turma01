using System;
using System.Collections.Generic;
using FilmesVotacao.Domain.Commands.Usuario.Input;
using FilmesVotacao.Domain.Commands.Usuario.Output;
using FilmesVotacao.Domain.Handlers;
using FilmesVotacao.Domain.Interfaces.Commands;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesVotacao.Api.Controllers
{

    [Authorize()]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/usuarios")]
        public IEnumerable<UsuarioQueryResult> Usuarios()
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
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Usuario(long id)
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
        [Route("v1/usuarios")]
        public ICommandResult UsuarioInserir([FromBody] AdicionarUsuarioCommand command)
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
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioAlterar(long id, [FromBody] AtualizarUsuarioCommand command)
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
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioApagar(long id)
        {
            try
            {
                ApagarUsuarioCommand command = new ApagarUsuarioCommand() { Id = id };
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("v1/usuarios/login")]
        public ICommandResult UsuarioLogar([FromBody] LogarUsuarioCommand command)
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
