using Flunt.Notifications;
using Livraria.Domain.Commands.Livro.Input;
using Livraria.Domain.Commands.Livro.Output;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Commands;
using Livraria.Domain.Interfaces.Repositories;
using System;

namespace Livraria.Domain.Handlers
{
    public class LivroHandler : Notifiable, ICommandHandler<AdicionarLivroCommand>,
                                            ICommandHandler<AtualizarLivroCommand>,
                                            ICommandHandler<ApagarLivroCommand>
    {

        private readonly ILivroRepository _repository;


        public LivroHandler(ILivroRepository repository)
        {
            _repository = repository;

        }

        public ICommandResult Handler(AdicionarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AdicionarLivroCommandResult(false, "Por favor corrija as inconsistência abaixo", command.Notifications);
                }

                long id = 0;
                string nome = command.Nome;
                string autor = command.Autor;
                int edicao = command.Edicao;
                string isbn = command.Isbn;
                string imagem = command.Imagem;

                Livro livro = new Livro(0, nome, autor, edicao, isbn, imagem);

                id = _repository.Inserir(livro);

                var retorno = new AdicionarLivroCommandResult(true, "Livro granado com sucesso", new
                {
                    Id = id,
                    Nome = livro.Nome,
                    Autor = livro.Autor,
                    Edicao = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public ICommandResult Handler(AtualizarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AtualizarLivroCommandResult(false, "Por favor corrija as inconsistência abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id invalido. Este idnão esta cadastrado.");
                    return new AtualizarLivroCommandResult(false, "Por favor corrija as inconsistência abaixo", Notifications);
                }

                long id = command.Id;
                string nome = command.Nome;
                string autor = command.Autor;
                int edicao = command.Edicao;
                string isbn = command.Isbn;
                string imagem = command.Imagem;

                Livro livro = new Livro(id, nome, autor, edicao, isbn, imagem);

              _repository.Alterar(livro);

                var retorno = new AtualizarLivroCommandResult(true, "Livro alterado com sucesso", new
                {
                    Id = livro.Id,
                    Nome = livro.Nome,
                    Autor = livro.Edicao,
                    Edicao = livro.Edicao,
                    Isbn = livro.Isbn,
                    Imagem = livro.Imagem
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public ICommandResult Handler(ApagarLivroCommand command)
        {
            if (!command.ValidarCommand())
            {
                return new ApagarLivroCommandResult(false, "Por favor corrija as inconsistência abaixo", command.Notifications);
            }

            if (!_repository.CheckId(command.Id))
            {
                AddNotification("Id", "Id invalido. Este idnão esta cadastrado.");
                return new ApagarLivroCommandResult(false, "Por favor corrija as inconsistência abaixo", Notifications);
            }

            _repository.Deletar(command.Id);

            var retorno = new AtualizarLivroCommandResult(true, "Livro deletado com sucesso", new
            {
                Id = command.Id,

            });

            return retorno;

            
        }
    }
}
