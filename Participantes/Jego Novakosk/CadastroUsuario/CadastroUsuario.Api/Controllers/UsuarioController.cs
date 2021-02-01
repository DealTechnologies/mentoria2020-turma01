using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Domain.Command.Usuario.Input;
using Usuario.Domain.Handlers;
using Usuario.Domain.Interface.Commands;
using Usuario.Domain.Interface.Handlers;
using Usuario.Domain.Interface.Repositories;
using Usuario.Domain.Queries.Usuario;

namespace CadastroUsuario.Api.Controllers
{
    [Consumes("Application/json")]
    [Produces("Application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, IUsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }



        /// <summary>
        /// Buscar todos os Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/usuarios")]
        public IEnumerable<UsuarioQueryResult> Usuarios()
        {
            return _repository.Listar();
        }

        /// <summary>
        /// Buscar Usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Usuarios(int id)
        {
            return _repository.ObterPorId(id);
        }

        /// <summary>
        /// Adicionar Usuario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult IserirUsuario([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/usuarios/{id}")]
        public ICommandResult AtualizarUsuario(int id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// Deletaar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult ApagarUsuario(int id)
        {
            ApagarUsuarioCommand command = new ApagarUsuarioCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
