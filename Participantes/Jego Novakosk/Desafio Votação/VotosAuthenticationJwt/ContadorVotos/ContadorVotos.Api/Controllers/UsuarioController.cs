using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voto.Domain.Commands.Usuario.Input;
using Voto.Domain.Handlers;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Usuario;

namespace ContadorVotos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Authorize()]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariorepository;
        private readonly IUsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository usuariorepository, IUsuarioHandler handler)
        {
            _usuariorepository = usuariorepository;
            _handler = handler;
        }

        /// <summary>
        /// buscar todos usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/usuarios")]
        public IEnumerable<UsuarioQueryResult> Usuario()
        {
            return _usuariorepository.ListarUsuario();
        }

        /// <summary>
        /// Obter usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Usuario(int id)
        {
            return _usuariorepository.ObterUsuarioPorId(id);
        }

        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult UsuarioInserir([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handler(command);
        }
        /// <summary>
        /// Valiadar login Usuario
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("v1/usuarios/login")]
        public ICommandResult LoginUsuario(string login, string senha,[FromBody] LoginUsuarioCommand command)
        {
            command.Senha = senha;
            command.Login = login;
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
        public ICommandResult UsuarioAtualizar(int id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// deletar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioDeletar(int id, [FromBody] ApagarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }
    }
}
