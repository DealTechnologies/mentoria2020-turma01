using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Commands.Filme.Inputs;
using Votacao.Domain.Commands.Filme.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Domain.Handlers
{
    public class FilmeHandler : Notifiable, ICommandHandler<AdicionarFilmeCommand>,
                                                ICommandHandler<AtualizarFilmeCommand>,
                                                ICommandHandler<ApagarFilmeCommand>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public ICommandResult Handler(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AdicionarFilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                Filme filme = new Filme(id, command.Titulo, command.Diretor);

                id = _filmeRepository.Inserir(filme);

                return new AdicionarFilmeCommandResult(true, "Filme Gravado com sucesso!",
                    new
                    {
                        Id = id,
                        Titulo = filme.Titulo,
                        Diretor = filme.Diretor
                    });
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
                    return new AtualizarFilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_filmeRepository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");
                    return new AtualizarFilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                Filme filme = new Filme(command.Id, command.Titulo, command.Diretor);

                _filmeRepository.Alterar(filme);

                return new AdicionarFilmeCommandResult(true, "Filme Atualizado com sucesso!",
                    new
                    {
                        Id = filme.Id,
                        Titulo = filme.Titulo,
                        Diretor = filme.Diretor
                    });
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
                    return new ApagarFilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                if (!_filmeRepository.CheckId(command.Id))
                {
                    AddNotification("Id", "Id inválido. Este Id não está cadastrado.");
                    return new ApagarFilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", Notifications);
                }

                _filmeRepository.Deletar(command.Id);

                return new ApagarFilmeCommandResult(true, "Filme Apagado com sucesso!",
                    new
                    {
                        Id = command.Id
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
