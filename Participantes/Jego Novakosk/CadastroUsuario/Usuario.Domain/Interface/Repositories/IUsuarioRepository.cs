using System.Collections.Generic;
using Usuario.Domain.Entidades;
using Usuario.Domain.Queries.Usuario;

namespace Usuario.Domain.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        int Inserir(UsuarioCad usuarios);
        void Alterar(UsuarioCad usuarios);
        void Deletar(int id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult ObterPorId(int id);
        bool CheckId(int id);
    }
}
