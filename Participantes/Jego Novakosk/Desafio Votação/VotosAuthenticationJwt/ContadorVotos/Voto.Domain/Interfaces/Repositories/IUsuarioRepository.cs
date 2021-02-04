using System.Collections.Generic;
using Voto.Domain.Entidades;
using Voto.Domain.Queries.Usuario;

namespace Voto.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        int InserirUsuario(Usuario usuario);
        void AlterarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        List<UsuarioQueryResult> ListarUsuario();
        UsuarioQueryResult ObterUsuarioPorId(int id);
        bool CheckUsuarioId(int id);
        bool ValidarLogin(string login, string senha);
    }
}
