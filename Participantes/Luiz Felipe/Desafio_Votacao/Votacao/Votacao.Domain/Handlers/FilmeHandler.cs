using Flunt.Notifications;
using System;
using System.Linq;
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
                    return new AdicionarFilmeCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                long id = 0;
                Filme filme = new Filme(id, command.Titulo, command.Diretor);

                id = _filmeRepository.InserirAsync(filme).Result;

                return new AdicionarFilmeCommandResult(true, Avisos.Filme_Gravado_com_sucesso,
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
                    return new AtualizarFilmeCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_filmeRepository.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (Notifications.Count() > 0)
                    return new AtualizarFilmeCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                Filme filme = new Filme(command.Id, command.Titulo, command.Diretor);

                _filmeRepository.AlterarAsync(filme);

                return new AdicionarFilmeCommandResult(true, Avisos.Filme_Atualizado_com_sucesso,
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
                    return new ApagarFilmeCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, command.Notifications);

                if (!_filmeRepository.CheckIdAsync(command.Id).Result)
                    AddNotification("Id", Avisos.Id_invalido_Este_Id_nao_esta_cadastrado);

                if (Notifications.Count() > 0)
                    return new ApagarFilmeCommandResult(false, Avisos.Por_favor_corrija_as_inconsistências_abaixo, Notifications);

                _filmeRepository.DeletarAsync(command.Id);

                return new ApagarFilmeCommandResult(true, Avisos.Filme_Apagado_com_sucesso,
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
