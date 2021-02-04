using Flunt.Notifications;
using System;
using Voto.Domain.Commands.Filme.Input;
using Voto.Domain.Commands.Filme.Output;
using Voto.Domain.Entidades;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;

namespace Voto.Domain.Handlers
{
    public class FilmeHandler : Notifiable, IFilmeHandler
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
                {
                    return new AdicionarFilmeCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                int id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(0, titulo, diretor);

                id = _repository.Inserir(filme);

                var retorno = new AdicionarFilmeCommandResult(true, "Filme Adicionado com Sucesso!", new { 
                
                    Id = id,
                    Titulo = filme.Titulo,
                    Diretor =filme.Diretor
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

                int id = command.Id;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                _repository.Alterar(filme);

                var retorna = new AtualizarFilmeCommandResult(true, "Filme atualizado com sucesso", new
                {
                    Id = filme.Id,
                    Titulo = filme.Id,
                    Diretor = filme.Diretor
                    
                });

                return retorna;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICommandResult Handler(ApagarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                {
                    return new ApagarFilmeCommandResult(false, "Por favor arrumar as inconsistência abaixo", command.Notifications);
                }

                if (!_repository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id Invalido. Este ai nao esta cadastrado");
                    return new ApagarFilmeCommandResult(false, "Por favor arrumar as inconsistência abaixo", Notifications);
                }

              

                _repository.Deletar(command.Id);

                var retorno = new ApagarFilmeCommandResult(true, "Filme Apagado com sucesso", new
                {
                    Id = command.Id
                });

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
