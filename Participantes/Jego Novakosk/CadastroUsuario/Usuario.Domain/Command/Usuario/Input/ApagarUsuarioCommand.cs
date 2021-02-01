using Flunt.Notifications;
using System;
using Usuario.Domain.Interface.Commands;

namespace Usuario.Domain.Command.Usuario.Input
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }
 
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                {
                    AddNotification("Id", "Id e um campo Obgrigatorio");
                }

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
