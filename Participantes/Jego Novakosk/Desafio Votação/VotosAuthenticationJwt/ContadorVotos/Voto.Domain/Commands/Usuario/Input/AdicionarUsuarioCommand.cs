using Flunt.Notifications;
using System;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Usuario.Input
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                // TRATAMENTO DE ERRO NOME
                if (string.IsNullOrEmpty(Nome))
                {
                    AddNotification("Nome", "Nome e um compo Obrigatorio");
                }
                else if (Nome.Length > 50)
                {
                    AddNotification("Nome", "Campo maior que o esperado");
                }

                //TRATAMENTO DE ERRO LOGIN
                if(string.IsNullOrEmpty(Login))
                {
                    AddNotification("Login", "Login e um compo Obrigatorio");
                }
                else if (Login.Length > 50)
                {
                    AddNotification("Login", "Campo maior que o esperado");
                }

                //TRATAMENTO DE ERRO SENHA
                if (string.IsNullOrEmpty(Senha))
                {
                    AddNotification("Senha", "Senha e um compo Obrigatorio");
                }
                else if (Senha.Length > 50)
                {
                    AddNotification("Senha", "Campo maior que o esperado");
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
