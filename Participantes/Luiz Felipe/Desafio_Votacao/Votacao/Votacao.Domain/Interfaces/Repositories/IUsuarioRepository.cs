using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Deletar(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult ObterPorId(long id);
        bool CheckId(long id);
        bool CheckAutenticacao(string login, string senha);
    }
}
