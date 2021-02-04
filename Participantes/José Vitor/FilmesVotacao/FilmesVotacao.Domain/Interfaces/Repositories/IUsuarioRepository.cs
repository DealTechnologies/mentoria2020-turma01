using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Queries.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Deletar(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult ObterPorId(long id);
        bool CheckId(long id);
        public bool CheckLogin(string Login, string senha);
    }
}