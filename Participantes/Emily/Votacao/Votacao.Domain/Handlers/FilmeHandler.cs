using Flunt.Notifications;
using System;
using Votacao.Domain.Commands.Filme.Input;
using Votacao.Domain.Commands.Filme.Output;
using Votacao.Domain.Entidades.Filme;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Domain.Handlers
{
    public class FilmeHandler : Notifiable, ICommandHandler<AdicionarFilmeCommand>,
                                            ICommandHandler<AtualizarFilmeCommand>,
                                            ICommandHandler<ApagarFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarFilmeCommandResult(false, "Por favor corrija as inconsistencias abaixo:", command.Notifications);
                long id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(0, titulo, diretor);

                id = _repository.Inserir(filme);
                var retorno = new AdicionarFilmeCommandResult(true, "Livro adicionado", new
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });

                return retorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ICommandResult Handler(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new AtualizarFilmeCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Este ai nao esta cadastrado");
                    return new AtualizarFilmeCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

                long id = command.Id;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                _repository.Alterar(filme);

                var retorno = new AtualizarFilmeCommandResult(true, "Filme atualizado com sucesso", new
                {
                    Id = command.Id,
                    Titulo = filme.Id,
                    Diretor = filme.Diretor

                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(ApagarFilmeCommand command)
        {
            if (!command.ValidarCommand())
                return new ApagarFilmeCommandResult(false, "Por favor corrija as inconsistencias abaixo:", command.Notifications);
            if (!_repository.CheckId(command.Id))
            {
                AddNotification("Id", "Id inválido");
                return new ApagarFilmeCommandResult(false, "Por favor corrija as inconsistencias abaixo:", this.Notifications);
            }

            _repository.Deletar(command.Id);

            var retorno = new ApagarFilmeCommandResult(true, "Filme apagado", new
            {
                Id = command.Id
            });

            return retorno;

        }
    }
}
