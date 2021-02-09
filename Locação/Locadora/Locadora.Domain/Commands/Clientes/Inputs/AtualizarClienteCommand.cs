using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Globalization;

namespace Locadora.Domain.Commands.Clientes.Inputs
{
    public class AtualizarClienteCommand : Notifiable, ICommandPadrao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public DateTime DataNascimentoConvertida { get; private set; }

        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Guid.Empty == Id)
                    AddNotification("Id", "Id obrigatório");

                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que o esperado");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha obrigatória");
                else if (!(Senha.Length >= 3 && Senha.Length <= 6))
                    AddNotification("Senha", "Senha deve ser maior que 3 e menor que 6 digitos");

                if (string.IsNullOrEmpty(Rg))
                    AddNotification("Rg", "Rg obrigatório");
                else if (Rg.Length > 8)
                    AddNotification("Rg", "Rg maior que o esperado");

                if (string.IsNullOrEmpty(Cpf))
                    AddNotification("Cpf", "Cpf obrigatório");
                else if (Cpf.Length > 11)
                    AddNotification("Cpf", "Cpf maior que o esperado");

                if (string.IsNullOrEmpty(Email))
                    AddNotification("Email", "Email obrigatório");
                else if (Email.Length > 50)
                    AddNotification("Email", "Email maior que o esperado");

                CultureInfo culture = new CultureInfo("pt-BR");
                DateTime dtNascimento;
                if (string.IsNullOrEmpty(DataNascimento))
                    AddNotification("DataNascimento", "Data de Nascimento obrigatório");
                else if (!DateTime.TryParseExact(DataNascimento, "yyyy-MM-dd", culture, DateTimeStyles.None, out dtNascimento))
                    AddNotification("DataNascimento", "Data de Nascimento inválida");
                else
                    DataNascimentoConvertida = dtNascimento;


                if (string.IsNullOrEmpty(Cep))
                    AddNotification("Cep", "Cep obrigatório");
                else if (Cep.Length > 9)
                    AddNotification("Cep", "Cep maior que o esperado");

                if (string.IsNullOrEmpty(Rua))
                    AddNotification("Rua", "Rua obrigatório");
                else if (Rua.Length > 50)
                    AddNotification("Rua", "Rua maior que o esperado");

                if (Numero <= 0)
                    AddNotification("Numero", "Número obrigatório");

                if (string.IsNullOrEmpty(Complemento))
                    AddNotification("Complemento", "Complemento obrigatório");
                else if (Complemento.Length > 50)
                    AddNotification("Complemento", "Complemento maior que o esperado");

                if (string.IsNullOrEmpty(Cidade))
                    AddNotification("Cidade", "Cidade obrigatório");
                else if (Cidade.Length > 50)
                    AddNotification("Cidade", "Cidade maior que o esperado");

                if (string.IsNullOrEmpty(Estado))
                    AddNotification("Estado", "Estado obrigatório");
                else if (Estado.Length > 50)
                    AddNotification("Estado", "Estado maior que o esperado");

                if (string.IsNullOrEmpty(Pais))
                    AddNotification("Pais", "Pais obrigatório");
                else if (Pais.Length > 50)
                    AddNotification("Pais", "Pais maior que o esperado");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
